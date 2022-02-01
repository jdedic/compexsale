using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.Common.Entities
{
    public class ProfileCategory
    {
        [Key]
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public ProfileModel Profile { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
