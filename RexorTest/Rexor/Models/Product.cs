using System;
using System.ComponentModel.DataAnnotations;

namespace Rexor.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateAdded { get; private set; } = DateTime.Now;
        [Required]
        public double Price { get; set;}
        public Product()
        {
        }
    }
}
