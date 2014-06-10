using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped] // Tell EF not to expect a column in the DB table
        public string FormalName
        { get { return LastName + ", " + FirstName; } }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [NotMapped]
        public string FullName { get; set; }

        // Navigation Properties
        public virtual IEnumerable<Order> Orders { get; set; }  // IEnumerable is basically a collection interface
        // virtual keyword in EF allows Orders to be "lazy-loaded"
        public virtual ContactDetail ContactDetail { get; set; }
    }

}
