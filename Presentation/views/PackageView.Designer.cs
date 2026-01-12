namespace Postal_Management_System.Presentation.views
{
    partial class PackageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageView));
            searchBox = new TextBox();
            searchBtn = new Button();
            label1 = new Label();
            tabControl1 = new TabControl();
            packagesTbl = new TabPage();
            packageTbl = new DataGridView();
            editBtn = new Button();
            addBtn = new Button();
            deleteBtn = new Button();
            packageDet1 = new TabPage();
            nxtDet = new Button();
            txtpackageID = new RichTextBox();
            txtWeight = new RichTextBox();
            txtlength = new RichTextBox();
            txtWidth = new RichTextBox();
            txtheight = new RichTextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            packageDet2 = new TabPage();
            backbtn = new Button();
            deadlinePicker = new DateTimePicker();
            rdoStandard = new RadioButton();
            label11 = new Label();
            saveBtn = new Button();
            cancelBtn = new Button();
            IsPriority = new RadioButton();
            txtContent = new RichTextBox();
            txtDestination = new RichTextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            panel2 = new Panel();
            importBtn = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            previousBtn = new Button();
            nextBtn = new Button();
            label12 = new Label();
            txtCustomer = new TextBox();
            tabControl1.SuspendLayout();
            packagesTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)packageTbl).BeginInit();
            packageDet1.SuspendLayout();
            packageDet2.SuspendLayout();
            SuspendLayout();
            // 
            // searchBox
            // 
            searchBox.Location = new Point(12, 22);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(259, 27);
            searchBox.TabIndex = 0;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(277, 15);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(110, 41);
            searchBtn.TabIndex = 1;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 84);
            label1.Name = "label1";
            label1.Size = new Size(105, 23);
            label1.TabIndex = 2;
            label1.Text = "Packages";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(packagesTbl);
            tabControl1.Controls.Add(packageDet1);
            tabControl1.Controls.Add(packageDet2);
            tabControl1.Location = new Point(12, 122);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(966, 361);
            tabControl1.TabIndex = 3;
            // 
            // packagesTbl
            // 
            packagesTbl.Controls.Add(packageTbl);
            packagesTbl.Controls.Add(editBtn);
            packagesTbl.Controls.Add(addBtn);
            packagesTbl.Controls.Add(deleteBtn);
            packagesTbl.Location = new Point(4, 29);
            packagesTbl.Name = "packagesTbl";
            packagesTbl.Padding = new Padding(3);
            packagesTbl.Size = new Size(958, 328);
            packagesTbl.TabIndex = 0;
            packagesTbl.Text = "PackageView";
            packagesTbl.UseVisualStyleBackColor = true;
            // 
            // packageTbl
            // 
            packageTbl.AllowUserToAddRows = false;
            packageTbl.AllowUserToDeleteRows = false;
            packageTbl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            packageTbl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            packageTbl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            packageTbl.Location = new Point(-4, 0);
            packageTbl.Name = "packageTbl";
            packageTbl.ReadOnly = true;
            packageTbl.RowHeadersWidth = 51;
            packageTbl.Size = new Size(745, 328);
            packageTbl.TabIndex = 0;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(780, 79);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(146, 41);
            editBtn.TabIndex = 7;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(780, 32);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(146, 41);
            addBtn.TabIndex = 4;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(780, 126);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(146, 41);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // packageDet1
            // 
            packageDet1.Controls.Add(txtCustomer);
            packageDet1.Controls.Add(label12);
            packageDet1.Controls.Add(nxtDet);
            packageDet1.Controls.Add(txtpackageID);
            packageDet1.Controls.Add(txtWeight);
            packageDet1.Controls.Add(txtlength);
            packageDet1.Controls.Add(txtWidth);
            packageDet1.Controls.Add(txtheight);
            packageDet1.Controls.Add(label7);
            packageDet1.Controls.Add(label6);
            packageDet1.Controls.Add(label5);
            packageDet1.Controls.Add(label4);
            packageDet1.Controls.Add(label3);
            packageDet1.Controls.Add(panel1);
            packageDet1.Location = new Point(4, 29);
            packageDet1.Name = "packageDet1";
            packageDet1.Padding = new Padding(3);
            packageDet1.Size = new Size(958, 328);
            packageDet1.TabIndex = 1;
            packageDet1.Text = "packageDet1";
            packageDet1.UseVisualStyleBackColor = true;
            // 
            // nxtDet
            // 
            nxtDet.Location = new Point(702, 279);
            nxtDet.Name = "nxtDet";
            nxtDet.Size = new Size(94, 29);
            nxtDet.TabIndex = 12;
            nxtDet.Text = "Next";
            nxtDet.UseVisualStyleBackColor = true;
            // 
            // txtpackageID
            // 
            txtpackageID.Location = new Point(416, 23);
            txtpackageID.Name = "txtpackageID";
            txtpackageID.Size = new Size(116, 32);
            txtpackageID.TabIndex = 11;
            txtpackageID.Text = "";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(416, 66);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(116, 32);
            txtWeight.TabIndex = 10;
            txtWeight.Text = "";
            // 
            // txtlength
            // 
            txtlength.Location = new Point(416, 117);
            txtlength.Name = "txtlength";
            txtlength.Size = new Size(116, 32);
            txtlength.TabIndex = 9;
            txtlength.Text = "";
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(416, 174);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(116, 32);
            txtWidth.TabIndex = 8;
            txtWidth.Text = "";
            // 
            // txtheight
            // 
            txtheight.Location = new Point(416, 232);
            txtheight.Name = "txtheight";
            txtheight.Size = new Size(116, 32);
            txtheight.TabIndex = 7;
            txtheight.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(275, 232);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 6;
            label7.Text = "Height";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(275, 177);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 5;
            label6.Text = "Width";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(275, 120);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 4;
            label5.Text = "Length";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(275, 69);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 3;
            label4.Text = "Weight";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(275, 26);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 1;
            label3.Text = "Package ID";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(29, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(176, 156);
            panel1.TabIndex = 0;
            // 
            // packageDet2
            // 
            packageDet2.Controls.Add(backbtn);
            packageDet2.Controls.Add(deadlinePicker);
            packageDet2.Controls.Add(rdoStandard);
            packageDet2.Controls.Add(label11);
            packageDet2.Controls.Add(saveBtn);
            packageDet2.Controls.Add(cancelBtn);
            packageDet2.Controls.Add(IsPriority);
            packageDet2.Controls.Add(txtContent);
            packageDet2.Controls.Add(txtDestination);
            packageDet2.Controls.Add(label10);
            packageDet2.Controls.Add(label9);
            packageDet2.Controls.Add(label8);
            packageDet2.Controls.Add(panel2);
            packageDet2.Location = new Point(4, 29);
            packageDet2.Name = "packageDet2";
            packageDet2.Padding = new Padding(3);
            packageDet2.Size = new Size(958, 328);
            packageDet2.TabIndex = 2;
            packageDet2.Text = "packageDet2";
            packageDet2.UseVisualStyleBackColor = true;
            // 
            // backbtn
            // 
            backbtn.Location = new Point(481, 276);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(112, 36);
            backbtn.TabIndex = 14;
            backbtn.Text = "back";
            backbtn.UseVisualStyleBackColor = true;
            // 
            // deadlinePicker
            // 
            deadlinePicker.CalendarForeColor = Color.Lime;
            deadlinePicker.Location = new Point(784, 61);
            deadlinePicker.Name = "deadlinePicker";
            deadlinePicker.Size = new Size(142, 27);
            deadlinePicker.TabIndex = 13;
            // 
            // rdoStandard
            // 
            rdoStandard.AutoSize = true;
            rdoStandard.Location = new Point(523, 27);
            rdoStandard.Name = "rdoStandard";
            rdoStandard.Size = new Size(100, 24);
            rdoStandard.TabIndex = 12;
            rdoStandard.TabStop = true;
            rdoStandard.Text = "IsStandard";
            rdoStandard.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Cooper Black", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(798, 31);
            label11.Name = "label11";
            label11.Size = new Size(75, 17);
            label11.TabIndex = 10;
            label11.Text = "Deadline";
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(643, 276);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(112, 36);
            saveBtn.TabIndex = 9;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(297, 276);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(116, 36);
            cancelBtn.TabIndex = 8;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // IsPriority
            // 
            IsPriority.AutoSize = true;
            IsPriority.Location = new Point(417, 27);
            IsPriority.Name = "IsPriority";
            IsPriority.Size = new Size(87, 24);
            IsPriority.TabIndex = 7;
            IsPriority.TabStop = true;
            IsPriority.Text = "IsPriority";
            IsPriority.UseVisualStyleBackColor = true;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(417, 188);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(338, 70);
            txtContent.TabIndex = 6;
            txtContent.Text = "";
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(417, 103);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(338, 48);
            txtDestination.TabIndex = 5;
            txtDestination.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(307, 191);
            label10.Name = "label10";
            label10.Size = new Size(61, 20);
            label10.TabIndex = 4;
            label10.Text = "Content";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(306, 106);
            label9.Name = "label9";
            label9.Size = new Size(85, 20);
            label9.TabIndex = 3;
            label9.Text = "Destination";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(307, 29);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 1;
            label8.Text = "Status";
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(23, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(194, 169);
            panel2.TabIndex = 0;
            // 
            // importBtn
            // 
            importBtn.Location = new Point(603, 75);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(131, 41);
            importBtn.TabIndex = 5;
            importBtn.Text = "Import";
            importBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cooper Black", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(93, 517);
            label2.Name = "label2";
            label2.Size = new Size(97, 17);
            label2.TabIndex = 8;
            label2.Text = "Total rows:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.ImeMode = ImeMode.Off;
            comboBox1.Items.AddRange(new object[] { "latest", "earliest" });
            comboBox1.Location = new Point(326, 75);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 9;
            comboBox1.Text = "Sort";
            // 
            // previousBtn
            // 
            previousBtn.Location = new Point(254, 489);
            previousBtn.Name = "previousBtn";
            previousBtn.Size = new Size(133, 29);
            previousBtn.TabIndex = 10;
            previousBtn.Text = "Previous page";
            previousBtn.UseVisualStyleBackColor = true;
            // 
            // nextBtn
            // 
            nextBtn.Location = new Point(439, 489);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(94, 29);
            nextBtn.TabIndex = 11;
            nextBtn.Text = "Next Page";
            nextBtn.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(647, 23);
            label12.Name = "label12";
            label12.Size = new Size(89, 20);
            label12.TabIndex = 13;
            label12.Text = "Customer Id";
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(774, 23);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(125, 27);
            txtCustomer.TabIndex = 14;
            // 
            // PackageView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 560);
            Controls.Add(nextBtn);
            Controls.Add(previousBtn);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(importBtn);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Controls.Add(searchBtn);
            Controls.Add(searchBox);
            Name = "PackageView";
            Text = "PackageView";
            tabControl1.ResumeLayout(false);
            packagesTbl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)packageTbl).EndInit();
            packageDet1.ResumeLayout(false);
            packageDet1.PerformLayout();
            packageDet2.ResumeLayout(false);
            packageDet2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchBox;
        private Button searchBtn;
        private Label label1;
        private TabControl tabControl1;
        private TabPage packagesTbl;
        private TabPage packageDet1;
        private Button addBtn;
        private Button importBtn;
        private Button deleteBtn;
        private DataGridView packageTbl;
        private Button editBtn;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button nxtDet;
        private RichTextBox txtpackageID;
        private RichTextBox txtWeight;
        private RichTextBox txtlength;
        private RichTextBox txtWidth;
        private RichTextBox txtheight;
        private Label label7;
        private TabPage packageDet2;
        private Label label10;
        private Label label9;
        private Label label8;
        private Panel panel2;
        private RichTextBox txtContent;
        private RichTextBox txtDestination;
        private RadioButton IsPriority;
        private Button saveBtn;
        private Button cancelBtn;
        private ComboBox comboBox1;
        private Button previousBtn;
        private Button nextBtn;
        private Label label11;
        private RadioButton rdoStandard;
        private DateTimePicker deadlinePicker;
        private Button backbtn;
        private Label label12;
        private TextBox txtCustomer;
    }
}