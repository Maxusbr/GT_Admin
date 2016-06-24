using Getticket.Web.API.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель для смены пароля
    /// </summary>
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }

        [Required]
        [CustomPassword]
        public string NewPassword { get; set; }
        [Required]
        bool SendCopyPassword { get; set; }
    }
}