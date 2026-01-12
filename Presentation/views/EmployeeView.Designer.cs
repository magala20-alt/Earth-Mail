namespace Postal_Management_System.views
{
    partial class EmployeeView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;

        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.DataGridView employeeDataGridView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage empView;
        private System.Windows.Forms.TabPage empDets;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            txtEmployeeID = new System.Windows.Forms.TextBox();
            txtFirstname = new System.Windows.Forms.TextBox();
            txtLastname = new System.Windows.Forms.TextBox();
            txtRole = new System.Windows.Forms.TextBox();
            txtSearch = new System.Windows.Forms.TextBox();

            btnAdd = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            btnImport = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnPrev = new System.Windows.Forms.Button();

            lblPage = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();

            employeeDataGridView = new System.Windows.Forms.DataGridView();
            tabControl1 = new System.Windows.Forms.TabControl();
            empView = new System.Windows.Forms.TabPage();
            empDets = new System.Windows.Forms.TabPage();

            ((System.ComponentModel.ISupportInitialize)(employeeDataGridView)).BeginInit();
            tabControl1.SuspendLayout();
            empView.SuspendLayout();
            empDets.SuspendLayout();
            SuspendLayout();

            // txtEmployeeID
            txtEmployeeID.Location = new System.Drawing.Point(160, 20);
            txtEmployeeID.Size = new System.Drawing.Size(200, 27);

            // txtFirstname
            txtFirstname.Location = new System.Drawing.Point(160, 60);
            txtFirstname.Size = new System.Drawing.Size(200, 27);

            // txtLastname
            txtLastname.Location = new System.Drawing.Point(160, 100);
            txtLastname.Size = new System.Drawing.Size(200, 27);

            // txtRole
            txtRole.Location = new System.Drawing.Point(160, 140);
            txtRole.Size = new System.Drawing.Size(200, 27);

            // txtSearch
            txtSearch.Location = new System.Drawing.Point(20, 20);
            txtSearch.Size = new System.Drawing.Size(400, 27);

            // Labels
            label1.Text = "Employee ID:";
            label1.Location = new System.Drawing.Point(30, 23);
            label2.Text = "First Name:";
            label2.Location = new System.Drawing.Point(30, 63);
            label3.Text = "Last Name:";
            label3.Location = new System.Drawing.Point(30, 103);
            label4.Text = "Role:";
            label4.Location = new System.Drawing.Point(30, 143);
            label5.Text = "Employee Management";
            label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(20, 60);
            label5.Size = new System.Drawing.Size(300, 30);

            // Buttons
            btnSearch.Text = "Search";
            btnSearch.Location = new System.Drawing.Point(430, 17);
            btnSearch.Size = new System.Drawing.Size(80, 30);

            btnAdd.Text = "Add";
            btnAdd.Location = new System.Drawing.Point(620, 30);
            btnAdd.Size = new System.Drawing.Size(100, 30);

            btnEdit.Text = "Edit";
            btnEdit.Location = new System.Drawing.Point(620, 70);
            btnEdit.Size = new System.Drawing.Size(100, 30);

            btnDelete.Text = "Delete";
            btnDelete.Location = new System.Drawing.Point(620, 110);
            btnDelete.Size = new System.Drawing.Size(100, 30);

            btnImport.Text = "Import";
            btnImport.Location = new System.Drawing.Point(20, 460);
            btnImport.Size = new System.Drawing.Size(100, 30);

            btnExport.Text = "Export";
            btnExport.Location = new System.Drawing.Point(130, 460);
            btnExport.Size = new System.Drawing.Size(100, 30);

            btnSave.Text = "Save";
            btnSave.Location = new System.Drawing.Point(160, 200);
            btnSave.Size = new System.Drawing.Size(100, 30);

            btnCancel.Text = "Cancel";
            btnCancel.Location = new System.Drawing.Point(280, 200);
            btnCancel.Size = new System.Drawing.Size(100, 30);

            btnNext.Text = "Next";
            btnNext.Location = new System.Drawing.Point(680, 460);
            btnNext.Size = new System.Drawing.Size(80, 30);

            btnPrev.Text = "Prev";
            btnPrev.Location = new System.Drawing.Point(580, 460);
            btnPrev.Size = new System.Drawing.Size(80, 30);

            // lblPage
            lblPage.Text = "Page 1 of N";
            lblPage.Location = new System.Drawing.Point(300, 460);
            lblPage.Size = new System.Drawing.Size(200, 30);

            // DataGridView
            employeeDataGridView.Location = new System.Drawing.Point(20, 70);
            employeeDataGridView.Size = new System.Drawing.Size(540, 280);
            employeeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // empView tab
            empView.Text = "Employee List";
            empView.Controls.Add(employeeDataGridView);
            empView.Controls.Add(btnAdd);
            empView.Controls.Add(btnEdit);
            empView.Controls.Add(btnDelete);

            // empDets tab
            empDets.Text = "Employee Details";
            empDets.Controls.Add(label1);
            empDets.Controls.Add(label2);
            empDets.Controls.Add(label3);
            empDets.Controls.Add(label4);
            empDets.Controls.Add(txtEmployeeID);
            empDets.Controls.Add(txtFirstname);
            empDets.Controls.Add(txtLastname);
            empDets.Controls.Add(txtRole);
            empDets.Controls.Add(btnSave);
            empDets.Controls.Add(btnCancel);

            // tabControl1
            tabControl1.Controls.Add(empView);
            tabControl1.Controls.Add(empDets);
            tabControl1.Location = new System.Drawing.Point(20, 100);
            tabControl1.Size = new System.Drawing.Size(750, 340);

            // EmployeeView Form
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(label5);
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(tabControl1);
            this.Controls.Add(btnImport);
            this.Controls.Add(btnExport);
            this.Controls.Add(btnPrev);
            this.Controls.Add(btnNext);
            this.Controls.Add(lblPage);
            this.Name = "EmployeeView";
            this.Text = "Employee Management";

            ((System.ComponentModel.ISupportInitialize)(employeeDataGridView)).EndInit();
            tabControl1.ResumeLayout(false);
            empView.ResumeLayout(false);
            empDets.ResumeLayout(false);
            empDets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}



