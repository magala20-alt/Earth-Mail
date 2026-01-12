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
    public partial class TransactConfigView : Form, ITrackingView
    {
        public TransactConfigView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            searchBtn.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); }; // to capture Search btn being pressed
            searchBtn.KeyDown += (s, e) =>  // to capture enter key being pressed
            {
                if (e.KeyData == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty); // invoke the search event
                }
            };//to capture the search Btn being pressed

            billBtn.Click += delegate {
                //tabControl1.TabPages.Remove(trackingtab1);
                //tabControl1.TabPages.Add(trackingtab2);
                Bill?.Invoke(this, EventArgs.Empty); 
            }; // to capture Bill btn being pressed

            cancelBtn.Click += delegate { 
                tabControl1.TabPages.Remove(trackingtab2);
                tabControl1.TabPages.Add(trackingtab1);
                cancelEvent?.Invoke(this, EventArgs.Empty); 
            }; // to capture cancel btn being pressed
            saveBtn.Click += delegate
            {
                SaveTracking?.Invoke(this, EventArgs.Empty);
                if (IsSuccessful)
                {
                    MessageBox.Show("Tracking saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to save tracking: " + Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnPrev.Click += delegate { PreviousPageClicked?.Invoke(this, EventArgs.Empty); };
            btnNext.Click += delegate { NextPageClicked?.Invoke(this, EventArgs.Empty); };
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TrackingID {
            get { return txtTrackingID.Text; }
            set { txtTrackingID.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CustomBill { 
            get { return int.Parse(txtBill.Text); }
            set { txtBill.Text = value.ToString(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PackageID
        {
            get { return txtpackageID.Text; }
            set { txtpackageID.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string declared { 
            get { return txtDeclared.Text; }
            set { txtDeclared.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PaymentStatus { 
            get { return txtStatus.Text; }
            set { txtStatus.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? BilledOn { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string searchTracking { 
            get { return txtSearch.Text; } 
            set {  txtSearch.Text = value; } 
        }
        

        public event EventHandler SaveTracking;
        public event EventHandler SearchEvent;
        public event EventHandler Bill;
        public event EventHandler cancelEvent;
        public event EventHandler PreviousPageClicked;
        public event EventHandler NextPageClicked;

        public void SetTrackingListBindingSource(BindingSource TrackingSource)
        {
            trackingTbl.DataSource = null;
            trackingTbl.AutoGenerateColumns = true;
            trackingTbl.DataSource = TrackingSource; // Binds the datasource to the data table
            Console.WriteLine("BindingSource set to DataGridView");
        }
        public void UpdatePageLabel(string labelText)
        {
            lblPage.Text = labelText;
        }


        //set the package view
        public static TransactConfigView instance;
        public static TransactConfigView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TransactConfigView();
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
