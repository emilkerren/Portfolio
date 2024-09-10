using System;
using System.ComponentModel.DataAnnotations;

namespace Rexor.Models
{
    public class Rebate
    {
        [Key]
        public int RebateId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateAdded { get; private set; } = DateTime.Now;
        public double Amount { get; set; }
        public Rebate()
        {
                
        }
    }
}
