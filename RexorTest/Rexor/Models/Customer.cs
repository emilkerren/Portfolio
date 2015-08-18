using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rexor.Models
{
    public class Customer
    {
        //public List<Customer> CustomerList { get; set; }
        //public int SelectedCustomer { get; set; }
        public int CustomerId { get; set; }
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
