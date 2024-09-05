using Rexor.Controllers;
using Rexor.DAL;
using Rexor.Models;
using System.Data.Entity;

namespace Rexor
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            BusinessLayer businessLayer = new BusinessLayer();
            System.Collections.Generic.List<Customer> customers = businessLayer.GetCustomers();
            System.Collections.Generic.List<Product> products = businessLayer.GetProducts();
            System.Collections.Generic.List<Rebate> rebates = businessLayer.GetRebates();

            // Seeding default customers
            context.Customers.AddRange(customers);
            context.Products.AddRange(products);
            context.Rebates.AddRange(rebates);

            // Save any other entities
            context.SaveChanges();
        }
    }
}