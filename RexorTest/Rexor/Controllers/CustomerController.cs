using Rexor.Models;
using Rexor.Services;
using System;
using System.Collections.Generic;
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
            RebateService rebateService = new RebateService();
            List<Rebate> rebates = rebateService.GetRebates();
            // Create SelectList for the dropdown
            ViewBag.Rebates = new SelectList(rebates, "RebateId", "Name");
            return View();
        }
        
        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (customer.RebateId == 0)
            {
                ModelState.AddModelError("PartitionKey", "PartitionKey cannot be 0.");
            }
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    var key = state.Key;  // Property name
                    var errors = state.Value.Errors;  // Collection of errors for this property

                    foreach (var error in errors)
                    {
                        // Log or inspect the error messages
                        Console.WriteLine($"Error in {key}: {error.ErrorMessage}");
                        if (error.Exception != null)
                        {
                            Console.WriteLine($"Exception: {error.Exception.Message}");
                        }
                    }
                }
            }
            else
            {
                CustomerService service = new CustomerService();
                if (service.CreateCustomer(customer))
                {
                    TempData["AlertMessage"] = "Customer created successfully!";
                    return RedirectToAction("Index"); // Redirect to the list or another action
                }
                else
                {
                    TempData["AlertMessage"] = "Customer not created successfully! Exception thrown in service";
                }
            }
            TempData["AlertMessage"] = "Customer not created successfully! ModelState not valid: " + ModelState.Values.ToString();
            // If we got this far, something failed; redisplay form.
            return View(customer);
        }
    }
}