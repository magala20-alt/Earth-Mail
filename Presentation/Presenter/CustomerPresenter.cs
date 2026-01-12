
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Core.Services;
using Postal_Management_System.Presentation.Presenter.Common;
using Postal_Management_System.Presentation.views;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Postal_Management_System.Presentation.Presenter
{
    public class CustomerPresenter
    {
        private readonly ICustomerView _view;
        private readonly IStoreRepository<Customers> _repository;
        private readonly SearchManager<Customers> _searchManager;
        private readonly BindingSource _bindingSource = new();

        //pagination variables
        private int _currentPage = 1;
        private int _pageSize = 10;
        private int _totalPages = 1;

        public CustomerPresenter(
            ICustomerView view,
            IStoreRepository<Customers> repository,
            SearchManager<Customers> searchManager)
        {
            _view = view;
            _repository = repository;
            _searchManager = searchManager;

            // Event subscriptions
            _view.SaveCustomer += async (s, e) => await SaveCustomer();
            _view.DeleteCustomer += async (s, e) => await DeleteCustomer();
            _view.AddNewCustomer += AddNewCustomer;
            _view.EditCustomer += EditCustomer;
            _view.CancelEvent += CancelOperation;
            _view.ImportClicked += async (s, e) => await ImportCsv();
            _view.SearchCustomer += async (s, e) => await Search();

            _view.PreviousPageClicked += async (s, e) =>
            {
                if (_currentPage > 1)
                {
                    _currentPage--;
                    await LoadCustomersAsync();
                }
            };

            _view.NextPageClicked += async (s, e) =>
            {
                if (_currentPage < _totalPages)
                {
                    _currentPage++;
                    await LoadCustomersAsync();
                }
            };

            _view.SetCustomerListBindingSource(_bindingSource);
            ((Form)_view).Load += async (s, e) => await LoadCustomersAsync();
        }

        // Public wrapper to be used externally
        public async Task LoadCustomers()
        {
            await LoadCustomersAsync();
        }
        //load customer table
        private async Task LoadCustomersAsync()
        {
            var data = await _repository.GetDataTableAsync(_currentPage, _pageSize);
            var list = new List<Customers>();

            foreach (DataRow row in data.Rows)
            {
                list.Add(new Customers
                {
                    CustID = row["CustID"]?.ToString(),
                    Firstname = row["Firstname"]?.ToString(),
                    Lastname = row["Lastname"]?.ToString(),
                    Email = row["Email"]?.ToString(),
                    PhoneNo = row["PhoneNo"]?.ToString(),
                    Address = row["Address"]?.ToString()
                });
            }

            _bindingSource.DataSource = list;

            int totalCount = await _repository.GetTotalCountAsync();
            _totalPages = (int)Math.Ceiling((double)totalCount / _pageSize);
            _view.UpdatePageLabel($"Page {_currentPage} of {_totalPages}");
        }
        //add new customer
        private void AddNewCustomer(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            //_view.CustomerID = string.Empty; deleted so that it can show on the form
            _view.CustomerFirstname = string.Empty;
            _view.CustomerLastname = string.Empty;
            _view.CustomerEmail = string.Empty;
            _view.CustomerPhone = string.Empty;
            _view.CustomerAddress = string.Empty;
        }
        //edit customer
        private void EditCustomer(object? sender, EventArgs e)
        {
            if (_bindingSource.Current is Customers selected)
            {
                _view.IsEdit = true;
                _view.CustomerID = selected.CustID;
                _view.CustomerFirstname = selected.Firstname;
                _view.CustomerLastname = selected.Lastname;
                _view.CustomerEmail = selected.Email;
                _view.CustomerPhone = selected.PhoneNo;
                _view.CustomerAddress = selected.Address;
            }
        }
        //save customer
        private async Task SaveCustomer()
        {
            var model = new Customers
            {
                CustID = _view.CustomerID,
                Firstname = _view.CustomerFirstname,
                Lastname = _view.CustomerLastname,
                Email = _view.CustomerEmail,
                PhoneNo = _view.CustomerPhone,
                Address = _view.CustomerAddress
            };

            try
            { 
                if (_view.IsEdit)
                {
                    var existing = await _repository.GetByValueAsync(_view.CustomerID);
                    if (existing == null)
                    {
                        _view.IsSuccessful = false;
                        _view.Message = "Customer not found!";
                        return;
                    }
                    existing.Firstname = _view.CustomerFirstname;
                    existing.Lastname = _view.CustomerLastname;
                    existing.Email = _view.CustomerEmail;
                    existing.PhoneNo = _view.CustomerPhone;
                    existing.Address = _view.CustomerAddress;

                    new Common.EntitiyValidation().ValidateEntity(existing);

                    await _repository.UpdateAsync(existing);
                    _view.IsSuccessful = true;
                    _view.Message = "Saved successfully!";


                }
                else {
                    await _repository.AddAsync(model);
                    _view.Message = "Saved successfully!";
                }
                _view.IsSuccessful = true;
                await LoadCustomersAsync();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                _view.Message = $"Error saving: {ex.Message}";
                _view.IsSuccessful = false;
            }
        }
        //clears content when saved
        private void CleanViewFields()
        {
            _view.IsEdit = false;
            _view.CustomerFirstname = string.Empty;
            _view.CustomerLastname = string.Empty;
            _view.CustomerEmail = string.Empty;
            _view.CustomerPhone = string.Empty;
            _view.CustomerAddress = string.Empty;
        }
        //delete customer
        private async Task DeleteCustomer()
        {
            if (_bindingSource.Current is Customers selected)
            {
                try
                {
                    Console.WriteLine($"Selected Customer ID: {selected.CustID}");
                    // Optional: Fetch fresh entity from DB
                    var actualCustomer = await _repository.GetByValueAsync(selected.CustID);
                    if (actualCustomer == null)
                    {
                        _view.IsSuccessful = false;
                        _view.Message = "Customer not found in database.";
                        return;
                    }
                    await _repository.DeleteAsync(actualCustomer);
                    _view.IsSuccessful = true;
                    _view.Message = "Deleted successfully!";
                    await LoadCustomersAsync();
                }
                catch (Exception ex)
                {
                    _view.IsSuccessful = false;
                    _view.Message = $"Error deleting: {ex.Message}";
                   
                }
            }
        }
        //import customer csv
        private async Task ImportCsv()
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Select CSV file"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var filePath = ofd.FileName;
                string pkName = Interaction.InputBox("Enter primary key column:", "Primary Key", "CustID");

                try
                {
                    await _repository.ImportCsvToDatabase<Customers>(filePath, pkName, new CustomersMap());
                    await LoadCustomersAsync();
                    _view.Message = "CSV imported!";
                    _view.IsSuccessful = true;
                }
                catch (Exception ex)
                {
                    _view.Message = $"Import failed: {ex.Message}";
                    _view.IsSuccessful = false;
                }
            }
        }
        //search customer
        private async Task Search()
        {
            var result = await _searchManager.SearchByValueAsync(_view.Searchtext);
            if (result != null)
            {
                var found = new Customers
                {
                    CustID = result["CustID"].ToString(),
                    Firstname = result["Firstname"].ToString(),
                    Lastname = result["Lastname"].ToString(),
                    Email = result["Email"].ToString(),
                    PhoneNo = result["PhoneNo"].ToString(),
                    Address = result["Address"].ToString()
                };

                _bindingSource.DataSource = new List<Customers> { found };
                _view.Message = "Search successful.";
            }
            else
            {
                _view.Message = "No match found.";
            }
        }
        //when cancel button is pressed
        private void CancelOperation(object? sender, EventArgs e)
        {
            _view.CustomerID = string.Empty;
            _view.CustomerFirstname = string.Empty;
            _view.CustomerLastname = string.Empty;
            _view.CustomerEmail = string.Empty;
            _view.CustomerPhone = string.Empty;
            _view.CustomerAddress = string.Empty;
        }
    }
}
