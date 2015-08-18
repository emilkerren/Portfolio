using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rexor.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public double Price { get; set;}
        public Product()
        {
        }
    }
}
