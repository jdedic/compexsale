using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO
{
    public class EmailForCollaboration
    {
        [Required(ErrorMessage ="Molimo Vas unesti email adrese")]
        public string Emails { get; set; }
    }
}
