using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Postal_Management_System.Core.Data;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Core.Services;
using Postal_Management_System.Presentation.views;
using Postal_Management_System.views;

namespace Postal_Management_System.Presentation.Presenter
{
    public class AdminPresenter
    {
        private readonly IAdminView _adminView;
        private readonly IStoreRepository<Employee> _employeeRepository;
        private readonly IStoreRepository<Packages> _packageRepository;
        private readonly IStoreRepository<Customers> _customerRepository;
        private readonly IStoreRepository<Tracking> _trackingRepository;
        private readonly DashboardView dashboardView;
        public AdminPresenter(
            IAdminView adminView,
            IStoreRepository<Employee> employeeRepository,
            IStoreRepository<Packages> packageRepository,
            IStoreRepository<Customers> customerRepository,
            IStoreRepository<Tracking> trackingRepository)
        {
            _adminView = adminView;
            _employeeRepository = employeeRepository;
            _packageRepository = packageRepository;
            _customerRepository = customerRepository;
            _trackingRepository = trackingRepository;

            //casting views to the admin view
            _adminView.ShowEmployeeView += async (s, e) => await ShowEmployeeViewAsync();
            _adminView.ShowCustomerView += async (s, e) => await ShowCustomerViewAsync();
            _adminView.ShowPackageView += async (s, e) => await ShowPackageViewAsync();
            _adminView.ShowTrackingView += async (s, e) => await ShowTrackingViewAsync();
            _adminView.ShowDashboardView += async (s, e) => await ShowDashboardViewAsync();
            _adminView.Logout += async (s, e) => await _adminView_Logout();

           

           
        }

        private async Task ShowDashboardViewAsync()
        {
            var dashboardView = DashboardView.GetInstance((Form)_adminView, _employeeRepository, _customerRepository, _packageRepository);
            int packageCount = await _packageRepository.GetTotalCountAsync();
            int employeeCount = await _employeeRepository.GetTotalCountAsync();
            int customerCount = await _customerRepository.GetTotalCountAsync();

            dashboardView.SetSummaryData(employeeCount, customerCount, packageCount);

            DisplayInPanel((Form)dashboardView);

        }

        //show tracking view
        private async Task ShowTrackingViewAsync()
        {
            var trackingView = TransactConfigView.GetInstance((Form)_adminView);
            var searchManager = new SearchManager<Tracking>(_trackingRepository);
            var presenter = new TrackingPresenter(trackingView, _trackingRepository,_packageRepository, searchManager);
           
            await presenter.LoadTrackingAsync();
            DisplayInPanel((Form)trackingView);
        }
       //show package view
        private async Task ShowPackageViewAsync()
        {
            var packageView = PackageView.GetInstance((Form)_adminView);
            var searchManager = new SearchManager<Packages>(_packageRepository);
            InvoiceEngine invoiceEngine = new InvoiceEngine(_trackingRepository);
            var presenter = new packagePresenter(packageView, _packageRepository, searchManager,invoiceEngine);

            await presenter.LoadPackages();
            DisplayInPanel((Form)packageView);
        }
        //show customer view
        private async Task ShowCustomerViewAsync()
        {
            var customerView = CustomerView.GetInstance((Form)_adminView);
            var searchManager = new SearchManager<Customers>(_customerRepository);
            var presenter = new CustomerPresenter(customerView, _customerRepository, searchManager);

            await presenter.LoadCustomers();
            DisplayInPanel((Form)customerView);
        }
        //show employee view
        private async Task ShowEmployeeViewAsync()
        {
            var employeeView = EmployeeView.GetInstance((Form)_adminView);
            var searchManager = new SearchManager<Employee>(_employeeRepository);
            var presenter = new EmployeePresenter(employeeView, _employeeRepository, searchManager);

            await presenter.LoadEmployees();
            DisplayInPanel((Form)employeeView);
        }

        //method to display in admin panel
        private void DisplayInPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            var adminForm = (AdminView)_adminView;
            adminForm.contentPanel.Controls.Clear();
            adminForm.contentPanel.Controls.Add(form);
            form.Show();
        }
        //logout
        private async Task _adminView_Logout()
        {
            
        }
    }
}


