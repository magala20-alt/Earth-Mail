
namespace Postal_Management_System.views
{
    partial class DashboardView
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblEmployees;
        private Label lblCustomers;
        private Label lblPackages;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardView));
            lblEmployees = new Label();
            lblCustomers = new Label();
            lblPackages = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            flowLayoutPanel6 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // lblEmployees
            // 
            lblEmployees.AutoSize = true;
            lblEmployees.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmployees.Location = new Point(3, 105);
            lblEmployees.Name = "lblEmployees";
            lblEmployees.Size = new Size(171, 28);
            lblEmployees.TabIndex = 0;
            lblEmployees.Text = "Total Employees:";
            // 
            // lblCustomers
            // 
            lblCustomers.AutoSize = true;
            lblCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCustomers.Location = new Point(3, 105);
            lblCustomers.Name = "lblCustomers";
            lblCustomers.Size = new Size(169, 28);
            lblCustomers.TabIndex = 1;
            lblCustomers.Text = "Total Customers:";
            // 
            // lblPackages
            // 
            lblPackages.AutoSize = true;
            lblPackages.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPackages.ImageAlign = ContentAlignment.MiddleLeft;
            lblPackages.Location = new Point(3, 118);
            lblPackages.Name = "lblPackages";
            lblPackages.Size = new Size(157, 28);
            lblPackages.TabIndex = 2;
            lblPackages.Text = "Total Packages:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Yellow;
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Controls.Add(lblPackages);
            flowLayoutPanel1.Location = new Point(24, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(266, 169);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackgroundImage = (Image)resources.GetObject("flowLayoutPanel2.BackgroundImage");
            flowLayoutPanel2.BackgroundImageLayout = ImageLayout.Stretch;
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(144, 112);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.SeaShell;
            flowLayoutPanel3.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel3.Controls.Add(lblEmployees);
            flowLayoutPanel3.Location = new Point(250, 195);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(250, 158);
            flowLayoutPanel3.TabIndex = 4;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BackgroundImage = (Image)resources.GetObject("flowLayoutPanel4.BackgroundImage");
            flowLayoutPanel4.BackgroundImageLayout = ImageLayout.Zoom;
            flowLayoutPanel4.Location = new Point(3, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(133, 99);
            flowLayoutPanel4.TabIndex = 1;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.BackColor = Color.Aquamarine;
            flowLayoutPanel5.Controls.Add(flowLayoutPanel6);
            flowLayoutPanel5.Controls.Add(lblCustomers);
            flowLayoutPanel5.Location = new Point(418, 13);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(250, 158);
            flowLayoutPanel5.TabIndex = 5;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.BackgroundImage = (Image)resources.GetObject("flowLayoutPanel6.BackgroundImage");
            flowLayoutPanel6.BackgroundImageLayout = ImageLayout.Zoom;
            flowLayoutPanel6.Location = new Point(3, 3);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(133, 99);
            flowLayoutPanel6.TabIndex = 1;
            // 
            // DashboardView
            // 
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(789, 383);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel5);
            Name = "DashboardView";
            Text = "Dashboard Overview";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
    }
}
