using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO
{
    public class EmailForCollaboration
    {
        [Required(ErrorMessage ="Molimo Vas unesite email adrese")]
        public string Emails { get; set; }
    }
}
