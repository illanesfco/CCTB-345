﻿using NorthwindSystem.DAL;
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
    public class NorthwindManager
    {
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
    }
}
