namespace Postal_Management_System.views
{
    partial class AdminView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminView));
            employeeBindingSource = new BindingSource(components);
            applicationDbContextBindingSource = new BindingSource(components);
            applicationDbContextBindingSource1 = new BindingSource(components);
            customersBindingSource = new BindingSource(components);
            customersBindingSource1 = new BindingSource(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            sidebarContainer = new FlowLayoutPanel();
            dashboardBtn = new Button();
            employeeBtn = new Button();
            customerBtn = new Button();
            packageBtn = new Button();
            trackingBtn = new Button();
            sidebarTimer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            menuBtn = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel6 = new Panel();
            logOutBtn = new Button();
            contentPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customersBindingSource1).BeginInit();
            sidebarContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)menuBtn).BeginInit();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // employeeBindingSource
            // 
            employeeBindingSource.DataSource = typeof(Core.Entities.Employee);
            // 
            // applicationDbContextBindingSource
            // 
            applicationDbContextBindingSource.DataSource = typeof(Core.Data.ApplicationDbContext);
            // 
            // applicationDbContextBindingSource1
            // 
            applicationDbContextBindingSource1.DataSource = typeof(Core.Data.ApplicationDbContext);
            // 
            // customersBindingSource
            // 
            customersBindingSource.DataSource = typeof(Core.Entities.Customers);
            // 
            // customersBindingSource1
            // 
            customersBindingSource1.DataSource = typeof(Core.Entities.Customers);
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // sidebarContainer
            // 
            sidebarContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sidebarContainer.AutoScroll = true;
            sidebarContainer.AutoSize = true;
            sidebarContainer.BackColor = Color.PaleGreen;
            sidebarContainer.Controls.Add(dashboardBtn);
            sidebarContainer.Controls.Add(employeeBtn);
            sidebarContainer.Controls.Add(customerBtn);
            sidebarContainer.Controls.Add(packageBtn);
            sidebarContainer.Controls.Add(trackingBtn);
            sidebarContainer.Location = new Point(2, 64);
            sidebarContainer.Name = "sidebarContainer";
            sidebarContainer.Size = new Size(262, 670);
            sidebarContainer.TabIndex = 3;
            // 
            // dashboardBtn
            // 
            dashboardBtn.BackColor = Color.PaleGreen;
            dashboardBtn.FlatAppearance.BorderColor = Color.Black;
            dashboardBtn.FlatAppearance.BorderSize = 0;
            dashboardBtn.FlatStyle = FlatStyle.Flat;
            dashboardBtn.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dashboardBtn.Image = (Image)resources.GetObject("dashboardBtn.Image");
            dashboardBtn.ImageAlign = ContentAlignment.MiddleLeft;
            dashboardBtn.Location = new Point(3, 3);
            dashboardBtn.Name = "dashboardBtn";
            dashboardBtn.Padding = new Padding(11, 0, 0, 0);
            dashboardBtn.Size = new Size(253, 70);
            dashboardBtn.TabIndex = 4;
            dashboardBtn.Text = "Dashboard";
            dashboardBtn.UseVisualStyleBackColor = false;
            // 
            // employeeBtn
            // 
            employeeBtn.BackColor = Color.PaleGreen;
            employeeBtn.FlatAppearance.BorderSize = 0;
            employeeBtn.FlatStyle = FlatStyle.Flat;
            employeeBtn.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            employeeBtn.Image = (Image)resources.GetObject("employeeBtn.Image");
            employeeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            employeeBtn.Location = new Point(3, 79);
            employeeBtn.Name = "employeeBtn";
            employeeBtn.Padding = new Padding(11, 0, 0, 0);
            employeeBtn.Size = new Size(256, 67);
            employeeBtn.TabIndex = 5;
            employeeBtn.Text = "Employees";
            employeeBtn.UseVisualStyleBackColor = false;
            // 
            // customerBtn
            // 
            customerBtn.BackColor = Color.PaleGreen;
            customerBtn.FlatAppearance.BorderSize = 0;
            customerBtn.FlatStyle = FlatStyle.Flat;
            customerBtn.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customerBtn.Image = (Image)resources.GetObject("customerBtn.Image");
            customerBtn.ImageAlign = ContentAlignment.MiddleLeft;
            customerBtn.Location = new Point(3, 152);
            customerBtn.Name = "customerBtn";
            customerBtn.Padding = new Padding(11, 0, 0, 0);
            customerBtn.Size = new Size(253, 70);
            customerBtn.TabIndex = 6;
            customerBtn.Text = "Customers";
            customerBtn.UseVisualStyleBackColor = false;
            // 
            // packageBtn
            // 
            packageBtn.BackColor = Color.PaleGreen;
            packageBtn.FlatAppearance.BorderSize = 0;
            packageBtn.FlatStyle = FlatStyle.Flat;
            packageBtn.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            packageBtn.Image = (Image)resources.GetObject("packageBtn.Image");
            packageBtn.ImageAlign = ContentAlignment.MiddleLeft;
            packageBtn.Location = new Point(3, 228);
            packageBtn.Name = "packageBtn";
            packageBtn.Padding = new Padding(11, 0, 0, 0);
            packageBtn.Size = new Size(253, 70);
            packageBtn.TabIndex = 5;
            packageBtn.Text = "Packages";
            packageBtn.UseVisualStyleBackColor = false;
            // 
            // trackingBtn
            // 
            trackingBtn.BackColor = Color.PaleGreen;
            trackingBtn.FlatAppearance.BorderSize = 0;
            trackingBtn.FlatStyle = FlatStyle.Flat;
            trackingBtn.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            trackingBtn.Image = (Image)resources.GetObject("trackingBtn.Image");
            trackingBtn.ImageAlign = ContentAlignment.MiddleLeft;
            trackingBtn.Location = new Point(3, 304);
            trackingBtn.Name = "trackingBtn";
            trackingBtn.Padding = new Padding(11, 0, 0, 0);
            trackingBtn.Size = new Size(253, 70);
            trackingBtn.TabIndex = 5;
            trackingBtn.Text = "      Transaction Config";
            trackingBtn.UseVisualStyleBackColor = false;
            // 
            // sidebarTimer
            // 
            sidebarTimer.Interval = 10;
            sidebarTimer.Tick += sidebarTimer_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(78, 10);
            label1.Name = "label1";
            label1.Size = new Size(259, 32);
            label1.TabIndex = 0;
            label1.Text = "Earth Mail Postal";
            label1.Click += label1_Click;
            // 
            // menuBtn
            // 
            menuBtn.Image = Properties.Resources.menu;
            menuBtn.Location = new Point(7, 10);
            menuBtn.Name = "menuBtn";
            menuBtn.Size = new Size(42, 41);
            menuBtn.SizeMode = PictureBoxSizeMode.Zoom;
            menuBtn.TabIndex = 4;
            menuBtn.TabStop = false;
            menuBtn.Click += menuBtn_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 512);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(menuBtn);
            panel2.Controls.Add(label1);
            panel2.ForeColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(-1, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1230, 64);
            panel2.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.Controls.Add(logOutBtn);
            panel6.Location = new Point(1043, 10);
            panel6.Name = "panel6";
            panel6.Size = new Size(165, 47);
            panel6.TabIndex = 5;
            // 
            // logOutBtn
            // 
            logOutBtn.FlatAppearance.BorderColor = Color.Silver;
            logOutBtn.FlatAppearance.MouseDownBackColor = Color.Silver;
            logOutBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            logOutBtn.FlatStyle = FlatStyle.Flat;
            logOutBtn.Font = new Font("Cooper Black", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logOutBtn.Image = (Image)resources.GetObject("logOutBtn.Image");
            logOutBtn.ImageAlign = ContentAlignment.MiddleLeft;
            logOutBtn.Location = new Point(-15, 0);
            logOutBtn.Name = "logOutBtn";
            logOutBtn.Padding = new Padding(20, 0, 0, 0);
            logOutBtn.Size = new Size(192, 47);
            logOutBtn.TabIndex = 0;
            logOutBtn.Text = "           LogOut";
            logOutBtn.UseVisualStyleBackColor = true;
            // 
            // contentPanel
            // 
            contentPanel.Anchor = AnchorStyles.Top;
            contentPanel.Location = new Point(268, 64);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(961, 670);
            contentPanel.TabIndex = 5;
            // 
            // AdminView
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 735);
            Controls.Add(contentPanel);
            Controls.Add(sidebarContainer);
            Controls.Add(panel2);
            IsMdiContainer = true;
            Name = "AdminView";
            ShowIcon = false;
            Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)customersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)customersBindingSource1).EndInit();
            sidebarContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)menuBtn).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource applicationDbContextBindingSource1;
        private BindingSource applicationDbContextBindingSource;
        private BindingSource employeeBindingSource;
        private BindingSource customersBindingSource;
        private BindingSource customersBindingSource1;
        private ContextMenuStrip contextMenuStrip1;
        private FlowLayoutPanel sidebarContainer;
        private Button dashboardBtn;
        private Button employeeBtn;
        private Button customerBtn;
        private Button packageBtn;
        private Button trackingBtn;
        private System.Windows.Forms.Timer sidebarTimer;
        private Label label1;
        private PictureBox menuBtn;
        private Panel panel1;
        private Panel panel2;
        private Panel panel6;
        private Button logOutBtn;
        public Panel contentPanel;
    }
}