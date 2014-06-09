using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // has attributes we can use for our Entity 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.CodeFirst.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipToAddress { get; set; }
        public int CustomerId { get; set; }

        // Navigation Properties
        public virtual Customer Customer { get; set; }
    }
}
