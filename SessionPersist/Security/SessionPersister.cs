using SessionPersist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionPersist.Security
{
    public class SessionPersister
    {
        static string accountSession = "objUser";

        public static Usuario usuario
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var sessionvar = HttpContext.Current.Session[accountSession];
                //HttpContext.Current.Session.Timeout = 50;
                if (sessionvar != null)
                {
                    return sessionvar as Usuario;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[accountSession] = value;
            }
        }
    }
}