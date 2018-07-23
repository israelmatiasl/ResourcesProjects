using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisplayTemplate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Person person = new Person() { name = "Israel", age = 22, birthdate = DateTime.Now, employee = true };

            ViewBag.person = person;
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

    public class Person
    {
        public String name { get; set; }
        public Int32 age { get; set; }
        public DateTime birthdate { get; set; }
        public Boolean employee { get; set; }
    }
}