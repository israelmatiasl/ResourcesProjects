using SessionPersist.Models;
using SessionPersist.Security;
using SessionPersist.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionPersist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(Roles = "ADMINISTRADOR")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [CustomAuthorize(Roles = "DOCENTE")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            AccountSessionViewModel obj = new AccountSessionViewModel();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Login(AccountSessionViewModel obj)
        {
            var db = new PaisesEntities();
            var usuario = new Usuario();
            var response = default(ActionResult);
            try
            {
                usuario = db.Usuario.Where(x => x.username == obj.username && x.password == obj.password).FirstOrDefault();
                if(usuario == null)
                {
                    response = View(obj);
                }
                else
                {
                    SessionPersister.usuario = usuario;
                    response = RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                response = View(obj);
            }

            return response;
        }

        //[HttpPost]
        public ActionResult Signout()
        {
            Session.Clear();
            Session.Abandon();
            
            return RedirectToAction("Index", "Home");
        }

    }
}