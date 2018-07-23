using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore2Migration.Data
{
    public class Student
    {
        public Int32 id { get; set; }
        public String name { get; set; }
        public Int32 age { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public Region Region { get; set; }
    }
}
