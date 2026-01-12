using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Core.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.IO.Packaging;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Presentation.views;

namespace Postal_Management_System.views
{
    public partial class AdminView : Form, IAdminView
    {
        //form controls config
        bool sidebarExpand;

        public event EventHandler ShowEmployeeView;
        public event EventHandler ShowCustomerView;
        public event EventHandler ShowPackageView;
        public event EventHandler Logout;
        public event EventHandler ShowDashboardView;

        public event EventHandler ShowTrackingView;

        //dependency injection
        public AdminView()
        {
            InitializeComponent();
            employeeBtn.Click += delegate { ShowEmployeeView?.Invoke(this, EventArgs.Empty); }; //click to show employeeBtn
            customerBtn.Click += delegate { ShowCustomerView?.Invoke(this, EventArgs.Empty); }; //click to show customerBtn
            packageBtn.Click += delegate { ShowPackageView?.Invoke(this, EventArgs.Empty); }; //click to show packageBtn
            logOutBtn.Click += delegate { Logout?.Invoke(this, EventArgs.Empty); }; //click to show logOutBtn
            trackingBtn.Click += delegate { ShowTrackingView?.Invoke(this, EventArgs.Empty); }; //click to show trackingBtn
            dashboardBtn.Click += (s, e) => ShowDashboardView?.Invoke(this, EventArgs.Empty); // click to show dashboard

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }
        //side bar expanision
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            //MAXIMUM SIZE AND WIDTH

            //sidebar expanded
            if (sidebarExpand)
            {
                sidebarContainer.Width -= 10;
                if (sidebarContainer.Width == sidebarContainer.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();

                }
            }
            else
            {
                sidebarContainer.Width += 10;
                if (sidebarContainer.Width == sidebarContainer.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }

            }
        }

        //setting window views
        private void menuBtn_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start(); // sidebar animation
        }
    }
}
