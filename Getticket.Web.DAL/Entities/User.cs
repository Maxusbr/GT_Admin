using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// User
    /// </summary>
    public class User : BaseEntity, IUser<int>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public User(){}

        /// <summary>
        /// Уникальное поле для IUser интерфейса
        /// фактически логин для пользователя
        /// хранится как Email в бд
        /// </summary>
        [Column("UserMail")]
        public string UserName { get; set; }

        /// <summary>
        /// Мобильный телефон (+79*********)
        /// Второе уникальное поле для пользователя,
        /// также является логином
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// Хеш пароля пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public DateTime? LastEnter { get; set; }

        /// <summary>
        /// Информация о пользователе
        /// Имя, Фамилия, Компания и т.д.virtual
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }

        /// <summary>
        /// Внешний ключ для роли пользователя
        /// </summary>
        public int AccessRoleId { get; set; }

        /// <summary>
        /// Роль доступа пользователя к API
        /// </summary>
        public virtual AccessRoles AccessRoles { get; set; }

        /// <summary>
        /// Статус пользователя в системе
        /// </summary>
        public virtual UserStatuses UserStatuses { get; set; }
    }
}
