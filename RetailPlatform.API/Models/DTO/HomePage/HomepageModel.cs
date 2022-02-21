using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RetailPlatform.API.Models.DTO.HomePage
{
    public class HomepageModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<SelectListItem> FilteredCategories { get; set; }
        public string SelectedCategory { get; set; }
        public List<AddModel> Adds { get; set; }
    }

    public class AddModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PublicationDate { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }

}
