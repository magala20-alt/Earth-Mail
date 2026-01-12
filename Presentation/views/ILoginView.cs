using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postal_Management_System.Presentation.views
{
    public interface ILoginView
    {
        string username { get; set; }
        string password { get; set; }
        bool IsLoggedIn {  get; set; }
        void ShowMessage(string message);
        void CloseLoginForm();
        void ShowLoginForm();

        event EventHandler LoggedIn;
        event EventHandler Logout;
        event EventHandler ShowAdmin;


    }
}
