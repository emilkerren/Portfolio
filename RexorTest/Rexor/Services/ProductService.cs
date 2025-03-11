using Rexor.Controllers;
using Rexor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Rexor.Services
{
    public class ProductsService
    {
        private static readonly MemoryCache Cache = MemoryCache.Default;

        private ApplicationDbContext _db = new ApplicationDbContext();

        public List<Product> GetProducts()
        {
            var cacheKey = "ProductList";
            if (Cache.Contains(cacheKey)) return (List<Product>)Cache[cacheKey];
            // Fetch from database
            var products = _db.Products.ToList();

            // Cache for 10 minutes
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
            };
            Cache.Add(cacheKey, products, cacheItemPolicy);

            return (List<Product>)Cache[cacheKey];
        }

        public void CreateProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }
    }
}