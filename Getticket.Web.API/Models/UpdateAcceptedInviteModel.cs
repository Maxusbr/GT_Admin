using Getticket.Web.API.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель для обновления информации приглашения
    /// при принятии приглашения пользователем
    /// </summary>
    public class UpdateAcceptedInviteModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [CustomPhone]
        public string Phone { get; set; }

        // Пароль проверяем в сервисе, т.к. он может сгенерен быть если
        // GeneratePassword = true
        public string Password { get; set; }

        [Required]
        public bool GeneratePassword { get; set; }
    }
}