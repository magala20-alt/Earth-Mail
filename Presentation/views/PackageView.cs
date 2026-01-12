using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Postal_Management_System.Core.Data;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Core.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Postal_Management_System.Presentation.views
{
    public partial class PackageView : Form, IPackageView
    {
        public PackageView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(packageDet1);
            tabControl1.TabPages.Remove(packageDet2);
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Search Event
            searchBtn.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); }; // to capture Search btn being pressed
            searchBox.KeyDown += (s, e) =>  // to capture enter key being pressed
            {
                if (e.KeyData == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty); // invoke the search event
                }
            };
            //Import Event
            importBtn.Click += delegate { ImportClicked?.Invoke(this, EventArgs.Empty); };
            //Add Event
            addBtn.Click += delegate
            {
                tabControl1.TabPages.Remove(packagesTbl);
                tabControl1.TabPages.Remove(packageDet2);
                tabControl1.TabPages.Add(packageDet1);
                using (var context = new ApplicationDbContext())
                {
                    var repo = new StoreRepository<Packages>(context);
                    string nextId = repo.GetNextCustomId<Packages>();
                    MessageBox.Show("Generated ID: " + nextId);
                    txtpackageID.ReadOnly = true;
                    txtpackageID.Text = nextId;
                }
                AddNewPackage?.Invoke(this, EventArgs.Empty);
            };
            //Save Event
            saveBtn.Click += delegate
            {
                SavePackage?.Invoke(this, EventArgs.Empty);
                if (IsSuccessful)
                {
                    MessageBox.Show("Package saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.TabPages.Remove(packageDet1);
                    tabControl1.TabPages.Remove(packageDet2);
                    tabControl1.TabPages.Add(packagesTbl);
                }
                else
                {
                    MessageBox.Show("Error: " + Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            //Delete Event
            deleteBtn.Click += delegate
            {
                DeletePackage?.Invoke(this, EventArgs.Empty);
                if (IsSuccessful)
                {
                    MessageBox.Show("Package deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.TabPages.Remove(packageDet1);
                    tabControl1.TabPages.Add(packagesTbl);
                }
            };
            //Edit Event
            editBtn.Click += delegate
            {
                EditPackage?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(packagesTbl);
                tabControl1.TabPages.Add(packageDet1);
            };
            //Cancel Event
            cancelBtn.Click += delegate
            {
                
                tabControl1.TabPages.Remove(packageDet1);
                tabControl1.TabPages.Remove(packageDet2);
                tabControl1.TabPages.Add(packagesTbl);
            };
            //Prev button clicked
            previousBtn.Click += delegate { PreviousPageClicked?.Invoke(this, EventArgs.Empty); };
            //next button clicked
            nextBtn.Click += delegate { NextPageClicked?.Invoke(this, EventArgs.Empty); };
            //next det clicked
            nxtDet.Click += delegate
            {
                tabControl1.TabPages.Remove(packageDet1);
                tabControl1.TabPages.Add(packageDet2);
            };
            backbtn.Click += delegate
            {
                tabControl1.TabPages.Remove(packageDet2);
                tabControl1.TabPages.Add(packageDet1);
            };
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public string PackageID { 
            get { return txtpackageID.Text; }
            set { txtpackageID.Text = value; }  
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public string PackageStatus {
            get
            {
                if (IsPriority.Checked) return "Yes";
                if (rdoStandard.Checked) return "No";
                return string.Empty;
            }
            set
            {
                IsPriority.Checked = value == "Yes";
                rdoStandard.Checked = value == "No";
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public int PackageWeight { 
            get { return Convert.ToInt32(txtWeight.Text); }
            set { txtWeight.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public int PackageLength {
            get { return Convert.ToInt32(txtlength.Text); }
            set { txtlength.Text = value.ToString(); } 
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public int PackageWidth { 
            get { return Convert.ToInt32(txtWidth.Text); }
            set { txtWidth.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public int PackageHeight {
            get { return Convert.ToInt32(txtheight.Text); }
            set { txtheight.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public string Dest_address { 
            get { return txtDestination.Text; }
            set { txtDestination.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public string ContentDes { 
            get { return txtContent.Text; }
            set { txtContent.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public bool IsEdit { get; set;}
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public bool IsSuccessful  { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public string Message {  get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Prevents serialization
        public string searchPackage { 
            get { return searchPackage; }
            set {  searchPackage = value; } 
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Deadline {
            get => deadlinePicker.Value;
            set => deadlinePicker.Value = value;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TrackingID { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string CustID {
        //    get { return txtCustomer.Text; }
        //    set { txtCustomer.Text = value; } 
        //}

        //events
        public event EventHandler SavePackage;
        public event EventHandler SearchEvent;
        public event EventHandler AddNewPackage;
        public event EventHandler DeletePackage;
        public event EventHandler EditPackage;
        public event EventHandler cancelEvent;
        public event EventHandler PreviousPageClicked;
        public event EventHandler NextPageClicked;
        public event EventHandler ImportClicked;
        public event EventHandler ExportClicked;
        public event EventHandler SortByDeadline;

        //methods
        public void SetPackageListBindingSource(BindingSource packageSource)
        {
            packageTbl.DataSource= null;
            packageTbl.AutoGenerateColumns = true;
            packageTbl.DataSource = packageSource; // Binds the datasource to the data table
            Console.WriteLine("BindingSource set to DataGridView");
        }


        //set the package view
        public static PackageView instance;
        public static PackageView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PackageView();
                instance.MdiParent = parentContainer;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                {
                    instance.BringToFront();
                    instance.WindowState = FormWindowState.Normal;
                    instance.BringToFront();
                }
            }
            return instance;
        }
    }
}
