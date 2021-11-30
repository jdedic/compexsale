using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RetailPlatform.Common.Entities
{
    public class Profile
    {
        [Key]
        public long Id { get; set; }
        public bool LegalEntity { get; set; }
        //if profile is legal entity we need next information
        public string CompanyName { get; set; }
        public string PIB { get; set; }
        public string IdentityNumber { get; set; }
        //contact person if profile is legal entity
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        //if it is not legal entity
        public string JMBG { get; set; }
        //unique email
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsVendor { get; set; }
        public bool IsCustomer { get; set; }
        public bool Active { get; set; }
    }
}
