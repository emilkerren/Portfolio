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
        private static readonly MemoryCache _cache = MemoryCache.Default;

        private ApplicationDbContext db = new ApplicationDbContext();
        public List<Customer> GetCustomers()
        {
            var cacheKey = "CustomerList";
            if (!_cache.Contains(cacheKey))
            {
                // Fetch from database
                var customers = db.Customers.ToList();

                // Cache for 10 minutes
                var cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
                };
                _cache.Add(cacheKey, customers, cacheItemPolicy);
            }

            return (List<Customer>)_cache[cacheKey];
        }

        public void CreateCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
    }
}