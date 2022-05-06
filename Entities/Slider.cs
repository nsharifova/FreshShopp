using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Slider:BaseEntity
    {

        public string PhotoUrl { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
        public bool IsDeleted { get; set; }

    }
}
