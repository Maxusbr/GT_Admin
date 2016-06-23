using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель требуемая для создания 
    /// приглашения для нового пользователя
    /// </summary>
    public class SendInviteModel
    {
        /// <summary>
        /// Email адресс пользователя
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Внутренняя роль для доступа к API
        /// </summary>
        [Required]
        public int RoleId { get; set; }
    }
}