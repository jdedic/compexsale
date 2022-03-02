using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RetailPlatform.Common.Entities
{
    public class Email
    {
        [Key]
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public bool IsSent { get; set; }
        public DateTime? DateWhenEmailIsSent { get; set; }
    }
}
