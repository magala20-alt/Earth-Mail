using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Interfaces;

namespace Postal_Management_System.views
{
    public partial class MainForm : Form
    {
        private readonly IStoreRepository<Employee> _employeeRepository;
        private readonly IStoreRepository<Package> _packageRepository;
        private readonly IStoreRepository<Customers> _customerRepository;
        public MainForm(
              IStoreRepository<Employee> employeeRepository,
             IStoreRepository<Package> packageRepository,
             IStoreRepository<Customers> customerRepository
            )
        {
            InitializeComponent();
            _employeeRepository =employeeRepository;
            _packageRepository = packageRepository;
            _customerRepository = customerRepository;

            //Admin adminForm = new Admin(employeeRepository,packageRepository,customerRepository);

            //adminForm.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
