using Rexor.Models;
using System.ComponentModel.DataAnnotations;

namespace Rexor.Controllers
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Product Product { get { return _product; } set { _product = value; } }
        
        [Required]
        public Customer Customer { get { return _customer; } set { _customer = value; } }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "PartitionKey must be greater than 0.")]
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        
        private Product _product = new Product();
        private Customer _customer = new Customer();
        private int _quantity;
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
