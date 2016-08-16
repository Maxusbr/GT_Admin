using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Лог изменения сущностей <see cref="Entities.Event" /> сущностями <see cref="Entities.User" />
    /// </summary>
    public class EventLog : BaseEntity
    {
        /// <summary>
        /// Содержание <see cref="Event" /> до изменения
        /// Обязательное поле
        /// </summary>
        [Required]
        public string ChengeFrom { get; set; }

        /// <summary>
        /// Содержание <see cref="Event" /> после изменения,
        /// Обязательное поле
        /// </summary>
        [Required]
        public string ChangeTo { get; set; }

        /// <summary>
        /// FK для <see cref="Entities.User" />
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Ссылка на изменившего <see cref="Entities.User" />
        /// </summary>
        
        public UserInfo User { get; set; }

        /// <summary>
        /// FK для <see cref="Entities.Event" />
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Ссылка на измененное <see cref="Entities.Event" />
        /// </summary>
        [ForeignKey("EventId")]
        public Event Event { get; set; }

        /// <summary>
        /// Ссылка на измененное свойство
        /// </summary>
        public int IdProperty { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime Date { get; set; }

        /// <see cref="LogType"/>
        public LogType Type { get; set; }
    }
}
