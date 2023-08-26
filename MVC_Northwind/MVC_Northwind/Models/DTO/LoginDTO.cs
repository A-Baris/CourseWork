using System.ComponentModel.DataAnnotations;

namespace MVC_Northwind.Models.DTO
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "Email adı zorunluı")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre adı zorunluı")]
        public string Password { get; set; }

      
    }
}
