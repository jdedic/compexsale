using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO.Add
{
    public class CreateRequestDTO
    {
        [Required(ErrorMessage = "Unesite Naziv")]
        public string Name { get; set; }
        public string DateOfCreation { get; set; }
        [Required(ErrorMessage = "Unesite Opis")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Unesite Mesto")]
        public string Place { get; set; }
        public string CreatedBy { get; set; }
        public IEnumerable<SelectListItem> FilteredCategories { get; set; }
        [Display(Name = "Kategorija")]
        [Required(ErrorMessage = "Izaberite kategoriju")]
        public string SelectedCategory { get; set; }
        public long ProfileId { get; set; }
        public IEnumerable<SelectListItem> FilteredEntities { get; set; }
        public string SelectedEntity { get; set; }
        public bool IsLegalEntity { get; set; }

    }
}
