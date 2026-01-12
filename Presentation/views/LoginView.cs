using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postal_Management_System.Presentation.views
{
    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();

            passwordTxt.PasswordChar = '*'; // This makes the password show as asterisks

            AssociateAndRaiseViewEvents();
        }


        private void AssociateAndRaiseViewEvents()
        {
            loginBtn.Click += delegate { LoggedIn ?.Invoke(this, EventArgs.Empty); };
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void CloseLoginForm()
        {
            this.Close();
        }
        public void ShowLoginForm()
        {
            this.Show(); // This is the actual definition of ShowLoginForm
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public string username { 
            get { return usernameTxt.Text; }
            set {  usernameTxt.Text = value; } 
        }
      

        // Alternatively, you can use the system's default password character
        // passwordTxt.UseSystemPasswordChar = true;
    

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public string password {
            get { return passwordTxt.Text; }
            set {  passwordTxt.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public bool IsLoggedIn { 
            get { return IsLoggedIn; }
            set {  IsLoggedIn = value; }
        }

        public event EventHandler LoggedIn;
        public event EventHandler Logout;
        public event EventHandler ShowAdmin;
    }
}
