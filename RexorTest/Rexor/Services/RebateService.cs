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
        private static readonly MemoryCache Cache = MemoryCache.Default;

        private ApplicationDbContext _db = new ApplicationDbContext();

        public List<Rebate> GetRebates()
        {
            var cacheKey = "RebateList";
            if (Cache.Contains(cacheKey)) return (List<Rebate>)Cache[cacheKey];
            // Fetch from database
            var rebates = _db.Rebates.ToList();

            // Cache for 10 minutes
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
            };
            Cache.Add(cacheKey, rebates, cacheItemPolicy);
            return (List<Rebate>)Cache[cacheKey];
        }

        public void CreateRebate(Rebate rebate)
        {
            _db.Rebates.Add(rebate);
            _db.SaveChanges();
        }
    }
}