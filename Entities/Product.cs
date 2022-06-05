using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    
    public class Product:BaseEntity
    {
       
        public string Name { get; set; }

        public string? Brend { get; set; }

        public bool IsFeatured { get; set; }

        public decimal Rating { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public bool Available { get; set; }

        public decimal? Discount { get; set; }
        public decimal? TotalPrice { get; set; }

        public bool? IsDiscount { get; set; }

        public string PhotoUrl { get; set; }

        public virtual Category? Category { get; set; }
    }
}
