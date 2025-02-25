﻿using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO
{
    public class EditPrivateAccountDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Unesite ime i prezime")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Unesite telefon")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Unesite JMBG")]
        public string JMBG { get; set; }
        [Required(ErrorMessage = "Unesite e-mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Molimo vas unesite ispravan e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Unesite adresu")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Unesite grad")]
        public string City { get; set; }
        //[Required(ErrorMessage = "Unesite državu")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Unesite poštanski broj")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Unesite šifru")]
        public string Password { get; set; }
        public bool Active { get; set; }
        public bool LegalEntity { get; set; }
        public bool IsVendor { get; set; }
        public bool AgreeWithTermsAndConditions { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }
}
