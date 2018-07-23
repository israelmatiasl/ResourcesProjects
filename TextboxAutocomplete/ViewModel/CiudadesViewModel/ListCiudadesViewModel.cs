using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextboxAutocomplete.Models;
using TextboxAutocomplete.ViewModel.PaisesViewModel;

namespace TextboxAutocomplete.ViewModel.CiudadesViewModel
{
    public class ListCiudadesViewModel
    {
        public IQueryable<SelectPaises> paises { get; set; }
        public IQueryable<SelectCiudades> ciudades { get; set; }
        public String provincia { get; set; }
        public Int32 paisId { get; set; }
        public Int32 provinciaId { get; set; }

        public ListCiudadesViewModel() {

            var db = new PaisesEntities();
            paises = (db.Pais.ToList()).Select(x => new SelectPaises(x.id, x.nombre)).ToList().AsQueryable();
        }

        public IQueryable<SelectCiudades> Fill(Int32 paisId)
        {
            var db = new PaisesEntities();
            ciudades = (db.Provincia.Where(x => x.paisId == paisId).ToList())
                .Select(x => new SelectCiudades(x.id, x.nombre)).ToList().AsQueryable();
            return ciudades;
        }
    }
}