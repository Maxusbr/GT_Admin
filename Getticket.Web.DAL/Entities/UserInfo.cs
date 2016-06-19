using System;

namespace Getticket.Web.DAL.Entities
{
    public class UserInfo : BaseEntity
    {
        public UserInfo(){}

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Должность в компании
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Мобильный телефон (+79*********)
        /// </summary>
        public string Phone { get; set; }

        public User User { get; set; }
    }
}
