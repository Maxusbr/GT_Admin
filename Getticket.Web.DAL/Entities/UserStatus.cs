using Getticket.Web.DAL.Enums;
using Newtonsoft.Json;
using System;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Статус пользователя в системе
    /// </summary>
    public class UserStatus : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UserStatus(){}

        /// <summary>
        /// Код статуса
        /// </summary>
        public UserStatusType Status { get; set; }

        /// <summary>
        /// Имя статуса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание статуса
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Время последнего обновления статуса
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// Ссыслка на пользователя
        /// </summary>
        [JsonIgnore]
        public User User { get; set; }
    }

}
