using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Postal_Management_System.Core.Interfaces;

namespace Postal_Management_System.Core.Services
{
    public class GraphManager
    {
        private readonly IStoreRepository<object> _repository; // Use generic object for table-level queries
        private readonly Dictionary<string, List<string>> _adjacencyList;

        public GraphManager(IStoreRepository<object> repository)
        {
            _repository = repository;
            _adjacencyList = new Dictionary<string, List<string>>();
        }

        // Load routes into graph from DB
        public async Task LoadGraphAsync()
        {
            try
            {
                var resultTable = await _repository.GetDataTable("Routes"); // You should have a 'Routes' table

                foreach (DataRow row in resultTable.Rows)
                {
                    string from = row["FromLocation"].ToString();
                    string to = row["ToLocation"].ToString();

                    if (!_adjacencyList.ContainsKey(from))
                        _adjacencyList[from] = new List<string>();

                    _adjacencyList[from].Add(to);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error loading graph: {ex.Message}");
            }
        }

        // BFS to find shortest route
        public List<string> FindShortestRoute(string start, string end)
        {
            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            var parent = new Dictionary<string, string>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == end)
                    return ReconstructPath(parent, start, end);

                if (_adjacencyList.ContainsKey(current))
                {
                    foreach (var neighbor in _adjacencyList[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            parent[neighbor] = current;
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            return null; // No path found
        }

        private List<string> ReconstructPath(Dictionary<string, string> parent, string start, string end)
        {
            var path = new List<string>();
            var current = end;

            while (current != start)
            {
                path.Insert(0, current);
                current = parent[current];
            }

            path.Insert(0, start);
            return path;
        }
    }
}