/*namespace Postal_Management_System.Presentation.views
{
    partial class EmployeeView
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
            components = new System.ComponentModel.Container();
            searchBox = new TextBox();
            label1 = new Label();
            addBtn = new Button();
            deleteBtn = new Button();
            editBtn = new Button();
            label2 = new Label();
            importBtn = new Button();
            exportBtn = new Button();
            tabControl1 = new TabControl();
            empView = new TabPage();
            employeeTbl = new DataGridView();
            empDetail = new TabPage();
            txtRole = new TextBox();
            label7 = new Label();
            cancelBtn = new Button();
            saveBtn = new Button();
            Lname = new TextBox();
            label6 = new Label();
            txtFirstname = new TextBox();
            label5 = new Label();
            txtEmployeeID = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            employeePresenterBindingSource = new BindingSource(components);
            searchBtn = new Button();
            lblPage = new Label();
            previousPageBtn = new Button();
            nextPageBtn = new Button();
            tabControl1.SuspendLayout();
            empView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeeTbl).BeginInit();
            empDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeePresenterBindingSource).BeginInit();
            SuspendLayout();
            // 
            // searchBox
            // 
            searchBox.Location = new Point(12, 12);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "Search";
            searchBox.Size = new Size(410, 27);
            searchBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(136, 26);
            label1.TabIndex = 1;
            label1.Text = "Employees";
            // 
            // addBtn
            // 
            addBtn.Location = new Point(780, 50);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(141, 37);
            addBtn.TabIndex = 3;
            addBtn.Text = "Add new";
            addBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(780, 179);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(141, 37);
            deleteBtn.TabIndex = 4;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(780, 113);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(141, 37);
            editBtn.TabIndex = 5;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cooper Black", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(163, 534);
            label2.Name = "label2";
            label2.Size = new Size(98, 17);
            label2.TabIndex = 6;
            label2.Text = "Table rows:";
            // 
            // importBtn
            // 
            importBtn.Location = new Point(593, 56);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(152, 37);
            importBtn.TabIndex = 7;
            importBtn.Text = "Import";
            importBtn.UseVisualStyleBackColor = true;
            // 
            // exportBtn
            // 
            exportBtn.Location = new Point(796, 56);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(141, 37);
            exportBtn.TabIndex = 8;
            exportBtn.Text = "Export";
            exportBtn.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(empView);
            tabControl1.Controls.Add(empDetail);
            tabControl1.Location = new Point(12, 99);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(954, 391);
            tabControl1.TabIndex = 9;
            // 
            // empView
            // 
            empView.Controls.Add(employeeTbl);
            empView.Controls.Add(addBtn);
            empView.Controls.Add(editBtn);
            empView.Controls.Add(deleteBtn);
            empView.Location = new Point(4, 29);
            empView.Name = "empView";
            empView.Padding = new Padding(3);
            empView.Size = new Size(946, 358);
            empView.TabIndex = 0;
            empView.Text = "EmployeeView";
            empView.UseVisualStyleBackColor = true;
            // 
            // employeeTbl
            // 
            employeeTbl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            employeeTbl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            employeeTbl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeeTbl.Location = new Point(3, 3);
            employeeTbl.Name = "employeeTbl";
            employeeTbl.RowHeadersWidth = 51;
            employeeTbl.Size = new Size(726, 352);
            employeeTbl.TabIndex = 0;
            // 
            // empDetail
            // 
            empDetail.Controls.Add(txtRole);
            empDetail.Controls.Add(label7);
            empDetail.Controls.Add(cancelBtn);
            empDetail.Controls.Add(saveBtn);
            empDetail.Controls.Add(Lname);
            empDetail.Controls.Add(label6);
            empDetail.Controls.Add(txtFirstname);
            empDetail.Controls.Add(label5);
            empDetail.Controls.Add(txtEmployeeID);
            empDetail.Controls.Add(label4);
            empDetail.Controls.Add(panel1);
            empDetail.Location = new Point(4, 29);
            empDetail.Name = "empDetail";
            empDetail.Padding = new Padding(3);
            empDetail.Size = new Size(946, 358);
            empDetail.TabIndex = 1;
            empDetail.Text = "EmployeeDetail";
            empDetail.UseVisualStyleBackColor = true;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(386, 186);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(269, 27);
            txtRole.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(275, 193);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 10;
            label7.Text = "Role";
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(312, 284);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 9;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(561, 297);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(94, 29);
            saveBtn.TabIndex = 8;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // Lname
            // 
            Lname.Location = new Point(386, 138);
            Lname.Name = "Lname";
            Lname.Size = new Size(269, 27);
            Lname.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(275, 141);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 6;
            label6.Text = "Last name";
            // 
            // txtFirstname
            // 
            txtFirstname.Location = new Point(386, 82);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(269, 27);
            txtFirstname.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(275, 82);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 4;
            label5.Text = "Firstname";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(386, 25);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(269, 27);
            txtEmployeeID.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(275, 27);
            label4.Name = "label4";
            label4.Size = new Size(90, 20);
            label4.TabIndex = 2;
            label4.Text = "EmployeeID";
            // 
            // panel1
            // 
            panel1.Location = new Point(29, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(196, 175);
            panel1.TabIndex = 0;
            // 
            // employeePresenterBindingSource
            // 
            employeePresenterBindingSource.DataSource = typeof(Presenter.EmployeePresenter);
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(428, 6);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(108, 38);
            searchBtn.TabIndex = 10;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(403, 504);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(50, 20);
            lblPage.TabIndex = 11;
            lblPage.Text = "label3";
            // 
            // previousPageBtn
            // 
            previousPageBtn.Location = new Point(492, 492);
            previousPageBtn.Name = "previousPageBtn";
            previousPageBtn.Size = new Size(94, 29);
            previousPageBtn.TabIndex = 13;
            previousPageBtn.Text = "Previous";
            previousPageBtn.UseVisualStyleBackColor = true;
            // 
            // nextPageBtn
            // 
            nextPageBtn.Location = new Point(651, 492);
            nextPageBtn.Name = "nextPageBtn";
            nextPageBtn.Size = new Size(94, 29);
            nextPageBtn.TabIndex = 14;
            nextPageBtn.Text = "next";
            nextPageBtn.UseVisualStyleBackColor = true;
            // 
            // EmployeeView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 560);
            Controls.Add(nextPageBtn);
            Controls.Add(previousPageBtn);
            Controls.Add(lblPage);
            Controls.Add(searchBtn);
            Controls.Add(label2);
            Controls.Add(tabControl1);
            Controls.Add(exportBtn);
            Controls.Add(importBtn);
            Controls.Add(label1);
            Controls.Add(searchBox);
            Name = "EmployeeView";
            Text = "EmployeeView";
            tabControl1.ResumeLayout(false);
            empView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)employeeTbl).EndInit();
            empDetail.ResumeLayout(false);
            empDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)employeePresenterBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchBox;
        private Label label1;
        private Button addBtn;
        private Button deleteBtn;
        private Button editBtn;
        private Label label2;
        private Button importBtn;
        private Button exportBtn;
        private TabControl tabControl1;
        private TabPage empView;
        private TabPage empDetail;
        private DataGridView employeeTbl;
        private TextBox txtRole;
        private Label label7;
        private Button cancelBtn;
        private Button saveBtn;
        private TextBox Lname;
        private Label label6;
        private TextBox txtFirstname;
        private Label label5;
        private TextBox txtEmployeeID;
        private Label label4;
        private Panel panel1;
        private Button searchBtn;
        private BindingSource employeePresenterBindingSource;
        private Label lblPage;
        private Button previousPageBtn;
        private Button nextPageBtn;
    }
}
*/