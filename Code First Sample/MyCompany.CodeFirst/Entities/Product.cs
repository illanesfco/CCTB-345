using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.CodeFirst.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public virtual IEnumerable<LineItem> LineItems { get; set; }
    }
}
