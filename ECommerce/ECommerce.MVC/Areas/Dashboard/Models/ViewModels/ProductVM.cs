using ECommerce.Entity.Entity;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Areas.Dashboard.Models.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ürün adı boş geçilemez")]
        public string ProductName { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Ürün fiyatı boş geçilemez")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Ürün stok boş geçilemez")]
        public short UnitsInStock { get; set; }
        [Required(ErrorMessage ="Ürün Image Path boş geçilemez")]
        public string ImagePath { get; set; }
   
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }




    }
}
