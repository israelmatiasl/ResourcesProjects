using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextboxAutocomplete.Models;
using TextboxAutocomplete.ViewModel.PaisesViewModel;
using TextboxAutocomplete.ViewModel.CiudadesViewModel;

namespace TextboxAutocomplete.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AddEditCiudadViewModel obj = new AddEditCiudadViewModel();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Index(AddEditCiudadViewModel obj)
        {
            String name = obj.nombre;
            String pais = obj.pais;

            return View();
        }

        public ActionResult About()
        {
            ListCiudadesViewModel obj = new ListCiudadesViewModel();
            return View(obj);
        }


        [HttpPost]
        public ActionResult About(ListCiudadesViewModel obj)
        {
            Int32 paisId = obj.paisId;
            Int32 ciudadId = obj.provinciaId;

            return RedirectToAction("Contact", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult getProvincias(Int32 paisId)
        {
            ListCiudadesViewModel obj = new ListCiudadesViewModel();
            IQueryable<SelectCiudades> provincias = obj.Fill(paisId);

            return Json(provincias, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPaises(string name)
        {
            ListPaisesViewModel obj = new ListPaisesViewModel();
            IEnumerable<SelectPaises> paises = obj.Fill(name);
            List<String> toSend = paises.Select(x => x.nombre).ToList();

            return Json(toSend, JsonRequestBehavior.AllowGet);
        }
    }
}