using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Postal_Management_System.Core.Data;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Core.Services;
using Postal_Management_System.Presentation.Presenter;
using Postal_Management_System.Presentation.views;
using Postal_Management_System.views;

namespace Postal_Management_System.Presenter.views
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole(); // Optional console

        [STAThread]
        static void Main()
        {
            AllocConsole(); // Attach console for debugging/logs

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            // Register DbContext with connection string
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Postage;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

            //register repositories
            services.AddScoped(typeof(IStoreRepository<>), typeof(StoreRepository<>));

            // Register AdminView
            services.AddScoped<IAdminView, AdminView>(); 
            services.AddScoped<AdminPresenter>();

            //register LoginView
            services.AddScoped<ILoginView, LoginView>();
            services.AddScoped<LoginPresenter>(provider =>
            {
                return new LoginPresenter(
                    provider.GetRequiredService<ILoginView>(),
                    provider.GetRequiredService<IStoreRepository<Employee>>(),
                    provider.GetRequiredService<IStoreRepository<Packages>>(),
                    provider.GetRequiredService<IStoreRepository<Customers>>(),
                    provider.GetRequiredService<IStoreRepository<Tracking>>(),
                    provider.GetRequiredService<LoginManager<Employee>>()
                );
            });

            // Register CustomerView
            services.AddScoped<ICustomerView, CustomerView>();
            services.AddScoped<CustomerPresenter>();
            // Register EmployeeView
            services.AddScoped<IEmployeeView, EmployeeView>();
            services.AddScoped<EmployeePresenter>();
            //Register PackageView
            services.AddScoped<IPackageView, PackageView>();
            services.AddScoped<packagePresenter>();
            // Register TrackingView
            services.AddScoped<ITrackingView, TransactConfigView>();
            services.AddScoped<TrackingPresenter>();
            //Register Dashboard view
            services.AddScoped<DashboardView>();

            services.AddScoped(typeof(SearchManager<>));// Manages searching by ID
            //services.AddScoped(typeof(FilterManager<>));     // Handles filtering by package status
            services.AddScoped<SortManager<Packages>>(); // handles sort
            // Sorts packages by delivery deadlines
            //services.AddScoped<GraphManager>();      // Determines shortest delivery route using graphs
            services.AddScoped(typeof(LoginManager<>));      // Handles login authentication from Users table
            services.AddScoped<InvoiceEngine>(); // handles billing

            // Build provider for repository
            var serviceProvider = services.BuildServiceProvider();

            Console.WriteLine(" Dependencies resolved!");

           
            //services used 

            services.AddScoped(typeof(SearchManager<>));// Manages searching by ID
            //services.AddScoped(typeof(FilterManager<>));     // Handles filtering by package status
            //services.AddScoped<SortManager>();       // Sorts packages by delivery deadlines
            //services.AddScoped<GraphManager>();      // Determines shortest delivery route using graphs
            services.AddScoped(typeof(LoginManager<>));      // Handles login authentication from Users table

            
            Console.WriteLine("Service successfully resolved!");

            
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;

                var AdminView = provider.GetRequiredService<ILoginView>();
                provider.GetRequiredService<LoginPresenter>(); // Hook up events

                Application.Run((Form)AdminView);
            }
        }
    }
}
