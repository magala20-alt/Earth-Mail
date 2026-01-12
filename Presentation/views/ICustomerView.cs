using System;
using System.Windows.Forms;

namespace Postal_Management_System.Presentation.views
{
    public interface ICustomerView
    {
        // Form Fields
        string CustomerID { get; set; }
        string CustomerFirstname { get; set; }
        string CustomerLastname { get; set; }
        string CustomerEmail { get; set; }
        string CustomerPhone { get; set; }
        string CustomerAddress { get; set; }

        // State Management
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string Searchtext { get; set; }

        // Paging
        void UpdatePageLabel(string text);

        // Data binding
        void SetCustomerListBindingSource(BindingSource customerList);

        // Events
        event EventHandler SearchCustomer;
        event EventHandler AddNewCustomer;
        event EventHandler SaveCustomer;
        event EventHandler DeleteCustomer;
        event EventHandler EditCustomer;
        event EventHandler CancelEvent;
        event EventHandler ImportClicked;
        event EventHandler NextPageClicked;
        event EventHandler PreviousPageClicked;
    }
}



/*using System;
using System.Windows.Forms;

namespace Postal_Management_System.Presentation.views
{
    public interface ICustomerView
    {
        // 🔍 Search & Pagination
        string SearchValue { get; }
        void UpdatePageLabel(int currentPage, int totalPages);
        event EventHandler SearchEvent;
        event EventHandler PreviousPageClicked;
        event EventHandler NextPageClicked;

        // ✨ Customer Properties
        string CustomerID { get; set; }
        string CustomerName { get; set; }    // Combines Firstname + Lastname
        string CustomerEmail { get; set; }
        string CustomerPhone { get; set; }
        string CustomerAddress { get; set; }

        // 📦 Data Binding
        void SetCustomerListBindingSource(BindingSource customerList);

        // ⚙️ CRUD Events
        event EventHandler AddNewCustomer;
        event EventHandler SaveCustomer;
        event EventHandler DeleteCustomer;
        event EventHandler EditCustomer;
        event EventHandler CancelEvent;

        // 📁 CSV Import/Export
        event EventHandler ImportClicked;
        event EventHandler ExportClicked;

        // 🧼 UI Feedback
        void ShowMessage(string message);
    }
}
*/