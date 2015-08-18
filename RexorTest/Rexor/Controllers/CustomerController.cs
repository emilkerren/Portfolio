using Rexor.DAL;
using Rexor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rexor.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            BusinessLayer customerBL = new BusinessLayer();
            List<Customer> customers = customerBL.GetCustomers();
            return View(customers);
        }
    }
}