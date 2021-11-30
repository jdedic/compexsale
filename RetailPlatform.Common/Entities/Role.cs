using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.Common.Entities
{
    public class Role
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
