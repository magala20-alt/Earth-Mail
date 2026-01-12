
/*
using Postal_Management_System.Core.Data;
using Postal_Management_System.Presentation.views;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Postal_Management_System.views
{
    public partial class CustomerView : Form, ICustomerView
    {
        public static CustomerView instance;

        public CustomerView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(custDets);
        }

        public static CustomerView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CustomerView();
                instance.MdiParent = parentContainer;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Normal;
                    instance.BringToFront();
                }
            }
            return instance;
        }

        // Interface Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerID
        {
            get => txtCustomerID.Text;
            set => txtCustomerID.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerFirstname
        {
            get => txtFirstname.Text;
            set => txtFirstname.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerLastname
        {
            get => txtLastname.Text;
            set => txtLastname.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerEmail
        {
            get => txtCustomerEmail.Text;
            set => txtCustomerEmail.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerPhone
        {
            get => txtCustomerPhone.Text;
            set => txtCustomerPhone.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerAddress
        {
            get => txtAddress.Text;
            set => txtAddress.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerName
        {
            get => $"{CustomerFirstname} {CustomerLastname}";
            set
            {
                var parts = value.Split(' ');
                CustomerFirstname = parts[0];
                CustomerLastname = parts.Length > 1 ? parts[1] : "";
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Searchtext
        {
            get => searchBox.Text;
            set => searchBox.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEdit { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message { get; set; }

        // Event declarations
        public event EventHandler SearchCustomer;
        public event EventHandler AddNewCustomer;
        public event EventHandler SaveCustomer;
        public event EventHandler DeleteCustomer;
        public event EventHandler EditCustomer;
        public event EventHandler CancelEvent;
        public event EventHandler ImportClicked;
        public event EventHandler PreviousPageClicked;
        public event EventHandler NextPageClicked;

        public void SetCustomerListBindingSource(BindingSource customerList)
        {
            customerDataGridView.DataSource = null;
            customerDataGridView.AutoGenerateColumns = true;
            customerDataGridView.DataSource = customerList;
            Console.WriteLine("BindingSource set to DataGridView");
        }

        public void UpdatePageLabel(string labelText)
        {
            lblPage.Text = labelText;
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchCustomer?.Invoke(this, EventArgs.Empty); };
            btnAdd.Click += delegate
            {
                tabControl1.TabPages.Remove(custView);
                tabControl1.TabPages.Add(custDets);

                using var context = new ApplicationDbContext();
                var repo = new StoreRepository<Customers>(context);
                string nextId = repo.GetNextCustomId<Customers>();

                txtCustomerID.ReadOnly = true;
                txtCustomerID.Text = nextId;

                AddNewCustomer?.Invoke(this, EventArgs.Empty);
            };

            btnSave.Click += delegate
            {
                if (ValidateInputs())
                {
                    SaveCustomer?.Invoke(this, EventArgs.Empty);
                    if (IsSuccessful)
                    {
                        MessageBox.Show("Customer saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.TabPages.Remove(custDets);
                        tabControl1.TabPages.Add(custView);
                    }
                    else
                    {
                        MessageBox.Show("Error: " + Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            btnEdit.Click += delegate
            {
                EditCustomer?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(custView);
                tabControl1.TabPages.Add(custDets);
            };

            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to permanently delete Customer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Customer Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            btnCancel.Click += delegate
            {
                tabControl1.TabPages.Remove(custDets);
                tabControl1.TabPages.Add(custView);
                CancelEvent?.Invoke(this, EventArgs.Empty);
            };

            btnImport.Click += delegate { ImportClicked?.Invoke(this, EventArgs.Empty); };
            btnPrev.Click += delegate { PreviousPageClicked?.Invoke(this, EventArgs.Empty); };
            btnNext.Click += delegate { NextPageClicked?.Invoke(this, EventArgs.Empty); };

            // Input field validation
            txtFirstname.KeyPress += LettersOnly_KeyPress;
            txtLastname.KeyPress += LettersOnly_KeyPress;
            txtCustomerPhone.KeyPress += NumbersOnly_KeyPress;
            txtCustomerEmail.Validating += Email_Validating;
            txtCustomerPhone.Validating += Phone_Validating;
        }

        private void LettersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void NumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Email_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            if (!Regex.IsMatch(txtCustomerEmail.Text, pattern))
            {
                e.Cancel = true;
                errorProvider.SetError(txtCustomerEmail, "Email must be a valid Gmail address.");
            }
            else
            {
                errorProvider.SetError(txtCustomerEmail, "");
            }
        }

        private void Phone_Validating(object sender, CancelEventArgs e)
        {
            if (txtCustomerPhone.Text.Length < 10 || !Regex.IsMatch(txtCustomerPhone.Text, @"^\d+$"))
            {
                e.Cancel = true;
                errorProvider.SetError(txtCustomerPhone, "Phone number must be numeric and at least 10 digits.");
            }
            else
            {
                errorProvider.SetError(txtCustomerPhone, "");
            }
        }

        private bool ValidateInputs()
        {
            bool valid = true;

            if (!Regex.IsMatch(txtCustomerEmail.Text, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
            {
                errorProvider.SetError(txtCustomerEmail, "Enter a valid Gmail.");
                valid = false;
            }

            if (txtCustomerPhone.Text.Length < 10 || !Regex.IsMatch(txtCustomerPhone.Text, @"^\d+$"))
            {
                errorProvider.SetError(txtCustomerPhone, "Phone number must be numeric and at least 10 digits.");
                valid = false;
            }

            if (!Regex.IsMatch(txtFirstname.Text, @"^[A-Za-z]+$"))
            {
                errorProvider.SetError(txtFirstname, "Firstname must contain only letters.");
                valid = false;
            }

            if (!Regex.IsMatch(txtLastname.Text, @"^[A-Za-z]+$"))
            {
                errorProvider.SetError(txtLastname, "Lastname must contain only letters.");
                valid = false;
            }

            return valid;
        }
    }
}
*/

