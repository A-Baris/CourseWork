using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunlu")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre adı zorunlu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre(Tekrar) adı zorunlu")]
        [Compare("Password", ErrorMessage = "Şifreler uyumsuz!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email adı zorunlu")]
        [EmailAddress(ErrorMessage ="abc@abc şeklinde girmelisiniz")]
        public string Email { get; set; }
    }
}
