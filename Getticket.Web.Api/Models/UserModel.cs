using Getticket.Web.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель пользователя (используется для ответов API)
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserStatusType Status { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
    }
}