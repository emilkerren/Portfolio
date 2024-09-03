using System;

namespace Rexor.Models
{
    public class Rebate
    {
        public int RebateId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public double Amount { get; set; }
        public Rebate()
        {
                
        }
    }
}
