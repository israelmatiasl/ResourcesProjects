using jQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jQuery.ViewModel
{
    public class ListUsuarioViewModel
    {
        public IQueryable<Usuario> usuarios { get; set; }
        
        public ListUsuarioViewModel()
        {
            var db = new PaisesEntities();
            usuarios = db.Usuario.ToList().AsQueryable();
        }
    }
}