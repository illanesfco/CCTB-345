using MyCompany.CodeFirst.DAL; // to access the DbContext
using MyCompany.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyCommandPrompt
{
    class Program
    {
        static void Main(string[] args)
        {
            // The using statement here ensures that the SalesContext object is properly disposed of in the event of an exception
            // NOTE: Since SalesContext inherits from DbContext, we need to add a NuGet reference to Entity Framework
            using (SalesContext context = new SalesContext())
            {
                // A) Ask for a customer to add
                Customer firstCustomer = new Customer();
                Console.Write("Enter a first name: ");
                firstCustomer.FirstName = Console.ReadLine();
                Console.Write("Enter a last name: ");
                firstCustomer.LastName = Console.ReadLine();
                
                // B) Add this customer to our database context
                context.Customers.Add(firstCustomer);
                context.SaveChanges(); //saves a transaction

                // C) Show all the customers
                var all = context.Customers;
                foreach (Customer person in all)
                {
                    Console.WriteLine("{0} {1} - {2}", person.FirstName, person.LastName, person.CustomerId);
                }
            }
        }
    }
}
