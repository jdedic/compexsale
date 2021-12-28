using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RetailPlatform.API.Models.DTO
{
    public class SubCategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Izaberite kategoriju")]
        public string SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> FilteredCategories { get; set; }
    }
}
