using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextboxAutocomplete.Models;

namespace TextboxAutocomplete.ViewModel.PaisesViewModel
{
    public class ListPaisesViewModel
    {
        List<Pais> paises { get; set; }
        List<SelectPaises> _paises { get; set; }
        public ListPaisesViewModel() { }

        public List<SelectPaises> Fill(String name_pais)
        {
            var db = new PaisesEntities();
            _paises = (db.Pais.Where(x => x.nombre.Contains(name_pais)).ToList()).Select(x => new SelectPaises(x.id, x.nombre)).ToList();
            return _paises;
        }
    }
}