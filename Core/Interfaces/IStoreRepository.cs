using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace Postal_Management_System.Core.Interfaces
{
    /// <summary>
    /// Generic repository interface for CRUD and data access operations.
    /// </summary>
    public interface IStoreRepository<T> where T : class
    {
        /// <summary>
        /// Asynchronously adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Asynchronously updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Asynchronously deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Asynchronously retrieves a list of entities matching a specific value.
        /// </summary>
        /// <param name="value">The value to filter on.</param>
        Task<T> GetByValueAsync(string value);

        /// <summary>
        /// Asynchronously gets a paginated DataTable of records.
        /// </summary>
        /// <param name="pageNumber">The page number (starting at 1).</param>
        /// <param name="pageSize">The number of records per page.</param>
        Task<DataTable> GetDataTableAsync(int pageNumber = 1, int pageSize = 10);

        /// <summary>
        /// Retrieves a full DataTable from a raw table name.
        /// </summary>
        /// <param name="tableName">The table name in the database.</param>
        Task<DataTable> GetDataTable(string tableName);

        /// <summary>
        /// Gets the total number of records in the set.
        /// </summary>
        Task<int> GetTotalCountAsync();

        /// <summary>
        /// Imports data from a CSV file to the database.
        /// </summary>
        /// <typeparam name="TModel">Model type matching the CSV schema.</typeparam>
        /// <param name="filePath">Full path to the CSV file.</param>
        /// <param name="pKname">The primary key column name in the CSV.</param>
        /// <param name="map">CsvHelper ClassMap for mapping CSV to entity.</param>
        Task ImportCsvToDatabase<TModel>(string filePath, string pKname, ClassMap map) where TModel : class, new();

        public string GetNextCustomId<T>() where T : class;
    }
}
