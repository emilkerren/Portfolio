using System.ComponentModel.DataAnnotations;

namespace Rexor.Models
{
    public class Item
    {
        [Key] public int Id { get; set; }

        [Required] public Product Product { get; set; }

        [Required] public Customer Customer { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "PartitionKey must be greater than 0.")]
        public int Quantity { get; set; }

        public Item(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Item(Product product, int quantity, Customer customer)
        {
            Product = product;
            Quantity = quantity;
            Customer = customer;
        }
    }
}