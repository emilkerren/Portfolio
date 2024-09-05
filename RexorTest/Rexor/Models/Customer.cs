using System;
using System.ComponentModel.DataAnnotations;

namespace Rexor.Models
{
    public class Customer
    {
        //public List<Customer> CustomerList { get; set; }
        //public int SelectedCustomer { get; set; }
        [Key]
        public int CustomerId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "PartitionKey must be greater than 0.")]
        public int RebateId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public double AmountBought {get; set;}
        public Boolean IsSelected { get; set; }
        public Customer()
        {

        }

    }
}
