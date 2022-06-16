using System;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.Common.Entities
{
    public class Add
    {
        [Key]
        public long Id { get; set; }
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public long ProfileId { get; set; }
        public ProfileModel Profile { get; set; }
        public string ImgUrl1 { get; set; }
        public string ImgUrl2 { get; set; }
        public string ImgUrl3 { get; set; }
        public string ImgUrl4 { get; set; }
        public long SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public double Quantity { get; set; }
        public bool Active { get; set; }
        public bool Confirmed { get; set; }
        public bool IsComepnsation { get; set; }
        public bool IsDiscontSale { get; set; }
        public bool IsExchange { get; set; }
        public bool IsMailSent { get; set; }
        public bool IsVisible { get; set; }
        public bool IsSold { get; set; }
        public string ReasonForRefusal { get; set; }
        public DateTime CreationDate { get; set; }
        public long UnitTypeId { get; set; }
        public UnitType UnitType { get; set; }
        public long JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public float? Price { get; set; }
        public long? SubCategoryId1 { get; set; }
        public long? SubCategoryId2 { get; set; }
        public long? SubCategoryId3 { get; set; }
    }
}
