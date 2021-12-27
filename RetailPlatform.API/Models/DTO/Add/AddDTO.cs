using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.API.Models.DTO
{
    public class AddDTO
    {
        public long Id { get; set; }
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string DateOfCreation { get; set; }
        public string ImagePaths { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
    }
}
