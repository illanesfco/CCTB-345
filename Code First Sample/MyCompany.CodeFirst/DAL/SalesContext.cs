using MyCompany.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.CodeFirst.DAL
{
    // NOTE: Although this is a public class, normally I would make it internal and provide access to the database only through the
    // Business Logic Layer (BLL)
    public class SalesContext : DbContext 
    {
        // Parameterless constructore with hard-coded reference to connection string name
        public SalesContext() : base("name=MyDb") { }

        // These DbSet<T> properties are representations of our database tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
