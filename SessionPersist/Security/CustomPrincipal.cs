using SessionPersist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SessionPersist.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public Usuario usuario;

        public IIdentity Identity { get; set; }

        public CustomPrincipal(Usuario _account)
        {
            usuario = _account;
            Identity = new GenericIdentity(_account.username);
        }

        public bool IsInRole(string role)
        {
            return role.Contains(usuario.role);
        }
    }
}