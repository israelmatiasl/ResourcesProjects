using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore2Migration.Models
{
    public class StudentRequest
    {
        public String name { get; set; }
        public Int32 age { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String region { get; set; }
    }
}
