using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postal_Management_System.Presentation.views;
using Postal_Management_System.Core;
using Postal_Management_System.Core.Services;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using System.Data;
using System.IO.Packaging;
using Microsoft.VisualBasic;
using Postal_Management_System.Core.Data;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;


namespace Postal_Management_System.Presentation.Presenter
{
    public class packagePresenter
    {
        private IPackageView view;
        private readonly IStoreRepository<Packages> _packageRepository;
        private readonly IStoreRepository<Tracking> _trackingRepository;
        private SearchManager<Packages> _searchManager;
        private readonly InvoiceEngine _invoiceEngine;
        private readonly SortManager<Packages> _sortManager;
        private BindingSource _packageBindingSource;

        private static readonly object _repoLock = new object();
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 1;

        public packagePresenter(IPackageView view, IStoreRepository<Packages> packageRepository, SearchManager<Packages> searchManager,InvoiceEngine invoiceEngine)
        {
            _packageBindingSource = new BindingSource();
            this.view = view;
            _packageRepository = packageRepository;
            _searchManager = searchManager;
            _invoiceEngine = invoiceEngine;

            //Subscribe events handler methods to view events
            this.view.SearchEvent += searchPackage;
            this.view.AddNewPackage += AddNewPackage;
            this.view.SavePackage += async (s, e) => await SavePackage();
            this.view.DeletePackage += DeletePackage;
            this.view.EditPackage += EditPackage;
            this.view.cancelEvent += exit;
            this.view.ImportClicked += ImportCsv;
            this.view.SortByDeadline += async (s, e) => await OnSortByDeadline();
            this.view.PreviousPageClicked += async (s, e) =>
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    await LoadPackages();
                }
            };

            this.view.NextPageClicked += async (s, e) =>
            {
                if (currentPage < totalPages)
                {
                    currentPage++;
                    await LoadPackages();
                }
            };
            //setting binding source to view
            this.view.SetPackageListBindingSource(_packageBindingSource);

