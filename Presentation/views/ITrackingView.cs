using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postal_Management_System.Presentation.views
{
    public interface ITrackingView
    {
        //form fields
        public string TrackingID { get; set; }
        public string PackageID { get; set; }
        public int CustomBill { get; set; }
        public string declared { get; set; }

        public string PaymentStatus { get; set; } 
        public DateTime? BilledOn { get; set; }

        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string searchTracking { set; get; }

        //events
        event EventHandler SaveTracking;
        event EventHandler SearchEvent;
        event EventHandler Bill;
        event EventHandler cancelEvent;
        event EventHandler PreviousPageClicked;
        event EventHandler NextPageClicked;
       

        //methods
        void SetTrackingListBindingSource(BindingSource packageSource);
        void UpdatePageLabel(string text);

    }
}
