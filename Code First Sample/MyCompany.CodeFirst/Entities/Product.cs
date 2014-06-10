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
        [Required]
        [StringLength(75)]
        public string Description { get; set; }
        [Required(ErrorMessage="Product Name is required"), 
            StringLength(25, MinimumLength=5, ErrorMessage="Product names are between 5 and 25 characters in length")]
        public string Name { get; set; }

        // Navigation Properties
        public virtual IEnumerable<LineItem> LineItems { get; set; }
    }
}
