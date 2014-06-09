using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.CodeFirst.Entities
{
    // This is a hand-crafted entity/class. We create/maintain these outselves in Code-First
    public class Customer
    {
        // By default, EF will treat "CustomerId" as a Primary Key in the database and an Identity column in the database table
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation Properties
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
