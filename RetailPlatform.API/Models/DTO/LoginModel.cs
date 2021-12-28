using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Unesite korisničko ime!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Unesite šifru!")]
        public string Password { get; set; }
    }
}
