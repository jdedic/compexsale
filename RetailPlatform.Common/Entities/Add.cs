using System;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.Common.Entities
{
    public class Add
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long ProfileId { get; set; }
        public Profile Profile { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImagePaths { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public double Quantity { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
