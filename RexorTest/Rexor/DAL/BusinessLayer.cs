using System;
using System.Collections.Generic;
using Rexor.Models;
namespace Rexor.DAL
{
     
    public class BusinessLayer
    {
        public List<Customer> GetCustomers(){
            List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "IKEA", RebateId = 1, DateAdded = DateTime.Now, AmountBought = 1000 },
                new Customer { Name = "JYSK", RebateId = 2, DateAdded = DateTime.Now, AmountBought = 3000 },
                new Customer { Name = "MIO", RebateId = 3, DateAdded = DateTime.Now, AmountBought = 5000 }
            };
            return customers;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Chair", Price = 100, DateAdded = DateTime.Now },
                new Product { Name = "Table", Price = 200, DateAdded = DateTime.Now },
                new Product { Name = "Desk", Price = 300, DateAdded = DateTime.Now }
            };
            return products;
        }
        public List<Rebate> GetRebates()
        {
            List<Rebate> rebates = new List<Rebate>
            {
                new Rebate { Name = "Chair", RebateId = 0, Amount = 0.1, DateAdded = DateTime.Now },
                new Rebate { Name = "Table", RebateId = 1, Amount = 0.2, DateAdded = DateTime.Now },
                new Rebate { Name = "Desk", RebateId = 2, Amount = 0.3, DateAdded = DateTime.Now }
            };
            return rebates;
        }
    }
}
