using System;
using System.Collections.Generic;
using Rexor.Models;
namespace Rexor.DAL
{
     
    public class BusinessLayer
    {
        public List<Customer> GetCustomers(){
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Name = "IKEA", CustomerId = 0, RebateId = 0, DateAdded = DateTime.Now, AmountBought = 1000 });
            customers.Add(new Customer { Name = "JYSK", CustomerId = 1, RebateId = 1, DateAdded = DateTime.Now, AmountBought = 3000 });
            customers.Add(new Customer { Name = "MIO", CustomerId = 2, RebateId = 2, DateAdded = DateTime.Now, AmountBought = 5000 });
            return customers;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Name = "Chair", ProductId = 0, Price = 100, DateAdded = DateTime.Now });
            products.Add(new Product { Name = "Table", ProductId = 1, Price = 200, DateAdded = DateTime.Now });
            products.Add(new Product { Name = "Desk", ProductId = 2, Price = 300, DateAdded = DateTime.Now});
            return products;
        }
        public List<Rebate> GetRebates()
        {
            List<Rebate> rebates = new List<Rebate>();
            rebates.Add(new Rebate { Name = "Chair", RebateId = 0, Amount = 0.1, DateAdded = DateTime.Now });
            rebates.Add(new Rebate { Name = "Table", RebateId = 1, Amount = 0.2, DateAdded = DateTime.Now });
            rebates.Add(new Rebate { Name = "Desk", RebateId = 2, Amount = 0.3, DateAdded = DateTime.Now });
            return rebates;
        }
    }
}
