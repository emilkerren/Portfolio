using Rexor.Controllers;
using Rexor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Rexor.Services
{
    public class RebateService
    {
        private static readonly MemoryCache _cache = MemoryCache.Default;

        private ApplicationDbContext db = new ApplicationDbContext();
        public List<Rebate> GetRebates()
        {
            var cacheKey = "RebateList";
            if (!_cache.Contains(cacheKey))
            {
                // Fetch from database
                var rebates = db.Rebates.ToList();

                // Cache for 10 minutes
                var cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
                };
                _cache.Add(cacheKey, rebates, cacheItemPolicy);
            }
            return (List<Rebate>)_cache[cacheKey];
        }
        public void CreateRebate(Rebate rebate)
        {
            db.Rebates.Add(rebate);
            db.SaveChanges();
        }
    }
}