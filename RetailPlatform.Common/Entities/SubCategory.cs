﻿using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.Common.Entities
{
    public class SubCategory
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
