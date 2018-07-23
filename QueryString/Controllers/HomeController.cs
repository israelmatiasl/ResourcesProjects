using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueryString.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(String name, Int32? dni)
        {
            ViewBag.name = name;
            ViewBag.dni = dni;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}