using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.Common.Entities
{
    public class CategorySubCategory
    {
        [Key]
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public long SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
