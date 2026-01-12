using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postal_Management_System.views;
using Postal_Management_System.Core;
using Postal_Management_System.Presentation.views;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using System.Data;
using Postal_Management_System.Core.Services;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Postal_Management_System.Presentation.Presenter
{
    public class EmployeePresenter
    {
        private IEmployeeView view;
        private readonly IStoreRepository<Employee> _employeeRepository;
        private BindingSource _EmployeeBindingSource= new();
        private SearchManager<Employee> _searchManager;

        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 1;

        public EmployeePresenter(IEmployeeView view, IStoreRepository<Employee> employeeRepository, SearchManager<Employee> searchManager)
        {
            this._EmployeeBindingSource = new BindingSource();
            this.view = view;
            _employeeRepository = employeeRepository;
            this._searchManager = searchManager;

            //Subscribe events handler methods to view events
            this.view.SearchEvent += SearchEmployee;
            this.view.AddNewEmployee += AddNewEmployee;
            this.view.SaveEmployee += async (s, e) => await SaveEmployee();
            this.view.DeleteEmployee += async (s, e) => await DeleteEmployee();
            this.view.EditEmployee += EditEmployee;
            this.view.cancelEvent += exit;
            this.view.ImportClicked += ImportCsv;

            this.view.PreviousPageClicked += async (s, e) =>
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    await LoadEmployees();
                }
            };

            this.view.NextPageClicked += async (s, e) =>
            {
                if (currentPage < totalPages)
                {
                    currentPage++;
                    await LoadEmployees();
                }
            };
            //set the bindingsource to view
            this.view.SetEmployeeListBindingSource(_EmployeeBindingSource);
            // 🔥 Load data when form is loaded, not in constructor
            ((Form)view).Load += async (s, e) => await LoadEmployees();

        }

        private async void ImportCsv(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Select a CSV file to import";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Prompt the user to enter the primary key name
                    string pkName = Interaction.InputBox("Enter the name of the primary key column:", "Primary Key Required", "Id");
                    try
                    {

                        await _employeeRepository.ImportCsvToDatabase<Employee>(filePath, pkName, new EmployeeMap());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred during import: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("File selection was cancelled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public async Task LoadEmployees()
        {
            try
            {
                var totalCount = await _employeeRepository.GetTotalCountAsync();
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var employeeTable = await _employeeRepository.GetDataTableAsync(currentPage,pageSize);
                if (employeeTable.Rows.Count == 0)
                {
                    MessageBox.Show("No employee records found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var list = new List<Employee>();
                foreach (DataRow row in employeeTable.Rows)
                {
                    list.Add(new Employee
                    {
                        EmployeeID = row["EmployeeID"]?.ToString(),
                        Firstname = row["Firstname"]?.ToString(),
                        Lastname = row["Lastname"]?.ToString(),
                        Role = row["Role"]?.ToString(),
                       
                    });
                }
                //_EmployeeBindingSource.DataSource = employeeTable;
                // ✅ This is the key line — set DefaultView
                _EmployeeBindingSource.DataSource = list;
                _EmployeeBindingSource.ResetBindings(false);

                Console.WriteLine("BindingSource set with DataTable.");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void exit(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditEmployee(object? sender, EventArgs e)
        {
            if (_EmployeeBindingSource.Current is Employee selected)
            {
                view.IsEdit = true;
                view.EmployeeID= selected.EmployeeID;
                view.Firstname = selected.Firstname;
                view.Lastname = selected.Lastname;
                view.Role = selected.Role;
                
            }
        }

        public async Task DeleteEmployee()
        {
            if (_EmployeeBindingSource.Current is Employee selected)
            {
                try
                {
                    Console.WriteLine($"Selected Customer ID: {selected.EmployeeID}");
                    // Optional: Fetch fresh entity from DB
                    var actualEmployee = await _employeeRepository.GetByValueAsync(selected.EmployeeID);
                    if (actualEmployee == null)
                    {
                        view.IsSuccessful = false;
                        view.Message = "Employee not found in database.";
                        return;
                    }
                    await _employeeRepository.DeleteAsync(actualEmployee);
                    view.IsSuccessful = true;
                    view.Message = "Deleted successfully!";
                    await LoadEmployees();
                }
                catch (Exception ex)
                {
                    view.IsSuccessful = false;
                    view.Message = $"Error deleting: {ex.Message}";

                }
            }
        }

        private async Task SaveEmployee()
        {
            var model = new Employee
            {
                EmployeeID = view.EmployeeID,
                Firstname = view.Firstname,
                Lastname = view.Lastname,
                Role = view.Role
            };
            try
            {
                if (view.IsEdit)
                {
                    var existing = await _employeeRepository.GetByValueAsync(view.EmployeeID);
                    if (existing == null)
                    {
                        view.IsSuccessful = false;
                        view.Message = "Customer not found!";
                        return;
                    }
                    existing.EmployeeID = view.EmployeeID;
                    existing.Firstname = view.Firstname;
                    existing.Lastname = view.Lastname;
                    existing.Role = view.Role;
                 
                    new Common.EntitiyValidation().ValidateEntity(existing);

                    await _employeeRepository.UpdateAsync(existing);
                    view.IsSuccessful = true;
                    view.Message = "Saved successfully!";
                }
                else
                {
                    await _employeeRepository.AddAsync(model);
                    view.Message = "Saved successfully!";
                }
                view.IsSuccessful = true;
                await LoadEmployees();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.Message = $"Error saving: {ex.Message}";
                view.IsSuccessful = false;
            }
        }

        private void CleanViewFields()
        {
            view.IsEdit = false;
            view.Firstname = string.Empty;
            view.Lastname = string.Empty;
            view.Role = string.Empty;
           
        }

        private void AddNewEmployee(object? sender, EventArgs e)
        {
            view.IsEdit = false;
            view.Firstname = string.Empty;
            view.Lastname = string.Empty;
            view.Role = string.Empty;
            
        }

        private async void SearchEmployee(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(view.SearchedEmployee))
            {
                await LoadEmployees(); // Show default results
                return;
            }

            try
            {
                var foundRow = await _searchManager.SearchByValueAsync(view.SearchedEmployee);


                if (foundRow == null)
                {
                    MessageBox.Show("No matching results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create a temporary DataTable to show just the found row
                DataTable resultTable = foundRow.Table.Clone(); // clone schema
                resultTable.ImportRow(foundRow);

                _EmployeeBindingSource.DataSource = resultTable.DefaultView;
                _EmployeeBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
