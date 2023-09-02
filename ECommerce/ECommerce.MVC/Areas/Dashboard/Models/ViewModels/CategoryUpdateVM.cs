using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Areas.Dashboard.Models.ViewModels
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı boş geçilemez!")]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
