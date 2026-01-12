using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Postal_Management_System.Core.Interfaces;

namespace Postal_Management_System.Core.Services
{
    public class LoginManager<T> where T : class
    {
        private readonly IStoreRepository<T> _repository;
        private Dictionary<string, string> _userCredentials; // Username → Passord(EmployeeID)

        public LoginManager(IStoreRepository<T> repository)
        {
            _repository = repository;
            _userCredentials = new Dictionary<string, string>();
        }

        // Load user data from the database into the HashMap
        public async Task LoadUsersAsync()
        {
            int totalCount = await _repository.GetTotalCountAsync();
            var data = await _repository.GetDataTableAsync(1, totalCount);
            _userCredentials.Clear();

            foreach (DataRow row in data.Rows)
            {
                string username = row["firstname"].ToString();
                string password = row["EmployeeID"].ToString();

                if (!_userCredentials.ContainsKey(username))
                {
                    _userCredentials.Add(username, password);
                }
            }
        }

        // Authenticate user using HashMap
        public bool Authenticate(string username, string password)
        {
            if (_userCredentials.TryGetValue(username, out var storedPassword))
            {
                return storedPassword == password;
            }
            return false;
        }
    }
}