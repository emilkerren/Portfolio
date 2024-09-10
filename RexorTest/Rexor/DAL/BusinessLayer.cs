using System.Collections.Generic;
using Rexor.Models;
namespace Rexor.DAL
{
     
    public class BusinessLayer
    {
        public List<Customer> GetCustomers(){
            List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "IKEA", RebateId = 1, AmountBought = 1000 },
                new Customer { Name = "JYSK", RebateId = 2, AmountBought = 3000 },
                new Customer { Name = "MIO", RebateId = 3, AmountBought = 5000 }
            };
            return customers;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Chair", Price = 100 },
                new Product { Name = "Table", Price = 200 },
                new Product { Name = "Desk", Price = 300 }
            };
            return products;
        }
        public List<Rebate> GetRebates()
        {
            List<Rebate> rebates = new List<Rebate>
            {
                new Rebate { Name = "Chair", RebateId = 1, Amount = 0.1 },
                new Rebate { Name = "Table", RebateId = 2, Amount = 0.2 },
                new Rebate { Name = "Desk", RebateId = 3, Amount = 0.3 }
            };
            return rebates;
        }
    }
}
