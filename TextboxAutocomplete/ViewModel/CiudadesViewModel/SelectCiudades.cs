using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextboxAutocomplete.ViewModel.CiudadesViewModel
{
    public class SelectCiudades
    {
        public Int32 id { get; set; }
        public String nombre { get; set; }

        public SelectCiudades(Int32 id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}