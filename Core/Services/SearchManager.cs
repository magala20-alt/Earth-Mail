using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Postal_Management_System.Core.Interfaces;

namespace Postal_Management_System.Core.Services
{
    public class SearchManager<T> where T : class
    {
        private readonly IStoreRepository<T> _repository;
        private Dictionary<string, Dictionary<string, DataRow>> _cacheMap;

        public SearchManager(IStoreRepository<T> repository)
        {
            _repository = repository;
            
        }

        // Load search result into a datarow.
        public async Task<DataRow?> SearchByValueAsync(string value, string[]? columnsToSearch = null)
        {
            try
            {
                int totalCount = await _repository.GetTotalCountAsync();
                var table = await _repository.GetDataTableAsync(1, totalCount);

                if (table == null || table.Rows.Count == 0)
                    return null;

                // If no specific columns provided, load all columns into an array
                if (columnsToSearch == null || columnsToSearch.Length == 0)
                {
                    columnsToSearch = table.Columns
                        .Cast<DataColumn>()
                        .Where(c => c.DataType == typeof(string) || c.DataType == typeof(int))
                        .Select(c => c.ColumnName)
                        .ToArray();
                }

                // Create a hashmap of column -> value -> row
                var searchMap = new Dictionary<string, Dictionary<string, DataRow>>();
                foreach (var column in columnsToSearch)
                {
                    if (!table.Columns.Contains(column)) continue;

                    var columnMap = new Dictionary<string, DataRow>(StringComparer.OrdinalIgnoreCase);

                    foreach (DataRow row in table.Rows)
                    {
                        string key = row[column]?.ToString() ?? "";
                        if (!columnMap.ContainsKey(key))
                        {
                            columnMap[key] = row;
                        }
                    }

                    searchMap[column] = columnMap;
                }

                // Search value in each column map
                foreach (var column in searchMap.Keys)
                {
                    var colMap = searchMap[column];
                    if (colMap.TryGetValue(value, out DataRow? foundRow))
                    {
                        Console.WriteLine("Found the searched item");
                        return foundRow;
                    }
                }
                Console.WriteLine("No result found");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        
    }

    
}