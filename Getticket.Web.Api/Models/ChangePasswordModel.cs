using Getticket.Web.API.Attributes;
using System.ComponentModel.DataAnnotations;

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
        public bool SendCopyPassword { get; set; }
    }
}