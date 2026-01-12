using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Core.Services;
using Postal_Management_System.Presentation.views;
using Postal_Management_System.views;

namespace Postal_Management_System.Presentation.Presenter
{
    public class LoginPresenter
    {
        private readonly ILoginView _loginView;
        private readonly LoginManager<Employee> _loginManager;

        private IAdminView? _adminView;
        private AdminPresenter? _adminPresenter;

        private readonly IStoreRepository<Employee> _employeeRepository;
        private readonly IStoreRepository<Packages> _packageRepository;
        private readonly IStoreRepository<Customers> _customerRepository;
        private readonly IStoreRepository<Tracking> _trackingRepository;

        public LoginPresenter(
            ILoginView loginView,
            IStoreRepository<Employee> employeeRepository,
            IStoreRepository<Packages> packageRepository,
            IStoreRepository<Customers> customerRepository,
            IStoreRepository<Tracking> trackingRepository,
            LoginManager<Employee> loginManager)
        {
            _loginView = loginView;
            _employeeRepository = employeeRepository;
            _packageRepository = packageRepository;
            _customerRepository = customerRepository;
            _trackingRepository = trackingRepository;
            _loginManager = loginManager;

            // Event wiring
            _loginView.LoggedIn += _LogIn;
            _loginView.Logout += _LogOut;
            _loginView.ShowAdmin += async (s, e) => await ShowAdminWindow();
        }

        private async void _LogIn(object? sender, EventArgs e)
        {
            await _loginManager.LoadUsersAsync();

            string username = _loginView.username;
            string password = _loginView.password;

            if (_loginManager.Authenticate(username, password))
            {
                _loginView.ShowMessage($"Welcome, {username}!");

                //// Raise ShowAdmin to load AdminForm
                //_loginView.ShowAdmin?.Invoke(this, EventArgs.Empty);
                // Show the admin window
                await ShowAdminWindow();

                // Now close the login form
                //_loginView.CloseLoginForm();
            }
            else
            {
                _loginView.ShowMessage("Invalid username or password.");
            }
        }

        private async Task ShowAdminWindow()
        {
            if (_adminView == null)
            {
                _adminView = new AdminView(); // Your AdminForm
                _adminPresenter = new AdminPresenter(
                    _adminView,
                    _employeeRepository,
                    _packageRepository,
                    _customerRepository,
                    _trackingRepository
                );

                _adminView.Logout += _LogOut;

                // When AdminForm is closed, show login form again
                (_adminView as Form)!.FormClosed += (s, e) =>
                {
                    _loginView.ShowLoginForm();
                    _adminView = null;
                    _adminPresenter = null;
                };
            }

            (_adminView as Form)!.Show();
        }
        // logout
        private void _LogOut(object? sender, EventArgs e)
        {
            (_adminView as Form)?.Close();
            _loginView.ShowLoginForm();
        }
    }
}
