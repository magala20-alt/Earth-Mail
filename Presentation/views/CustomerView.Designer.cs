namespace Postal_Management_System.views
{
    partial class CustomerView
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCustomerAddress;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;

        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.RichTextBox searchBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage custView;
        private System.Windows.Forms.TabPage custDets;
        private System.Windows.Forms.DataGridView customerDataGridView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Instantiate controls
            txtCustomerID = new System.Windows.Forms.TextBox();
            txtFirstname = new System.Windows.Forms.TextBox();
            txtLastname = new System.Windows.Forms.TextBox();
            txtCustomerEmail = new System.Windows.Forms.TextBox();
            txtCustomerPhone = new System.Windows.Forms.TextBox();
            txtAddress = new System.Windows.Forms.TextBox();
            txtCustomerAddress = new System.Windows.Forms.TextBox(); // Possibly unused
            btnSearch = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            btnImport = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnPrev = new System.Windows.Forms.Button();
            lblPage = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            searchBox = new System.Windows.Forms.RichTextBox();
            tabControl1 = new System.Windows.Forms.TabControl();
            custView = new System.Windows.Forms.TabPage();
            custDets = new System.Windows.Forms.TabPage();
            customerDataGridView = new System.Windows.Forms.DataGridView();

            // CustomerView properties
            this.ClientSize = new System.Drawing.Size(852, 525);
            this.Controls.Add(label5);
            this.Controls.Add(searchBox);
            this.Controls.Add(tabControl1);
            this.Controls.Add(txtCustomerAddress);
            this.Controls.Add(btnSearch);
            this.Controls.Add(btnImport);
            this.Controls.Add(btnNext);
            this.Controls.Add(btnPrev);
            this.Controls.Add(lblPage);
            this.Name = "CustomerView";
            this.Text = "Customer Management";

            // Label "Customers"
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Cooper Black", 13.8F);
            label5.Location = new System.Drawing.Point(30, 50);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(138, 26);
            label5.Text = "Customers";

            // Search Box
            searchBox.Location = new System.Drawing.Point(12, 12);
            searchBox.Name = "searchBox";
            searchBox.Size = new System.Drawing.Size(421, 35);
            searchBox.Text = "";

            // Search Button
            btnSearch.Location = new System.Drawing.Point(470, 17);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(90, 30);
            btnSearch.Text = "Search";

            // Page label
            lblPage.Location = new System.Drawing.Point(170, 479);
            lblPage.Name = "lblPage";
            lblPage.Size = new System.Drawing.Size(150, 20);
            lblPage.Text = "Page";

            // Navigation Buttons
            btnPrev.Location = new System.Drawing.Point(343, 474);
            btnPrev.Size = new System.Drawing.Size(90, 30);
            btnPrev.Text = "Previous";

            btnNext.Location = new System.Drawing.Point(486, 474);
            btnNext.Size = new System.Drawing.Size(90, 30);
            btnNext.Text = "Next";

            // Import
            btnImport.Location = new System.Drawing.Point(586, 59);
            btnImport.Size = new System.Drawing.Size(177, 39);
            btnImport.Text = "Import";

            // Tab Control
            tabControl1.Controls.Add(custView);
            tabControl1.Controls.Add(custDets);
            tabControl1.Location = new System.Drawing.Point(30, 104);
            tabControl1.Size = new System.Drawing.Size(778, 356);

            // View Tab
            custView.Controls.Add(customerDataGridView);
            custView.Controls.Add(btnAdd);
            custView.Controls.Add(btnEdit);
            custView.Controls.Add(btnDelete);
            custView.Text = "Customer View";

            // DataGridView
            customerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customerDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            customerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerDataGridView.Location = new System.Drawing.Point(0, 3);
            customerDataGridView.Size = new System.Drawing.Size(567, 320);

            // View Buttons
            btnAdd.Location = new System.Drawing.Point(593, 35);
            btnAdd.Size = new System.Drawing.Size(157, 38);
            btnAdd.Text = "Add";

            btnEdit.Location = new System.Drawing.Point(593, 97);
            btnEdit.Size = new System.Drawing.Size(157, 39);
            btnEdit.Text = "Edit";

            btnDelete.Location = new System.Drawing.Point(593, 161);
            btnDelete.Size = new System.Drawing.Size(157, 39);
            btnDelete.Text = "Delete";

            // Details Tab
            custDets.Controls.Add(txtCustomerID);
            custDets.Controls.Add(txtFirstname);
            custDets.Controls.Add(txtLastname);
            custDets.Controls.Add(txtCustomerEmail);
            custDets.Controls.Add(txtCustomerPhone);
            custDets.Controls.Add(txtAddress);
            custDets.Controls.Add(label1);
            custDets.Controls.Add(label2);
            custDets.Controls.Add(label6);
            custDets.Controls.Add(label3);
            custDets.Controls.Add(label4);
            custDets.Controls.Add(label7);
            custDets.Controls.Add(btnSave);
            custDets.Controls.Add(btnCancel);

            custDets.Text = "Customer Details";

            // Input Labels
            label1.Text = "Customer ID"; label1.Location = new System.Drawing.Point(30, 28);
            label2.Text = "First name"; label2.Location = new System.Drawing.Point(30, 75);
            label6.Text = "Last name"; label6.Location = new System.Drawing.Point(30, 128);
            label3.Text = "Email"; label3.Location = new System.Drawing.Point(30, 185);
            label4.Text = "Phone Number"; label4.Location = new System.Drawing.Point(30, 245);
            label7.Text = "Address"; label7.Location = new System.Drawing.Point(411, 28);

            // Input Fields
            txtCustomerID.Location = new System.Drawing.Point(169, 28); txtCustomerID.Size = new System.Drawing.Size(117, 27);
            txtFirstname.Location = new System.Drawing.Point(169, 75); txtFirstname.Size = new System.Drawing.Size(250, 27);
            txtLastname.Location = new System.Drawing.Point(169, 128); txtLastname.Size = new System.Drawing.Size(250, 27);
            txtCustomerEmail.Location = new System.Drawing.Point(169, 185); txtCustomerEmail.Size = new System.Drawing.Size(250, 27);
            txtCustomerPhone.Location = new System.Drawing.Point(169, 245); txtCustomerPhone.Size = new System.Drawing.Size(250, 27);
            txtAddress.Location = new System.Drawing.Point(514, 21); txtAddress.Size = new System.Drawing.Size(250, 27);

            // Save & Cancel Buttons
            btnSave.Location = new System.Drawing.Point(656, 131); btnSave.Text = "Save";
            btnCancel.Location = new System.Drawing.Point(494, 131); btnCancel.Text = "Cancel";

            tabControl1.ResumeLayout(false);
            custView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customerDataGridView).EndInit();
            custDets.ResumeLayout(false);
            custDets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
