using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return RedirectToAction("UserIndex", "Products");
            }
        }
    }
}