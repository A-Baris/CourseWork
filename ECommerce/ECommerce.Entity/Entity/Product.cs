using ECommerce.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entity.Entity
{
    public class Product:BaseClass
    {

        [MaxLength(255)]
        public string ProductName { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }

        [MaxLength(255)]
        public string ImagePath { get; set; }


        //Mapping
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }


    }
}
