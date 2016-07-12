using Getticket.Web.API.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель для полючения аутентификации пользователя
    /// в LogonController по адресу api/logon
    /// </summary>
    public class LogonModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [CustomPhone]
        public string Phone { get; set; }
        [CustomPassword]
        public string Password { get; set; }
    }
}