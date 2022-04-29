using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO.Add
{
    public class EditAddDTO
    {
        public long Id { get; set; }
        public string UniqueId { get; set; }
        [Required(ErrorMessage = "Unesite Naziv")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Unesite Opis")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Unesite Mesto")]
        public string Place { get; set; }
        [Required(ErrorMessage = "Unesite Količinu")]
        public double Quantity { get; set; }
        public IEnumerable<SelectListItem> JobTypes { get; set; }

        public string SelectedJobType { get; set; }
        public bool Active { get; set; }
        public bool Confirmed { get; set; }
        public bool IsMailSent { get; set; }
        public string ReasonForRefusal { get; set; }
        public IFormFile FirstImg { get; set; }
        public IFormFile SecondImg { get; set; }
        public IFormFile ThirdImg { get; set; }
        public IFormFile FourthImg { get; set; }
        public string ImgUrl1 { get; set; }
        public string ImgUrl2 { get; set; }
        public string ImgUrl3 { get; set; }
        public string ImgUrl4 { get; set; }
        public IEnumerable<SelectListItem> FilteredCategories { get; set; }
        public string SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Units { get; set; }
        public string SelectedUnit { get; set; }
        public bool IsComepnsation { get; set; }
        public bool IsDiscontSale { get; set; }
        public bool IsExchange { get; set; }
        public float? Price { get; set; }
        public string SelectedCategory1 { get; set; }
        public string SelectedCategory2 { get; set; }
        public string SelectedCategory3 { get; set; }
        public string CreatedBy { get; set; }
    }
}
