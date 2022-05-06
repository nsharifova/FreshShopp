using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contact:BaseEntity
    {

        public string Email { get; set; }

        public string Phone { get; set; }
        public string Name { get; set; }
        public string Addess { get; set; }
        public string Message { get; set; }

     
    }
}
