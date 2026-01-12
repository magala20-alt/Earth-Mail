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
    [PrimaryKey("TrackingID")]
    public class Tracking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TrackingID { get; set; }
        public int CustomBill {get; set; }
        public string declared {  get; set; }

        public string PaymentStatus { get; set; } = "Pending"; // Paid, Pending
        public DateTime? BilledOn { get; set; }


        [ForeignKey("Packages")]
        public string PackageID { get; set; } // one to one relationship

        [ForeignKey("Customers")]
        public string custID { get; set; }  // one to one relationship

        [ForeignKey("Employees")]
        public string EmployeeID { get; set; } // one to one relationship

        //references
        public virtual Packages Package{ get; set; }
        //public virtual Customers Customers { get; set; }
        //public virtual Employee Employee { get; set; }
    }

}
