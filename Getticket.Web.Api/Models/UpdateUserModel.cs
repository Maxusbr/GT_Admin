using Getticket.Web.API.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель для обновления информации о пользователе
    /// </summary>
    public class UpdateUserModel
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [CustomPhone]
        public string Phone { get; set; }
    }
}