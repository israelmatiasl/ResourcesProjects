using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pagination.ViewModel.UserViewModel;
using Pagination.Models;
using System.Web.Routing;

namespace Pagination.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Int32 page = 1, String status = null, String role = null)
        {
            Int32 itemsPerPage = 4;
            ListUserViewModel obj = new ListUserViewModel();
            obj.Fill(page, itemsPerPage, status, role);
            
            return View(obj);
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