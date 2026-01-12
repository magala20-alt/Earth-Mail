using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Postal_Management_System.Core.Entities
{
    [PrimaryKey("PackageID")]
    public class Packages
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Package ID is required.")]
        public string PackageID { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "Weight must be greater than zero.")]
        public int  Weight { get; set; }
        [Range(0.1, double.MaxValue, ErrorMessage = "Weight must be greater than zero.")]
        public int Length { get; set; }
        [Range(0.1, double.MaxValue, ErrorMessage = "Width must be greater than zero.")]
        public int Width { get; set; }
        [Range(0.1, double.MaxValue, ErrorMessage = "Height must be greater than zero.")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } // Add this line

        public string Dest_address { get; set; }
        public string ContentDes { get; set; }
        [Required(ErrorMessage = "Deadline is required.")]
        public DateTime Deadline { get; set; }

        //Foreign key
        [ForeignKey("Tracking")]
        public string TrackingID { get; set; }
        public virtual Tracking Tracking { get; set; }

        //[ForeignKey("Customers")]
        //public string CustomersCustID { get; set; } // one to one relationship
        //public virtual Customers Customers { get; set; } // navigation property


    }
    public class PackagesMap : ClassMap<Packages>
    {
        public PackagesMap()
        {
            Map(m => m.PackageID).Name("packageID");
            Map(m => m.Weight).Name("weight");
            Map(m => m.Length).Name("length");
            Map(m => m.Width).Name("width");
            Map(m => m.Height).Name("height");
            Map(m => m.ContentDes).Name("contentDes");
            Map(m =>m.Dest_address).Name("address");
            Map(m => m.TrackingID).Name("trackingID");
            Map(m => m.Deadline).Name("deadline");
        }
    }
}
