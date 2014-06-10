using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.CodeFirst.Entities
{
    // This provides extra contact info for a customer (stored in a separate table with a 0/1 to 1 relationship)
    public class ContactDetail
    {
        [Key, ForeignKey("Customer")]
        public int CustomerId {get; set;}
        public string HomePhone {get; set;}
        public string OfficeNumber {get; set;}

        // Navigation Properties
        public virtual Customer Customer {get; set;}
    
    }
}
