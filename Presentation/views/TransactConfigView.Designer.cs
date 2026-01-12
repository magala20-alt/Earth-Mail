namespace Postal_Management_System.Presentation.views
{
    partial class TransactConfigView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            trackingtab1 = new TabPage();
            billBtn = new Button();
            trackingTbl = new DataGridView();
            trackingtab2 = new TabPage();
            txtBill = new TextBox();
            txtCustomBill = new Label();
            txtTrackingID = new TextBox();
            label7 = new Label();
            dateBilledOn = new DateTimePicker();
            txtStatus = new ComboBox();
            cancelBtn = new Button();
            saveBtn = new Button();
            label6 = new Label();
            label3 = new Label();
            txtEmpID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtDeclared = new TextBox();
            label2 = new Label();
            txtpackageID = new TextBox();
            txtSearch = new TextBox();
            searchBtn = new Button();
            label1 = new Label();
            btnPrev = new Button();
            btnNext = new Button();
            lblPage = new Label();
            tabControl1.SuspendLayout();
            trackingtab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackingTbl).BeginInit();
            trackingtab2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(trackingtab1);
            tabControl1.Controls.Add(trackingtab2);
            tabControl1.Location = new Point(12, 94);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(760, 327);
            tabControl1.TabIndex = 0;
            // 
            // trackingtab1
            // 
            trackingtab1.Controls.Add(billBtn);
            trackingtab1.Controls.Add(trackingTbl);
            trackingtab1.Location = new Point(4, 29);
            trackingtab1.Name = "trackingtab1";
            trackingtab1.Padding = new Padding(3);
            trackingtab1.Size = new Size(752, 294);
            trackingtab1.TabIndex = 0;
            trackingtab1.Text = "Transactions";
            trackingtab1.UseVisualStyleBackColor = true;
            // 
            // billBtn
            // 
            billBtn.Location = new Point(619, 53);
            billBtn.Name = "billBtn";
            billBtn.Size = new Size(111, 43);
            billBtn.TabIndex = 1;
            billBtn.Text = "Bill";
            billBtn.UseVisualStyleBackColor = true;
            // 
            // trackingTbl
            // 
            trackingTbl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            trackingTbl.Location = new Point(0, 0);
            trackingTbl.Name = "trackingTbl";
            trackingTbl.RowHeadersWidth = 51;
            trackingTbl.Size = new Size(593, 291);
            trackingTbl.TabIndex = 0;
            // 
            // trackingtab2
            // 
            trackingtab2.Controls.Add(txtBill);
            trackingtab2.Controls.Add(txtCustomBill);
            trackingtab2.Controls.Add(txtTrackingID);
            trackingtab2.Controls.Add(label7);
            trackingtab2.Controls.Add(dateBilledOn);
            trackingtab2.Controls.Add(txtStatus);
            trackingtab2.Controls.Add(cancelBtn);
            trackingtab2.Controls.Add(saveBtn);
            trackingtab2.Controls.Add(label6);
            trackingtab2.Controls.Add(label3);
            trackingtab2.Controls.Add(txtEmpID);
            trackingtab2.Controls.Add(label5);
            trackingtab2.Controls.Add(label4);
            trackingtab2.Controls.Add(txtDeclared);
            trackingtab2.Controls.Add(label2);
            trackingtab2.Controls.Add(txtpackageID);
            trackingtab2.Location = new Point(4, 29);
            trackingtab2.Name = "trackingtab2";
            trackingtab2.Padding = new Padding(3);
            trackingtab2.Size = new Size(752, 294);
            trackingtab2.TabIndex = 1;
            trackingtab2.Text = "Billing";
            trackingtab2.UseVisualStyleBackColor = true;
            // 
            // txtBill
            // 
            txtBill.Location = new Point(144, 115);
            txtBill.Name = "txtBill";
            txtBill.Size = new Size(208, 27);
            txtBill.TabIndex = 19;
            // 
            // txtCustomBill
            // 
            txtCustomBill.AutoSize = true;
            txtCustomBill.Location = new Point(37, 115);
            txtCustomBill.Name = "txtCustomBill";
            txtCustomBill.Size = new Size(84, 20);
            txtCustomBill.TabIndex = 18;
            txtCustomBill.Text = "Custom Bill";
            // 
            // txtTrackingID
            // 
            txtTrackingID.Location = new Point(144, 21);
            txtTrackingID.Name = "txtTrackingID";
            txtTrackingID.Size = new Size(107, 27);
            txtTrackingID.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(37, 21);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 16;
            label7.Text = "Tracking ID";
            // 
            // dateBilledOn
            // 
            dateBilledOn.Location = new Point(144, 212);
            dateBilledOn.Name = "dateBilledOn";
            dateBilledOn.Size = new Size(235, 27);
            dateBilledOn.TabIndex = 15;
            // 
            // txtStatus
            // 
            txtStatus.FormattingEnabled = true;
            txtStatus.Items.AddRange(new object[] { "Paid", "Pending" });
            txtStatus.Location = new Point(540, 38);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(195, 28);
            txtStatus.TabIndex = 14;
            txtStatus.Text = "Pending";
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(235, 259);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 13;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(416, 259);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(94, 29);
            saveBtn.TabIndex = 12;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(416, 38);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 11;
            label6.Text = "Payment Status";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(416, 105);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 9;
            label3.Text = "Billed by";
            // 
            // txtEmpID
            // 
            txtEmpID.Location = new Point(538, 98);
            txtEmpID.Name = "txtEmpID";
            txtEmpID.Size = new Size(208, 27);
            txtEmpID.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 212);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 7;
            label5.Text = "Biiled On";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 159);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 6;
            label4.Text = "Declared";
            // 
            // txtDeclared
            // 
            txtDeclared.Location = new Point(144, 156);
            txtDeclared.Name = "txtDeclared";
            txtDeclared.Size = new Size(208, 27);
            txtDeclared.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 68);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 1;
            label2.Text = "PackageID";
            // 
            // txtpackageID
            // 
            txtpackageID.Location = new Point(144, 68);
            txtpackageID.Name = "txtpackageID";
            txtpackageID.Size = new Size(107, 27);
            txtpackageID.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search Package";
            txtSearch.Size = new Size(333, 27);
            txtSearch.TabIndex = 1;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(368, 12);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(94, 29);
            searchBtn.TabIndex = 2;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 56);
            label1.Name = "label1";
            label1.Size = new Size(232, 23);
            label1.TabIndex = 3;
            label1.Text = "Transaction Packages";
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(355, 427);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(94, 29);
            btnPrev.TabIndex = 4;
            btnPrev.Text = "Previous";
            btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(515, 427);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 5;
            btnNext.Text = "Next Page";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(136, 424);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(65, 20);
            lblPage.TabIndex = 6;
            lblPage.Text = "Page      ";
            // 
            // TransactConfigView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 478);
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(label1);
            Controls.Add(searchBtn);
            Controls.Add(txtSearch);
            Controls.Add(tabControl1);
            Name = "TransactConfigView";
            Text = "TransactConfigView";
            tabControl1.ResumeLayout(false);
            trackingtab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackingTbl).EndInit();
            trackingtab2.ResumeLayout(false);
            trackingtab2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage trackingtab1;
        private TabPage trackingtab2;
        private TextBox txtSearch;
        private Button searchBtn;
        private Label label1;
        private Button billBtn;
        private DataGridView trackingTbl;
        private Button btnPrev;
        private Button btnNext;
        private Label label2;
        private TextBox txtpackageID;
        private Label label5;
        private Label label4;
        private TextBox txtDeclared;
        private Label label3;
        private TextBox txtEmpID;
        private Button cancelBtn;
        private Button saveBtn;
        private Label label6;
        private ComboBox txtStatus;
        private DateTimePicker dateBilledOn;
        private TextBox txtTrackingID;
        private Label label7;
        private TextBox txtBill;
        private Label txtCustomBill;
        private Label lblPage;
    }
}