using Getticket.Web.API.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{

    /// <summary>
    /// Модель для предоставления пользователю 
    /// логина и пароля для доступа на контроллер
    /// </summary>
    public class AuthModel
    {
        public AuthModel() { }

        public AuthModel(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

        [EmailAddress]
        public string Email { get; set; }
        [CustomPassword]
        public string Password { get; set; }
    }
}