using System;
using System.ComponentModel.DataAnnotations;

namespace Rexor.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public double Price { get; set;}
        public Product()
        {
        }
    }
}
