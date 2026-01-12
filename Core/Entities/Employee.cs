using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Postal_Management_System.Core.Entities
{
    [PrimaryKey("EmployeeID")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string EmployeeID { get; set; }
        public string Firstname { get; set; }
        public string  Lastname { get; set; }
        public string Role { get; set; }

    }
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(m => m.EmployeeID).Name("EmployeeID");
            Map(m => m.Firstname).Name("firstname");
            Map(m => m.Lastname).Name("lastname");
            Map(m => m.Role).Name("role");
        }
    }
}
