using NorthwindSystem.DAL;
using NorthwindSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // for some of the EF extension methods

namespace NorthwindSystem.BLL
{
    // This is the primary public access into the NorthwindSystem's data 
    public partial class NorthwindManager
    {
        #region Shippers
        public Shipper GetShipper(int shipperId)
        {
            using (var context = new NWContext())
            {
                return context.Shippers.Find(shipperId);
            }
        }

        public int AddShipper(Shipper info)
        {
            using (var context = new NWContext())
            {
                context.Shippers.Add(info);
                context.SaveChanges();
                return info.ShipperID;
            }

        }

        public void UpdateShipper(Shipper info)
        {
            // See question and commentary on http://stackoverflow.com/questions/15336248/entity-framwork-5-updating-a-record
            using (var context = new NWContext())
            {
                context.Shippers.Attach(info);
                context.Entry(info).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IList<Shipper> ListShippers()
        {
            using (var context = new NWContext()) 
            {
                return context.Shippers.ToList();
            }
        }

        public void DeleteShipper(Shipper info)
        {
            using (var context = new NWContext())
            {
                var found = context.Shippers.Find(info.ShipperID);
                if (found != null)
                {
                    context.Shippers.Remove(found);
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Products

        public Product GetProduct(int productId)
        {
            using (var context = new NWContext())
            {
                return context.Products.Find(productId);
            }
        }

        public int AddProduct(Product info)
        {
            using (var context = new NWContext())
            {
                context.Products.Add(info);
                context.SaveChanges();
                return info.ProductID;
            }
        }

        public void UpdateProduct(Product info)
        {
            // See question and commentary on http://stackoverflow.com/questions/15336248/entity-framwork-5-updating-a-record
            using (var context = new NWContext())
            {
                context.Products.Attach(info);
                context.Entry(info).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IList<Product> ListProducts()
        {
            using (var context = new NWContext())
            {
                return context.Products.ToList();
            }
        }

        public void DeleteProduct(Product info)
        {
            using (var context = new NWContext())
            {
                var found = context.Products.Find(info.ProductID);
                if (found != null)
                {
                    context.Products.Remove(found);
                    context.SaveChanges();
                }
            }
        }

        #endregion
        #region Legacy Code
        public List<Employee> GetEmployees()
        {
            using (var context = new NWContext())
            {
                var result = context.Employees;
                return result.ToList();
            }
        }

        // TODO: Create a method called GetOrders that will return a list of Order objects from the DB
        public List<Order> GetOrders()
        {
            using (var context = new NWContext())
            {
                var result = context.Orders;
                return result.ToList();
            }
        }

        public List<Region> GetRegions()
        {
            using (var context = new NWContext())
            {
                var result = context.Regions // for all regions
                                .Include(item => item.Territories) // include each item in the region
                                .OrderBy(item => item.RegionDescription); // sort by region description
                return result.ToList();
            }
        }
        #endregion
    }
}
