using System.ComponentModel.DataAnnotations;

namespace MVC_Northwind.Models.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunlu")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre adı zorunluı")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre(Tekrar) adı zorunluı")]
        [Compare("Password", ErrorMessage = "Şifreler uyumsuz!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email adı zorunluı")]
        public string Email { get; set; }
    }
}
