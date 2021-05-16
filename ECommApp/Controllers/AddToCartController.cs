using ECommApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommApp.Controllers
{
    [Authorize]
    public class AddToCartController : Controller
    {
        public ActionResult Add(Product product)
        {
            if (Session["cart"] == null)
            {
                List<Product> li = new List<Product>();

                li.Add(product);
                Session["cart"] = li;
                ViewBag.cart = li.Count();

                Session["count"] = 1;
            }
            else
            {
                List<Product> li = (List<Product>)Session["cart"];
                
                if (!li.Any(item => item.Id ==product.Id)){
                    li.Add(product);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                } 
            }
            return RedirectToAction("UserIndex", "Products");
        }
        public ActionResult Myorder()
        {
            return View((List<Product>)Session["cart"]);
        }
        public ActionResult OrderConfirmation()
        {
            Session["cart"] = null;
            Session["count"] = 0;
            TempData["Message"] = "Your Order has been Saved Successfully ";
            return View();
        }

        public ActionResult Remove(Product product)
        {
            List<Product> li = (List<Product>)Session["cart"];
            li.RemoveAll(x => x.Id == product.Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
        }
    }
}