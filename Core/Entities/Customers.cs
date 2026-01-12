using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Postal_Management_System.Core.Entities
{
    [PrimaryKey("CustID")]
    public class Customers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Customer ID is required.")]
        public string CustID { get; set; } // Primary Key
        [Required(ErrorMessage = "First name is required.")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string Lastname { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        // A customer can have multiple tracking records
        public virtual ICollection<Tracking> TrackingRecords { get; set; } = new List<Tracking>();
    }
    //map customer entities from csv file
    public class CustomersMap : ClassMap<Customers>
    {
        public CustomersMap()
        {
            Map(m => m.CustID).Name("CustID");
            Map(m => m.Firstname).Name("Firstname");
            Map(m => m.Lastname).Name("Lastname");
            Map(m => m.Email).Name("Email");
            Map(m => m.PhoneNo).Name("PhoneNo");
            Map(m => m.Address).Name("Address");
        }
    }
}
