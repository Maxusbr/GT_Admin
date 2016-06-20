using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    public class AuthModel
    {
        public AuthModel() { }

        public AuthModel(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }


        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}