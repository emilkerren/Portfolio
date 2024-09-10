using Rexor.Models;
using Rexor.Services;
using System.Collections.Generic;
using System.Linq;
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
            List<SelectListItem> productItems = products.Select(p => new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.Name.ToString()
            }).ToList();
            ViewBag.Products = productItems;
            return View();
        }
    }
}