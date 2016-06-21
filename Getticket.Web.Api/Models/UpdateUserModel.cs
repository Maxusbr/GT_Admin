using Getticket.Web.API.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [CustomPhoneAttribute]
        public string Phone { get; set; }
        public bool SendPassword { get; set; }
        public bool PasswordChanged { get; set; }
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [MaxLength(20), MinLength(5)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool Locked { get; set; }
    }
}