using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.ModelFirst
{
    // Adding hand-crafted changes to the Customer entity class
    public partial class Customer
    {
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
