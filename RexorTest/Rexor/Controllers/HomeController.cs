using Rexor.Models;
using Rexor.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Rexor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ProductsService productsService = new ProductsService();
            List<Product> products = productsService.GetProducts();
            //ViewData["CustomerList"] = Enum.GetValues(typeof(Customer)).Cast<Customer>().Select(c => new SelectListItem { Text = c.Name.ToString(), Value = c.CustomerId.ToString() });

            return View(products);
        }
    }
}