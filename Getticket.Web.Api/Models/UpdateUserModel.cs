using Getticket.Web.API.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель для обновления информации о пользователе
    /// </summary>
    public class UpdateUserModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [CustomPhone]
        public string Phone { get; set; }

        public bool? SendPassword { get; set; }

        public bool? PasswordChanged { get; set; }

        public string OldPassword { get; set; }

        [CustomPassword]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

        public bool? Lock { get; set; }
    }
}