            // 🔥 Load data when form is loaded, not in constructor
            ((Form)view).Load += async (s, e) => await LoadPackages();
        }
        //import package csv
        private async void  ImportCsv(object? sender, EventArgs e)
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

                        await _packageRepository.ImportCsvToDatabase<Packages>(filePath, pkName, new PackagesMap());
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
        //load all packages to view
        public async Task LoadPackages()
        {
            try
            {
                var totalCount = await _packageRepository.GetTotalCountAsync();
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                var packageTable = await _packageRepository.GetDataTableAsync(currentPage, pageSize);
                var list = new List<Packages>();
                foreach (DataRow row in packageTable.Rows)
                {
                    list.Add(new Packages
                    {
                        PackageID = row["PackageID"]?.ToString(),
                        Weight = row["Weight"] != DBNull.Value ? Convert.ToInt32(row["Weight"]) : 0,
                        Length = row["Length"] != DBNull.Value ? Convert.ToInt32(row["Length"]) : 0,
                        Width = row["Width"] != DBNull.Value ? Convert.ToInt32(row["Width"]) : 0,
                        Height = row["Height"] != DBNull.Value ? Convert.ToInt32(row["Height"]) : 0,
                        Status = row["Status"]?.ToString(),
                        Dest_address = row["Dest_address"]?.ToString(),
                        ContentDes = row["ContentDes"]?.ToString(),
                        Deadline = row["Deadline"] != DBNull.Value ? Convert.ToDateTime(row["Deadline"]) : DateTime.MinValue,
                        TrackingID = row["TrackingID"]?.ToString(),
                        //CustomersCustID = row["CustID"]?.ToString()
                    });
                }
                //_EmployeeBindingSource.DataSource = employeeTable;
                // ✅ This is the key line — set DefaultView
                _packageBindingSource.DataSource = list;
                _packageBindingSource.ResetBindings(false);

                Console.WriteLine("BindingSource set with DataTable.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void exit(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //edit package contents
        private void EditPackage(object? sender, EventArgs e)
        {
            if (_packageBindingSource.Current is Packages selected)
            {
                view.IsEdit = true;
                view.PackageWeight = selected.Weight;
                view.PackageWidth = selected.Width;
                view.PackageLength = selected.Length;
                view.PackageHeight = selected.Height;
                view.PackageStatus = selected.Status;
                view.Dest_address = selected.Dest_address;
                view.ContentDes = selected.ContentDes;
                view.PackageID = selected.PackageID;
            }
        }
        //delete package
        private void DeletePackage(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //save package also generate tracking id
        private async Task SavePackage()
        {
            var model = new Packages
            {
                PackageID = view.PackageID,
                Weight = view.PackageWeight,
                Length = view.PackageLength,
                Width = view.PackageWidth,
                Height= view.PackageHeight,
                Status= view.PackageStatus,
                Dest_address = view.Dest_address,
                ContentDes= view.ContentDes,
                Deadline= view.Deadline,
                TrackingID = string.Empty, // Assuming TrackingID is not set here
             
            };

            try
            {
                if (view.IsEdit)
                {
                    var existing = await _packageRepository.GetByValueAsync(view.PackageID);
                    Console.WriteLine(existing);
                    if (existing == null)
                    {
                        view.IsSuccessful = false;
                        view.Message = "Package not found!";
                        return;
                    }
                    existing.PackageID = view.PackageID;
                    existing.Weight = view.PackageWeight;
                    existing.Length = view.PackageLength;
                    existing.Width = view.PackageWidth;
                    existing.Height = view.PackageHeight;
                    existing.Dest_address = view.Dest_address;
                    existing.ContentDes = view.ContentDes;

                    new Common.EntitiyValidation().ValidateEntity(existing);

                    await _packageRepository.UpdateAsync(existing);
                    view.IsSuccessful = true;
                    view.Message = "Saved successfully!";
                }
                else
                {
                    // If new package, make sure TrackingID is generated
                   var tracking = await _invoiceEngine.GenerateForAsync(model);
                        model.TrackingID = tracking.TrackingID;  
                    

                    // Validate and add the package
                    new Common.EntitiyValidation().ValidateEntity(model);
                    lock (_repoLock)
                    {
                         _packageRepository.AddAsync(model);
                    }
                    view.Message = "Package and tracking saved successfully!";
                    view.IsSuccessful = true;
                }
                view.IsSuccessful = true;
                await LoadPackages();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.Message = $"Error saving: {ex.Message}";
                Console.WriteLine(ex);
                view.IsSuccessful = false;
            }
        }

        private void CleanViewFields()
        {
            view.PackageID= string.Empty;
            view.PackageWeight = 0;
            view.PackageLength = 0;
            view.PackageWidth = 0;
            view.PackageHeight = 0;
            view.Dest_address = string.Empty;
            view.ContentDes = string.Empty;
        }

        private void AddNewPackage(object? sender, EventArgs e)
        {
            view.IsEdit = false;
            //view.PackageID = _packageRepository.GetNextCustomId<Packages>();
            view.PackageWeight = 0;
            view.PackageWidth = 0;
            view.PackageLength= 0;
            view.PackageHeight = 0;
            view.PackageStatus = string.Empty;
            view.Dest_address=string.Empty;
            view.ContentDes=string.Empty;
            view.Deadline= DateTime.Now;
        }

        private async void searchPackage(object? sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(view.searchPackage))
            {
                await LoadPackages(); // Show default results
                return;
            }

            try
            {
                var foundRow = await _searchManager.SearchByValueAsync(view.searchPackage);


                if (foundRow == null)
                {
                    MessageBox.Show("No matching results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create a temporary DataTable to show just the found row
                DataTable resultTable = foundRow.Table.Clone(); // clone schema
                resultTable.ImportRow(foundRow);

                _packageBindingSource.DataSource = resultTable.DefaultView;
                _packageBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        // method to sort
        private async Task OnSortByDeadline()
        {
            var sortedPackages = await _sortManager.SortPackagesByDeadlineAsync();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = sortedPackages;

            view.SetPackageListBindingSource(bindingSource);
        }


    }
}
