using Microsoft.AspNetCore.Mvc.Rendering;
using RetailPlatform.API.Helper;
using RetailPlatform.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Models.DTO
{
    public class EditUserDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Unesite Ime")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Unesite Prezime")]
        public string LastName { get; set; }
        [Display(Name = "Funkcija")]
        [Required(ErrorMessage = "Izaberite funkciju")]
        public string SelectedRole { get; set; }
        [Required(ErrorMessage = "Unesite adresu")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Unesite grad")]
        public string City { get; set; }
        [Required(ErrorMessage = "Unesite e-mail")]
        [UserEmailValidator(ErrorMessage = "E-mail već postoji")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Molimo vas unesite ispravan e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Unesite poštanski kod")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Unesite broj telefona")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Unesite šifru")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
        public string WorkingPosition { get; set; }
        public IEnumerable<SelectListItem> FilteredRoleTypes { get; set; }
        public List<Role> RoleTypes { get; set; }
    }
}
