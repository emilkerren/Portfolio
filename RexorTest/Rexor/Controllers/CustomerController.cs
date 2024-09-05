using Rexor.Models;
using Rexor.Services;
using System.Web.Mvc;

namespace Rexor.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerService customerService = new CustomerService();
            return View(customerService.GetCustomers());
        }
        // CREATE: Customer
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerService service = new CustomerService();
                service.CreateCustomer(customer);
                TempData["SuccessMessage"] = "Customer created successfully!";
                return RedirectToAction("Index"); // Redirect to the list or another action
            }

            // If we got this far, something failed; redisplay form.
            return View(customer);
        }
    }
}