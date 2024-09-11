using Rexor.Controllers;
using Rexor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
namespace Rexor.Services
{
    public class CustomerService
    {
        private static readonly MemoryCache Cache = MemoryCache.Default;

        private ApplicationDbContext _db = new ApplicationDbContext();
        public List<Customer> GetCustomers()
        {
            var cacheKey = "CustomerList";
            if (Cache.Contains(cacheKey)) return (List<Customer>)Cache[cacheKey];
            // Fetch from database
            var customers = _db.Customers.ToList();

            // Cache for 10 minutes
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
            };
            Cache.Add(cacheKey, customers, cacheItemPolicy);

            return (List<Customer>)Cache[cacheKey];
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
               Console.WriteLine("Failed to save: Message: " + ex);
               return false;
            }
        }
    }
}