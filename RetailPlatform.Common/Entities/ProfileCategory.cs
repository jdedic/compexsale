using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RetailPlatform.Common.Entities
{
    public class ProfileCategory
    {
        [Key]
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public Profile Profile { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
