using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postal_Management_System.Presentation.views
{
    public interface IEmployeeView
    {
        // Employee Management
        string EmployeeID { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }

        string Role { get; set; }
        string SearchedEmployee {  get; set; }
        bool IsEdit {get; set;}
        bool IsSuccessful { get; set;}
        string Message {get; set;}

        event EventHandler SaveEmployee;
        event EventHandler SearchEvent;
        event EventHandler NextPageClicked;
        event EventHandler PreviousPageClicked;
        event EventHandler AddNewEmployee;
        event EventHandler DeleteEmployee;
        event EventHandler EditEmployee;
        event EventHandler cancelEvent;
        event EventHandler ImportClicked;
        event EventHandler ExportClicked;

        //Methods
        void SetEmployeeListBindingSource(BindingSource employeeList);

       
    }
}
