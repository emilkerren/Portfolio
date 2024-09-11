using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Rexor.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringValidator(MinLength = 2, MaxLength = 10)]
        public string Name { get; set; }
        [Required]
        public DateTime DateAdded { get; private set; } = DateTime.Now;
        [Required]
        public double Price { get; set;}
    }
}
