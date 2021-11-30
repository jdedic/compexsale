﻿using RetailPlatform.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.Common.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public string ForgotPasswordToken { get; set; }
        public bool Active { get; set; }
        public string WorkingPosition { get; set; }
    }
}
