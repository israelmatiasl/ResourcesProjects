using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Pagination.Helpers;
using Pagination.Models;

namespace Pagination.ViewModel.UserViewModel
{
    public class ListUserViewModel : PaginationModel
    {
        public IQueryable<Usuario> usuarios { get; set; }

        //Filter
        public IEnumerable<SelectListItem> listStatus { get; set; }
        public IEnumerable<SelectListItem> listRoles { get; set; }
        public String status { get; set; }
        public String role { get; set; }

        public ListUserViewModel()
        {
            this.listStatus = SelectListItemBuilder.buildListStatus();
            this.listRoles = SelectListItemBuilder.buildListRoles();
        }

        public void Fill(Int32 page, Int32 itemsPerPage, String status = null, String role = null)
        {
            var db = new PaisesEntities();
            this.QueryStringValues = new RouteValueDictionary();

            var predicate = PredicateBuilder.True<Usuario>();
            if (!String.IsNullOrEmpty(role))
            {
                predicate = predicate.And(c => c.role == role);
                this.status = status;
            }
            if (!String.IsNullOrEmpty(status))
            {
                predicate = predicate.And(c => c.status == status);
                this.role = role;
            }

            this.usuarios = db.Usuario.Where(predicate)
                                      .OrderBy(x => x.id)
                                      .Skip((page - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .ToList().AsQueryable();


            this.totalItems = db.Usuario.Where(predicate).Count();
            this.actualPage = page;
            this.itemsPerPage = itemsPerPage;
            this.QueryStringValues["status"] = status;
            this.QueryStringValues["role"] = role;
        }
    }
    
}