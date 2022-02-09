using System;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO
{
    public class ProductPreviewDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl1 { get; set; }
        public string ImgUrl2 { get; set; }
        public string ImgUrl3 { get; set; }
        public string ImgUrl4 { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public double Quantity { get; set; }
        public string Active { get; set; }
        public DateTime CreationDate { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        public string Unit { get; set; }
        public string IsComepnsation { get; set; }
        public string IsDiscontSale { get; set; }
        public string IsExchange { get; set; }
        [Required(ErrorMessage = "Unesite ime i prezime.")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "Unesite email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Unesite poruku.")]
        public string Content { get; set; }
    }
}
