using Rexor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rexor.Controllers
{
    public class Item
    {
        private Product _product = new Product();
        public Product Product { get { return _product; } set { _product = value; } }
        private Customer _customer = new Customer();
        public Customer Customer { get { return _customer; } set { _customer = value; } }
        private int _quantity;
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public Item()
        {
                
        }
        public Item(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            
        }
        public Item(Product product, int quantity, Customer customer)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Customer = customer;
        }
    }
}
