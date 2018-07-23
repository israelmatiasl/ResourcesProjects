using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore2Migration.Data
{
    public class Region
    {
        public Int32 id { get; set; }
        public String name { get; set; }

        [ForeignKey("Student")]
        public Int32 studentId { get; set; }
    }
}
