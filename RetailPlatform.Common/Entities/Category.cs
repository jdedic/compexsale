using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.Common.Entities
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsAssigned { get; set; }
    }
}
