using ECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Entity
{
    public  class Product:BaseClass
    {
        [MaxLength(255)]
        public string ProductName { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        [MaxLength(255)]
        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
