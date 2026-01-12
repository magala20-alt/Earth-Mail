using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postal_Management_System.Presentation.views
{
    public interface IAdminView
    {
        event EventHandler ShowEmployeeView;
        event EventHandler ShowCustomerView;
        event EventHandler ShowPackageView;
        event EventHandler ShowTrackingView;
        event EventHandler Logout;
        event EventHandler ShowDashboardView;
    }
}
