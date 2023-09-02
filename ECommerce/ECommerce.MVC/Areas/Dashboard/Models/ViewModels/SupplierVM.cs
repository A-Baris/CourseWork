using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Areas.Dashboard.Models.ViewModels
{
    public class SupplierVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Boş Geçilemez")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string ContactTitle { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string PhoneNumber { get; set; }
        
    }
}
