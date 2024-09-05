using Rexor.Models;
using System.Data.Entity;

namespace Rexor.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("RexorConnection") // Connection string name from Web.config
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rebate> Rebates { get; set; }

        // Add more DbSets for other entities
    }
}