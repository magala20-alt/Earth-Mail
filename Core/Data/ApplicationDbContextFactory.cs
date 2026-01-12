using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Postal_Management_System.Core.Data
{
    //class used to initialize ApplicationDbContext in design time
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Set up the options for the DbContext (like the connection string)
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Postage ;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");  // Use your actual connection string

            // Return an instance of ApplicationDbContext
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
