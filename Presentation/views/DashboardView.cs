using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using System;
using System.Windows.Forms;

namespace Postal_Management_System.views
{
    public partial class DashboardView : Form
    {
        // Singleton instance
        private static DashboardView instance;

        // Repositories
        private readonly IStoreRepository<Employee> _employeeRepo;
        private readonly IStoreRepository<Customers> _customerRepo;
        private readonly IStoreRepository<Packages> _packageRepo;

        // Singleton accessor with dependency injection
        public static DashboardView GetInstance(Form parentContainer,
            IStoreRepository<Employee> employeeRepo,
            IStoreRepository<Customers> customerRepo,
            IStoreRepository<Packages> packageRepo)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DashboardView(employeeRepo, customerRepo, packageRepo);
                instance.MdiParent = parentContainer;
            }
            else if (instance.WindowState == FormWindowState.Minimized)
            {
                instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }

            return instance;
        }

        // Constructor for DI
        public DashboardView(
            IStoreRepository<Employee> employeeRepo,
            IStoreRepository<Customers> customerRepo,
            IStoreRepository<Packages> packageRepo)
        {
            InitializeComponent();

            _employeeRepo = employeeRepo;
            _customerRepo = customerRepo;
            _packageRepo = packageRepo;

            LoadCounts();
        }

        // Asynchronously load data
        private async void LoadCounts()
        {
            try
            {
                int employees = await _employeeRepo.GetTotalCountAsync();
                int customers = await _customerRepo.GetTotalCountAsync();
                int packages = await _packageRepo.GetTotalCountAsync();

                SetSummaryData(employees, customers, packages);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard statistics:\n{ex.Message}", "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to update dashboard UI labels
        public void SetSummaryData(int employeeCount, int customerCount, int packageCount)
        {
            lblEmployees.Text = $"👤 Employees: {employeeCount}";
            lblCustomers.Text = $"📦 Customers: {customerCount}";
            lblPackages.Text = $"📬 Packages: {packageCount}";
        }
    }
}

