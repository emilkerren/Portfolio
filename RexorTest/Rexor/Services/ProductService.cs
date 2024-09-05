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
        private static readonly MemoryCache _cache = MemoryCache.Default;

        private ApplicationDbContext db = new ApplicationDbContext();
        public List<Product> GetProducts()
        {
            var cacheKey = "ProductList";
            if (!_cache.Contains(cacheKey))
            {
                // Fetch from database
                var products = db.Products.ToList();

                // Cache for 10 minutes
                var cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
                };
                _cache.Add(cacheKey, products, cacheItemPolicy);
            }

            return (List<Product>)_cache[cacheKey];
        }
        public void CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
    }
}