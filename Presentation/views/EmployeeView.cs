using Postal_Management_System.Core.Data;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Presentation.views;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Postal_Management_System.views
{
    public partial class EmployeeView : Form, IEmployeeView
    {
        public static EmployeeView instance;
        private ErrorProvider errorProvider;

        public EmployeeView()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(empDets);
        }

        public static EmployeeView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new EmployeeView();
                instance.MdiParent = parentContainer;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;

                instance.BringToFront();
            }
            return instance;
        }

    

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EmployeeID { get => txtEmployeeID.Text; set => txtEmployeeID.Text = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Firstname { get => txtFirstname.Text; set => txtFirstname.Text = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Lastname { get => txtLastname.Text; set => txtLastname.Text = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Role { get => txtRole.Text; set => txtRole.Text = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchedEmployee { get => txtSearch.Text; set => txtSearch.Text = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEdit { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message { get; set; }

        public event EventHandler SaveEmployee;
        public event EventHandler SearchEvent;
        public event EventHandler NextPageClicked;
        public event EventHandler PreviousPageClicked;
        public event EventHandler AddNewEmployee;
        public event EventHandler DeleteEmployee;
        public event EventHandler EditEmployee;
        public event EventHandler cancelEvent;
        public event EventHandler ImportClicked;
        public event EventHandler ExportClicked;

        public void SetEmployeeListBindingSource(BindingSource employeeList)
        {
            employeeDataGridView.DataSource = null;
            employeeDataGridView.AutoGenerateColumns = true;
            employeeDataGridView.DataSource = employeeList;
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            btnAdd.Click += delegate
            {
                tabControl1.TabPages.Remove(empView);
                tabControl1.TabPages.Add(empDets);
                using var context = new ApplicationDbContext();
                var repo = new StoreRepository<Employee>(context);
                txtEmployeeID.Text = repo.GetNextCustomId<Employee>();
                AddNewEmployee?.Invoke(this, EventArgs.Empty);
            };

            btnSave.Click += delegate
            {
                if (ValidateInputs())
                {
                    SaveEmployee?.Invoke(this, EventArgs.Empty);
                    if (IsSuccessful)
                    {
                        MessageBox.Show("Employee saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.TabPages.Remove(empDets);
                        tabControl1.TabPages.Add(empView);
                    }
                    else
                    {
                        MessageBox.Show("Error: " + Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            btnEdit.Click += delegate
            {
                EditEmployee?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(empView);
                tabControl1.TabPages.Add(empDets);
            };

            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Confirm deletion of this employee?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEmployee?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Employee deleted successfully");
                }
            };

            btnCancel.Click += delegate
            {
                tabControl1.TabPages.Remove(empDets);
                tabControl1.TabPages.Add(empView);
            };

            btnImport.Click += delegate { ImportClicked?.Invoke(this, EventArgs.Empty); };
            btnExport.Click += delegate { ExportClicked?.Invoke(this, EventArgs.Empty); };
            btnNext.Click += delegate { NextPageClicked?.Invoke(this, EventArgs.Empty); };
            btnPrev.Click += delegate { PreviousPageClicked?.Invoke(this, EventArgs.Empty); };

            txtFirstname.KeyPress += OnlyLetters_KeyPress;
            txtLastname.KeyPress += OnlyLetters_KeyPress;
            txtRole.Validating += Role_Validating;
        }

        private void OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.Handled)
            {
                errorProvider.SetError((Control)sender, "Only alphabetic characters allowed.");
            }
            else
            {
                errorProvider.SetError((Control)sender, "");
            }
        }

        private void Role_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRole.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtRole, "Role cannot be empty.");
            }
            else
            {
                errorProvider.SetError(txtRole, "");
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (!Regex.IsMatch(txtFirstname.Text, @"^[A-Za-z]+$"))
            {
                errorProvider.SetError(txtFirstname, "First name should contain only letters.");
                isValid = false;
            }
            if (!Regex.IsMatch(txtLastname.Text, @"^[A-Za-z]+$"))
            {
                errorProvider.SetError(txtLastname, "Last name should contain only letters.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtRole.Text))
            {
                errorProvider.SetError(txtRole, "Role is required.");
                isValid = false;
            }

            return isValid;
        }
    }
}

