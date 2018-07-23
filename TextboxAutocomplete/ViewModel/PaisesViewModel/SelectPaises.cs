using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextboxAutocomplete.ViewModel.PaisesViewModel
{
    public class SelectPaises
    {
        public Int32 id { get; set; }
        public String nombre { get; set; }


        public SelectPaises(Int32 id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}