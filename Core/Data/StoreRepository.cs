using Microsoft.EntityFrameworkCore;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using CsvHelper.Configuration;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Postal_Management_System.Core.Data
{
    public class StoreRepository<T> : IStoreRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public StoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByValueAsync(string value)
        {
            // Optional: Add filtering logic
            return await _context.Set<T>().FindAsync(value);
        }
       
        /// <summary>
        /// Returns paginated data from the entity as a DataTable.
        /// </summary>
        //pagination 
        public async Task<DataTable> GetDataTableAsync(int pageNumber, int pageSize)
        {
            try
            {
                // Step 1: Fetch data using GetAll<T>()
                var items = await _context.Set<T>()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(); // Reuse existing function

                if (items == null || !items.Any())
                {
                    Console.WriteLine($"No records found for {typeof(T).Name}.");
                    return new DataTable(); // Return an empty DataTable
                }

                // Step 2: Convert to DataTable
                DataTable dt = new DataTable();
                PropertyInfo[] props = typeof(T).GetProperties();

                // Add columns to DataTable
                foreach (var prop in props)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    Console.WriteLine($"Added column: {prop.Name}");
                }

                // Add rows to DataTable
                foreach (var item in items)
                {
                    var values = props.Select(p => p.GetValue(item, null)).ToArray();
                    dt.Rows.Add(values);
                    Console.WriteLine($"Added row: {string.Join(", ", values)}");
                }

                Console.WriteLine($"Successfully returned DataTable for {typeof(T).Name} with {dt.Rows.Count} rows.");
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetDataTableAsync: {ex.Message}");
                Console.WriteLine($"Error in GetPaginatedDataAsync: {ex.Message}");
                throw;
            }
        }
        /// <summary>
        /// Executes a raw SQL query to return all data from the specified table name.
        /// </summary>
        public async Task<DataTable> GetDataTable(string tableName)
        {
            var dataTable = new DataTable();

            await using (DbConnection connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                await using var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM [{tableName}]";

                using var reader = await command.ExecuteReaderAsync();
                dataTable.Load(reader);
            }

            return dataTable;
        }

        /// <summary>
        /// Placeholder for importing data from CSV using CsvHelper.
        /// </summary>
        //method to import CSV file
        public async Task ImportCsvToDatabase<T>(string filePath, string pkname, ClassMap map) where T : class, new()
        {
            var records = CsvLoader.ReadCsv<T>(filePath, map); // read and mapped
            var dbSet = _context.Set<T>();

            foreach (var record in records)
            {
                var keyProperty = typeof(T).GetProperty(pkname);

                if (keyProperty == null)
                {
                    Console.WriteLine($"Primary key {pkname} is not found in {typeof(T).Name}");
                    continue;
                }

                var keyValue = keyProperty.GetValue(record);
                //check if the record already exists in database
                var existingRecord = await dbSet.FindAsync(keyValue);
                if (existingRecord != null)
                {
                    Console.WriteLine($"Skipping duplicate record with primary key {keyValue}");
                    continue;
                }
                await dbSet.AddAsync(record);
            }

            try
            {
                Console.WriteLine("Starting database save...");

                await _context.SaveChangesAsync();
                Console.WriteLine($"Successfully imported {records.Count} records into {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");

            }


            return;
        }
        //Generate next customized id
        public string GetNextCustomId<T>() where T : class
        {
            string entityName = typeof(T).Name;
            var keyProperty = typeof(T).GetProperties()
                .FirstOrDefault(p => p.Name.EndsWith("ID") || p.Name.EndsWith("Id"));

            if (keyProperty == null)
                throw new InvalidOperationException("No ID property found");

            string prefix = GetPrefixForEntity(entityName);

            var dbSet = _context.Set<T>();
            var lastEntity = dbSet
                .AsEnumerable()
                .OrderByDescending(e => keyProperty.GetValue(e)?.ToString())
                .FirstOrDefault();

            if (lastEntity == null)
                return $"{prefix}001";

            var value = keyProperty.GetValue(lastEntity)?.ToString();
            if (string.IsNullOrEmpty(value) || value.Length <= prefix.Length)
                return $"{prefix}001"; // fallback if somehow empty

            string lastId = value.Substring(prefix.Length);
            if (!int.TryParse(lastId, out int numericId))
                numericId = 0;

            return $"{prefix}{(numericId + 1):D3}";
        }
        //Gets the prefix for the naming convention
        private string GetPrefixForEntity(string entityName)
        {
            return entityName switch
            {
                "Customers" => "C",
                "Packages" => "PG",
                "Employee" =>"E",
                "Tracking" => "T",
                _ => "X" //fallback
            };
        }

        //counts the total number of rows
        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}





