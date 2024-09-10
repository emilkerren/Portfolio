using Rexor.Models;
using Rexor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Rexor.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ProductsService productsService = new ProductsService();
        private CustomerService customersService = new CustomerService();
        private RebateService rebatesService = new RebateService();
        private List<Product> shoppingProducts = new List<Product>();
        private List<Customer> customers = new List<Customer>();
        private List<Rebate> rebates = new List<Rebate>();
        //private
        // GET: ShoppingCart
        public ActionResult Index()
        {
            CustomerService customerService = new CustomerService();
            List<Customer> customers = customerService.GetCustomers();
            List<SelectListItem> customerItems = customers.Select(p => new SelectListItem
            {
                Value = p.CustomerId.ToString(),
                Text = p.Name.ToString()
            }).ToList();

            ViewBag.Customers = customerItems;
            return View();
        }

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                {

                    return i;
                }
            }
            return -1;
        }

        public ActionResult OrderNow(int id, int quantity)
        {
            if (Session["cart"] == null)
            {
                shoppingProducts = productsService.GetProducts();
                List<Item> cart = new List<Item>
                {
                    new Item(shoppingProducts.Find(x => x.ProductId == id), quantity)
                };
                Session["cart"] = cart;
            }
            customers = customersService.GetCustomers();
            IEnumerable<SelectListItem> selectListItems = customers.Select(c => new SelectListItem
            {
                Value = c.CustomerId.ToString(),
                Text = c.Name
            });
            //foreach (Customer cust in customers)
            //{
            //    SelectListItem selectListItem = new SelectListItem
            //    {
            //        Text = cust.Name,
            //        Value = cust.CustomerId.ToString(),
            //        Selected = cust.IsSelected.Equals(true) ? cust.IsSelected : false
            //    };
            //    //selectListItems.Add(selectListItem);
            //}
            ViewBag.CustomerId = selectListItems;
            return View("Cart");
        }

        [HttpPost]
        public ActionResult Calculate(FormCollection formCollection)
        {
            customers = customersService.GetCustomers();
            rebates = rebatesService.GetRebates();
            Session["Calc"] = Session["cart"];
            var item = (List<Item>)Session["Calc"];

            IEnumerable<SelectListItem> selectListItems = customers.Select(c => new SelectListItem
            {
                Value = c.CustomerId.ToString(),
                Text = c.Name
            });

            ViewBag.CustomerId = selectListItems;
            foreach (string key in formCollection.AllKeys)
            {
                if(string.IsNullOrEmpty(formCollection[key])) continue;
                int _key = ConvertKey(key, formCollection);
                Customer selCust = customers.Find(x => x.CustomerId == _key);
                Rebate rebateForCustomer = rebates.Find(r => r.RebateId == selCust.RebateId);
                if (rebateForCustomer == null)
                {
                    TempData["AlertMessage"] = "Customer must be chosen! you chose " + "selCust: " + selCust.Name + " with rebateId: " + selCust.RebateId;
                    continue;
                }
                Response.Write("Customer chosen = " + " ");
                Response.Write(selCust.Name);
                Response.Write("<br>");
                Response.Write("Rabate value = " + " ");
                Response.Write(rebateForCustomer.Amount * 100 + "%");
                Response.Write("<br>");
                Response.Write("Rabate of price = " + " ");
                Response.Write(rebateForCustomer.Amount * (item[0].Product.Price * item[0].Quantity));
                Response.Write("<br>");
            }

            //string val = formCollection["Customers"];
            //Response.Write(val);
            return View("Cart");
        }

        private int ConvertKey(string key, FormCollection formCollection)
        {
            try
            {
                return Convert.ToInt32(formCollection[key]);
            }
            catch (ArithmeticException arithmeticException)
            {
                throw new Exception(arithmeticException.Message);
            }
            catch (FormatException formatException)
            {
                TempData["AlertMessage"] = "Customer must be chosen! You chose: " + formCollection[key];
                throw new Exception($"Key was {key}", formatException);
            }
        }
    }
}