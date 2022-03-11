using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RetailPlatform.API.Models.DTO.HomePage
{
    public class AddsGrid
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<SelectListItem> FilteredCategories { get; set; }
        public string SelectedCategory { get; set; }
        public List<AddModel> Adds { get; set; }
        public long JobType { get; set; }
    }
}
