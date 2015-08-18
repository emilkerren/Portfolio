using Rexor.DAL;
using Rexor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rexor.Controllers
{
    public class ShoppingCartController : Controller
    {
        private BusinessLayer productsBL = new BusinessLayer();
        private List<Product> shoppingProducts = new List<Product>();
        private List<Customer> customers = new List<Customer>();
        private List<Rebate> rebates = new List<Rebate>();
        //private
        // GET: ShoppingCart
        public ActionResult Index()
        {
           
            return View();
        }
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if(cart[i].Product.ProductId == id){

                    return i;
                }
            }
                return -1;
        }
        
        public ActionResult OrderNow(int id, int quantity)
        {
            if(Session["cart"] == null)
            {
                shoppingProducts = productsBL.GetProducts();
                List<Item> cart = new List<Item>();
                cart.Add(new Item(shoppingProducts.Find(x => x.ProductId == id), quantity));
                Session["cart"] = cart;
            }
            customers = productsBL.GetCustomers();
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
            customers = productsBL.GetCustomers();
            rebates = productsBL.GetRebates();
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
                int _key = Convert.ToInt32(formCollection[key]);
                Customer selCust = customers.Find(x => x.CustomerId == _key);
                Rebate rebateForCustomer = rebates.Find(r => r.RebateId == selCust.RebateId);
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
    }
}