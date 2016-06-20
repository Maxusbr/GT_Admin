using Getticket.Web.API.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    public class RegisterUserModel
    {
        [Required]public string Name { get; set; }
        [Required]public string LastName { get; set; }
        [Required]public string Company { get; set; }
        [Required]public string Position { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [CustomPhoneAttribute]
        public string Phone { get; set; }
        [MaxLength(20), MinLength(5)]
        public string Password { get; set; }
        public bool GeneratePassword { get; set; }
        public bool NotSendWelcome { get; set; }
        [Required]public int RoleId { get; set; }
    }
}