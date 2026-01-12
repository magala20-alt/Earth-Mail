using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Data;

namespace Postal_Management_System.Core.Services
{
    public class SortManager<T> where T : class
    {
        private readonly IStoreRepository<T> _repository;

        // Injecting IStoreRepository for Database Access
        public SortManager(IStoreRepository<T> repository)
        {
            _repository = repository;
        }

        // Fetch and Sort Packages by Deadline
        public async Task<List<Packages>> SortPackagesByDeadlineAsync()
        {
            var packages = new List<Packages>();

            try
            {
                int totalCount = await _repository.GetTotalCountAsync();
                var resultTable = await _repository.GetDataTableAsync(1, totalCount);

                if (resultTable != null)
                {
                    foreach (DataRow row in resultTable.Rows)
                    {
                        packages.Add(new Packages
                        {
                            PackageID = row["packageID"].ToString(),
                            Deadline = DateTime.Parse(row["Deadline"].ToString())
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching packages: {ex.Message}");
            }

            return MergeSort(packages);
        }

        private List<Packages> MergeSort(List<Packages> packages)
        {
            if (packages.Count <= 1)
                return packages;

            int mid = packages.Count / 2;

            var left = MergeSort(packages.GetRange(0, mid));
            var right = MergeSort(packages.GetRange(mid, packages.Count - mid));

            return Merge(left, right);
        }

        private List<Packages> Merge(List<Packages> left, List<Packages> right)
        {
            var result = new List<Packages>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0].Deadline <= right[0].Deadline)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            result.AddRange(left);
            result.AddRange(right);

            return result;
        }
    }
}
