using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Core.Entities;

namespace Postal_Management_System.Core.Services
{
    public class FilterManager
    {
        private readonly IStoreRepository<Packages> _packageRepository;

        public FilterManager(IStoreRepository<Packages> packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<List<Packages>> FilterByStatusAsync(string status)
        {
            var result = new List<Packages>();
            var table = await _packageRepository.GetDataTable("Packages");

            foreach (DataRow row in table.Rows)
            {
                if (row["Status"].ToString().Equals(status, System.StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(new Packages
                    {
                        PackageID = row["PackageID"].ToString(),
                        Status = row["Status"].ToString(),
                        // Add more mappings as needed
                    });
                }
            }

            return result;
        }
    }
}
