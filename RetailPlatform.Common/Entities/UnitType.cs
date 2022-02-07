using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RetailPlatform.Common.Entities
{
    public class UnitType
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
