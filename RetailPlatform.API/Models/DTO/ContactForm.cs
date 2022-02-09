using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.API.Models.DTO
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Unesite ime i prezime.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Unesite email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Unesite poruku.")]
        public string Content { get; set; }
    }
}
