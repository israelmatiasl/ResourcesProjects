using SessionPersist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionPersist.ViewModel.Account
{
    public class AccountSessionViewModel
    {
        public String username { get; set; }
        public String password { get; set; }

        public Usuario findUser(String username)
        {
            var db = new PaisesEntities();
            return db.Usuario.Where(x=>x.username == username).FirstOrDefault();
        }
    }
}