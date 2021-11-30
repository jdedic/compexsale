using RetailPlatform.API.Helper;
using RetailPlatform.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Unesite Ime")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Unesite Prezime")]
        public string LastName { get; set; }
        public Role Role { get; set; }
        [Display(Name = "Funkcija")]
        [Required(ErrorMessage = "Izaberite funkciju")]
        public string SelectedRole { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Unesite e-mail")]
        [UserEmailValidator(ErrorMessage = "E-mail već postoji")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Molimo vas unesite ispravan e-mail")]
        public string Email { get; set; }
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Unesite broj telefona")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Unesite ispravan broj telefona")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Unesite šifru")]
        public string Password { get; set; }
        public string WorkingPosition { get; set; }
    }
}
