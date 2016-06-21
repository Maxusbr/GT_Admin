using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    public class User : BaseEntity, IUser<int>
    {
        public User(){}

        /// <summary>
        /// Уникальное поле для IUser интерфейса
        /// фактически логин для пользователя
        /// хранится как Email в бд
        /// </summary>
        [Column("Email")]
        public string UserName { get; set; }
      
        /// <summary>
        /// Хеш пароля пользователя
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Дата последнего вызова 
        /// методов контроллера
        /// </summary>
        public DateTime? LastEnter { get; set; }

        /// <summary>
        /// Информация о пользователе
        /// Имя, Фамилия, Телефон, Компания и т.д.virtual
        /// </summary>
        
        public virtual UserInfo UserInfo { get; set; }

        /// <summary>
        /// Роль доступа пользователя к API
        /// </summary>
        public int AccessRoleId { get; set; }
        
        public virtual AccessRole AccessRole { get; set; }

        /// <summary>
        /// Статус пользователя в системе
        /// </summary>
       
        public virtual UserStatus UserStatus { get; set; }
    }
}
