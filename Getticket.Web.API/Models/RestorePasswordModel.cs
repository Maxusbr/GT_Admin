using Getticket.Web.API.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель для смены пароля
    /// </summary>
    public class RestorePasswordModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [CustomPhone]
        public string Phone { get; set; }
    }
}