using Postal_Management_System.Core.Data;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Presentation.views;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Postal_Management_System.views
{
    public partial class CustomerView : Form, ICustomerView
    {
        public static CustomerView instance;
        private readonly ErrorProvider errorProvider;

        public CustomerView()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(custDets);
        }

        public static CustomerView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CustomerView();
                instance.MdiParent = parentContainer;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Normal;
                    instance.BringToFront();
                }
            }
            return instance;
        }

        // Interface Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerID
        {
            get => txtCustomerID.Text;
            set => txtCustomerID.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerFirstname
        {
            get => txtFirstname.Text;
            set => txtFirstname.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerLastname
        {
            get => txtLastname.Text;
            set => txtLastname.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerEmail
        {
            get => txtCustomerEmail.Text;
            set => txtCustomerEmail.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerPhone
        {
            get => txtCustomerPhone.Text;
            set => txtCustomerPhone.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerAddress
        {
            get => txtAddress.Text;
            set => txtAddress.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerName
        {
            get => $"{CustomerFirstname} {CustomerLastname}";
            set
            {
                var parts = value.Split(' ');
                CustomerFirstname = parts[0];
                CustomerLastname = parts.Length > 1 ? parts[1] : string.Empty;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Searchtext
        {
            get => searchBox.Text;
            set => searchBox.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEdit { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message { get; set; }

        // Events
        public event EventHandler SearchCustomer;
        public event EventHandler AddNewCustomer;
        public event EventHandler SaveCustomer;
        public event EventHandler DeleteCustomer;
        public event EventHandler EditCustomer;
        public event EventHandler CancelEvent;
        public event EventHandler ImportClicked;
        public event EventHandler PreviousPageClicked;
        public event EventHandler NextPageClicked;

        public void SetCustomerListBindingSource(BindingSource customerList)
        {
            customerDataGridView.DataSource = null;
            customerDataGridView.AutoGenerateColumns = true;
            customerDataGridView.DataSource = customerList;
        }

        public void UpdatePageLabel(string labelText)
        {
            lblPage.Text = labelText;
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += (s, e) => SearchCustomer?.Invoke(this, EventArgs.Empty);
            btnAdd.Click += (s, e) =>
            {
                tabControl1.TabPages.Remove(custView);
                tabControl1.TabPages.Add(custDets);

                using var context = new ApplicationDbContext();
                var repo = new StoreRepository<Customers>(context);
                string nextId = repo.GetNextCustomId<Customers>();

                txtCustomerID.ReadOnly = true;
                txtCustomerID.Text = nextId;

                AddNewCustomer?.Invoke(this, EventArgs.Empty);
            };

            btnSave.Click += (s, e) =>
            {
                if (ValidateInputs())
                {
                    SaveCustomer?.Invoke(this, EventArgs.Empty);
                    if (IsSuccessful)
                    {
                        MessageBox.Show("Customer saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.TabPages.Remove(custDets);
                        tabControl1.TabPages.Add(custView);
                    }
                    else
                    {
                        MessageBox.Show("Error: " + Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            btnEdit.Click += (s, e) =>
            {
                EditCustomer?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(custView);
                tabControl1.TabPages.Add(custDets);
            };

            btnDelete.Click += (s, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to permanently delete the customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Customer deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            btnCancel.Click += (s, e) =>
            {
                tabControl1.TabPages.Remove(custDets);
                tabControl1.TabPages.Add(custView);
                CancelEvent?.Invoke(this, EventArgs.Empty);
            };

            btnImport.Click += (s, e) => ImportClicked?.Invoke(this, EventArgs.Empty);
            btnPrev.Click += (s, e) => PreviousPageClicked?.Invoke(this, EventArgs.Empty);
            btnNext.Click += (s, e) => NextPageClicked?.Invoke(this, EventArgs.Empty);

            // Validation events
            txtFirstname.KeyPress += LettersOnly_KeyPress;
            txtLastname.KeyPress += LettersOnly_KeyPress;
            txtCustomerPhone.KeyPress += NumbersOnly_KeyPress;
            txtCustomerEmail.Validating += Email_Validating;
            txtCustomerPhone.Validating += Phone_Validating;
        }

        private void LettersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                errorProvider.SetError((Control)sender, "Please enter letters only.");
                e.Handled = true;
            }
            else
            {
                errorProvider.SetError((Control)sender, "");
            }
        }

        private void NumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                errorProvider.SetError((Control)sender, "Only numeric digits are allowed.");
                e.Handled = true;
            }
            else
            {
                errorProvider.SetError((Control)sender, "");
            }
        }

        private void Email_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            if (!Regex.IsMatch(txtCustomerEmail.Text, pattern))
            {
                errorProvider.SetError(txtCustomerEmail, "Please enter a valid Gmail address.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCustomerEmail, "");
            }
        }

        private void Phone_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtCustomerPhone.Text, @"^\d{10,}$"))
            {
                errorProvider.SetError(txtCustomerPhone, "Phone number must be numeric and at least 10 digits.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCustomerPhone, "");
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (!Regex.IsMatch(txtCustomerEmail.Text, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
            {
                errorProvider.SetError(txtCustomerEmail, "Email must be a valid Gmail address.");
                isValid = false;
            }

            if (!Regex.IsMatch(txtCustomerPhone.Text, @"^\d{10,}$"))
            {
                errorProvider.SetError(txtCustomerPhone, "Phone number must be at least 10 digits.");
                isValid = false;
            }

            if (!Regex.IsMatch(txtFirstname.Text, @"^[A-Za-z]+$"))
            {
                errorProvider.SetError(txtFirstname, "First name must contain only letters.");
                isValid = false;
            }

            if (!Regex.IsMatch(txtLastname.Text, @"^[A-Za-z]+$"))
            {
                errorProvider.SetError(txtLastname, "Last name must contain only letters.");
                isValid = false;
            }

            return isValid;
        }
    }
}
