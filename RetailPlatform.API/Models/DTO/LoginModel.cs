using RetailPlatform.API.Helper;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Unesite korisničko ime!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Unesite šifru!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Unesite e-mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Molimo vas unesite ispravan e-mail")]
        public string Email { get; set; }
    }
}
