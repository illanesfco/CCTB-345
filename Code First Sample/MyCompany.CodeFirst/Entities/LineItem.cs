using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.CodeFirst.Entities
{
    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        //Constructor
        public LineItem()
        {
            Quantity = 1; // Any default values are best to set in the constructor
        }

        // Navigation Properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }



    }
}
