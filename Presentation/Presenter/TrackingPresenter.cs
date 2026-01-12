using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postal_Management_System.Core.Services;
using Postal_Management_System.Presentation.views;
using Postal_Management_System.Core.Data;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using System.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Postal_Management_System.Presentation.Presenter
{
    public class TrackingPresenter
    {
        private readonly ITrackingView _view;
        private readonly IStoreRepository<Tracking> _TrackingRepository;
        private readonly IStoreRepository<Packages> _packageRepository;
        private readonly SearchManager<Tracking> searchManager;
        private readonly BindingSource _trackingBindingSource = new();

        private int _currentPage = 1;
        private int _pageSize = 10;
        private int _totalPages = 1;

        public TrackingPresenter(ITrackingView view, IStoreRepository<Tracking> trackingRepository, IStoreRepository<Packages> packageRepository, SearchManager<Tracking> searchManager)
        {
            _view = view;
            _TrackingRepository = trackingRepository;
            _packageRepository = packageRepository;
            this.searchManager = searchManager;

            _view.PreviousPageClicked += async (s, e) =>
            {
                if (_currentPage > 1)
                {
                    _currentPage--;
                    await LoadTrackingAsync();
                }
            };

            _view.NextPageClicked += async (s, e) =>
            {
                if (_currentPage < _totalPages)
                {
                    _currentPage++;
                    await LoadTrackingAsync();
                }
            };
            _view.SaveTracking += async (s,e)=> await SaveTrackingAsync();
            _view.Bill += async (s, e) => await BillTrackingAsync();
            _view.cancelEvent += async (s, e) => await CancelTrackingAsync();
            _view.SearchEvent += async (s, e) => await SearchTrackingAsync();


            _view.SetTrackingListBindingSource(_trackingBindingSource);
            ((Form)_view).Load += async (s, e) => await LoadTrackingAsync();
        }

        private async Task SearchTrackingAsync()
        {
            var result = await searchManager.SearchByValueAsync(_view.searchTracking);
            if (result != null)
            {
                var found = new Tracking
                {
                    TrackingID = result["TrackingID"]?.ToString(),
                    CustomBill = int.TryParse(result["CustomBill"]?.ToString(), out int customBill) ? customBill : 0,
                    declared = result["declared"]?.ToString(),
                    PaymentStatus = result["PaymentStatus"]?.ToString(),
                    BilledOn = DateTime.TryParse(result["BilledOn"]?.ToString(), out DateTime billedOn) ? billedOn : DateTime.MinValue,

                };

                _trackingBindingSource.DataSource = new List<Tracking> { found };
                _view.Message = "Search successful.";
            }
            else
            {
                _view.Message = "No match found.";
            }
        }

        private async Task CancelTrackingAsync()
        {
            _view.TrackingID = string.Empty;
            _view.PackageID =string.Empty;
            _view.CustomBill = 0;
            _view.declared = string.Empty;
            _view.PaymentStatus = string.Empty;
            _view.BilledOn = DateTime.UtcNow;
        }

        private async Task SaveTrackingAsync()
        {
            try
            {
                var existing = await _TrackingRepository.GetByValueAsync(_view.PackageID);

                if (existing != null)
                {
                    // Update existing tracking
                    existing.declared = _view.declared;
                    existing.CustomBill = _view.CustomBill;
                    existing.PaymentStatus = _view.PaymentStatus;
                    existing.BilledOn = _view.BilledOn ?? DateTime.UtcNow;

                    await _TrackingRepository.UpdateAsync(existing);
                    _view.Message = "Tracking updated successfully.";
                }
                else
                {
                    // Create new tracking entry
                    var newTracking = new Tracking
                    {
                        TrackingID = _TrackingRepository.GetNextCustomId<Tracking>(),
                        PackageID = _view.PackageID,
                        declared = _view.declared,
                        CustomBill = _view.CustomBill,
                        PaymentStatus = _view.PaymentStatus,
                        BilledOn = _view.BilledOn ?? DateTime.UtcNow
                        // optionally: custID, EmployeeID
                    };

                    await _TrackingRepository.AddAsync(newTracking);
                    _view.Message = "New tracking created successfully.";
                }

                _view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                _view.Message = $"Error saving tracking: {ex.Message}";
                _view.IsSuccessful = false;
            }

        }

        private async Task BillTrackingAsync()
        {
            if (_trackingBindingSource.Current is Tracking selected)
            {
                _view.TrackingID = selected.TrackingID;
                _view.PackageID = selected.PackageID;
                _view.CustomBill = selected.CustomBill;
                _view.declared = selected.declared;
                _view.PaymentStatus = selected.PaymentStatus;
                _view.BilledOn = selected.BilledOn ?? DateTime.UtcNow;

                _view.Message = "Tracking record loaded. You can now update the fields.";
                _view.IsSuccessful = true;
            }
            else
            {
                _view.Message = "No tracking record selected.";
                _view.IsSuccessful = false;
            }
        }

        public async Task LoadTrackingAsync()
        {
            var data = await _TrackingRepository.GetDataTableAsync(_currentPage, _pageSize);
            var list = new List<Tracking>();

            foreach (DataRow row in data.Rows)
            {
                list.Add(new Tracking
                {
                    TrackingID = row["TrackingID"]?.ToString(),
                    CustomBill = int.TryParse(row["CustomBill"]?.ToString(), out int customBill) ? customBill : 0,
                    declared = row["declared"]?.ToString(),
                    PaymentStatus = row["PaymentStatus"]?.ToString(),
                    BilledOn = DateTime.TryParse(row["BilledOn"]?.ToString(), out DateTime billedOn) ? billedOn : DateTime.MinValue,
                    
                });
            }

            _trackingBindingSource.DataSource = list;

            int totalCount = await _TrackingRepository.GetTotalCountAsync();
            _totalPages = (int)Math.Ceiling((double)totalCount / _pageSize);
            _view.UpdatePageLabel($"Page {_currentPage} of {_totalPages}");
        }
    }
}
