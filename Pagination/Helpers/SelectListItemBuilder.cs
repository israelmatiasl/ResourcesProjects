using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagination.Helpers
{
    public static class SelectListItemBuilder
    {
        public static IEnumerable<SelectListItem> buildListStatus()
        {
            IEnumerable<SelectListItem> selectList = new List<SelectListItem>
            {
                new SelectListItem{ Value = "ACTIVO", Text = "ACTIVO" },
                new SelectListItem{ Value = "INACTIVO", Text = "INACTIVO" }
            };
            return selectList;
        }

        public static IEnumerable<SelectListItem> buildListRoles()
        {
            IEnumerable<SelectListItem> selectList = new List<SelectListItem>
            {
                new SelectListItem{ Value = "ADMINISTRADOR", Text = "ADMINISTRADOR" },
                new SelectListItem{ Value = "DOCENTE", Text = "DOCENTE" },
                new SelectListItem{ Value = "ALUMNO", Text = "ALUMNO" }
            };
            return selectList;
        }
    }
}