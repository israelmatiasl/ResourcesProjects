using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Pagination.ViewModel
{
    public class PaginationModel
    {
        public Int32 actualPage { get; set; }
        public Int32 totalItems { get; set; }
        public Int32 itemsPerPage { get; set; }
        public RouteValueDictionary QueryStringValues { get; set; }
    }
}