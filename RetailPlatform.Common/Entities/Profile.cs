using System;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.Common.Entities
{
    public class ProfileModel
    {
        [Key]
        public long Id { get; set; }
        public bool LegalEntity { get; set; }
        public string CompanyName { get; set; }
        public string PIB { get; set; }
        public string IdentityNumber { get; set; }
        public string FullName { get; set; }
        public string Telephone { get; set; }
        public string JMBG { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsVendor { get; set; }
        public bool IsCustomer { get; set; }
        public bool Active { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
