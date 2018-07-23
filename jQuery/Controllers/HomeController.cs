using jQuery.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jQuery.Models;

namespace jQuery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            ListUsuarioViewModel obj = new ListUsuarioViewModel();
            return View(obj);
        }

        [HttpPost]
        public JsonResult deleteUser(Int32 id)
        {
            var db = new PaisesEntities();
            var response = new Response();
            try
            {
                Usuario usuario = db.Usuario.Find(id);
                usuario.status = "INACTIVO";
                db.SaveChanges();
                response.ok = true;
                response.message = "Se eliminó con éxito";
            }
            catch
            {
                response.ok = false;
                response.message = "Ocurrió un problema";
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Duplicar(Int32 numero)
        {
            Int32 result = numero * 2;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult CargarDatos()
        {
            List<Persona> personas = new List<Persona>()
            {
                new Persona { nombre = "Israel", edad = 22 },
                new Persona { nombre = "Sofía", edad = 24 },
                new Persona { nombre = "Kathy", edad = 20 },
                new Persona { nombre = "Ingrid", edad = 21 },
            };

            return PartialView("_Personas", personas);
        }
    }

    public class Persona
    {
        public String nombre { get; set; }
        public Int32 edad { get; set; }
    }

    public class Response
    {
        public Boolean ok { get; set; }
        public String message { get; set; }
    }
}