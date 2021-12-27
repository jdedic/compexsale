using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Unesite naziv kategorije")]
        public string Name { get; set; }
    }
}
