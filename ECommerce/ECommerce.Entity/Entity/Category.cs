using ECommerce.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entity.Entity
{
    public class Category:BaseClass
    {
        [MaxLength(255)]
        [Required]
        public string CategoryName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        //Mapping

        public virtual List<Product> Products { get; set; }
    }
}
