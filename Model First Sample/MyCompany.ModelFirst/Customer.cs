//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCompany.ModelFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
            this.Addresses = new HashSet<Address>();
        }
    
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerTypeId { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual ContactDetail ContactDetail { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
