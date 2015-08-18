using Rexor.DAL;
using Rexor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rexor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            BusinessLayer productsBL = new BusinessLayer();
            List<Product> products = productsBL.GetProducts();
            //ViewData["CustomerList"] = Enum.GetValues(typeof(Customer)).Cast<Customer>().Select(c => new SelectListItem { Text = c.Name.ToString(), Value = c.CustomerId.ToString() });

            return View(products);
        }
    }
}