using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Postal_Management_System.Core.Entities;

namespace Postal_Management_System.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        //used for dependency injection 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            :base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        // Define DbSet properties 
        public DbSet<Customers> Customers { get; set; }
        public DbSet <Employee> Employees { get; set; }
        public DbSet <Packages> Packages { get; set; }
        public DbSet<Tracking> Tracking { get; set; }

        // Configure connection string and options
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Postage ;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"; //change connection string here
                optionsBuilder.UseSqlServer(connectionString);
            }
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().ToTable("Customers"); // Mapped the DbSet to renamed table
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Packages>().ToTable("PackageDetails");
            modelBuilder.Entity<Tracking>().ToTable("PackageTracking");
        }

        // autogenerate customized IDs
        public override int SaveChanges()
        {
           foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.State == EntityState.Added)
                {
                    var entityType = entry.Entity.GetType();
                    var keyProperty = entityType.GetProperties()
                        .FirstOrDefault(p => p.Name.EndsWith("ID") || p.Name.EndsWith("Id")); // checks for possible ids in the header
                    if(keyProperty != null)
                    {
                        string prefix = GetPrefixForEntity(entityType.Name);
                        string newId = GenerateNextId(entityType, keyProperty, prefix);

                        keyProperty.SetValue(entry.Entity, newId); 
                    }
                }
            }
           return base.SaveChanges();
        }

        //method to return prefix
        private string GetPrefixForEntity(string entityName)
        {
            return entityName switch
            {
                "Customers" => "C",
                "Packages" => "PG",
                "Tracking" => "T"
            };
        }

        //generate next customized id
        public string GenerateNextId(Type entityType, PropertyInfo keyProperty, string prefix)
        {
            var dbSet = this.GetType().GetProperty(entityType.Name)?.GetValue(this);
            if (dbSet is IQueryable<object> query)
            {
                var lastEntity = query.OrderByDescending(e => keyProperty.GetValue(e)).FirstOrDefault();
                if (lastEntity == null)
                {
                    return $"{prefix}001"; // First record
                }

                string lastId = keyProperty.GetValue(lastEntity)?.ToString()?.Substring(1);
                int newId = int.Parse(lastId) + 1;
                return $"{prefix}{newId:D3}";
            }
            return $"{prefix}001";
        }

        public string GetNextCustomId<T>() where T : class
        {
            string entityName = typeof(T).Name;
            var keyProperty = typeof(T).GetProperties()
                .FirstOrDefault(p => p.Name.EndsWith("ID") || p.Name.EndsWith("Id"));

            if (keyProperty == null)
                throw new InvalidOperationException("No ID property found");

            string prefix = GetPrefixForEntity(entityName);

            var dbSet = this.Set<T>();
            var lastEntity = dbSet
                .AsEnumerable()
                .OrderByDescending(e => keyProperty.GetValue(e))
                .FirstOrDefault();

            if (lastEntity == null)
                return $"{prefix}001";

            string lastId = keyProperty.GetValue(lastEntity)?.ToString()?.Substring(prefix.Length);
            int newId = int.Parse(lastId) + 1;
            return $"{prefix}{newId:D3}";
        }

    }
}
