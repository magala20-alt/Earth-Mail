using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postal_Management_System.Presentation.views
{
    public interface IPackageView
    {

        // Package details
        string PackageID { get; set; }
        string PackageStatus { get; set; }
        int PackageWeight { get; set; }
        int PackageLength { get; set; }
        int PackageWidth { get; set; }
        int PackageHeight { get; set; }
        string Dest_address { get; set; }
        string ContentDes { get; set; }
        DateTime Deadline { get; set; }
        string TrackingID { get; set; }
        //string CustID { get; set; }

        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string searchPackage { set; get; }

        //events
        event EventHandler SortByDeadline;
        event EventHandler SavePackage;
        event EventHandler SearchEvent;
        event EventHandler AddNewPackage;
        event EventHandler DeletePackage;
        event EventHandler EditPackage;
        event EventHandler cancelEvent;
        event EventHandler PreviousPageClicked;
        event EventHandler NextPageClicked;
        event EventHandler ImportClicked;
        event EventHandler ExportClicked;

        //methods
        void SetPackageListBindingSource(BindingSource packageSource);
    }
}
