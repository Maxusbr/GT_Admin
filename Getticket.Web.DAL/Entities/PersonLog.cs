using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Лог изменения сущностей <see cref="Entities.Person" /> сущностями <see cref="Entities.User" />
    /// </summary>
    public class PersonLog : BaseEntity
    {
        /// <summary>
        /// Содержание <see cref="Entities.Person" /> до изменения
        /// Обязательное поле
        /// </summary>
        [Required]
        public string ChengeFrom { get; set; }

        /// <summary>
        /// Содержание <see cref="Entities.Person" /> после изменения,
        /// Обязательное поле
        /// </summary>
        [Required]
        public string ChangeTo { get; set; }

        /// <summary>
        /// FK для <see cref="Entities.UserInfo" />
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Ссылка на изменившего <see cref="Entities.User" />
        /// </summary>
        [ForeignKey("UserId")]
        public virtual UserInfo User { get; set; }
        /// <summary>
        /// FK для <see cref="Entities.Person" />
        /// </summary>
        public int IdPerson { get; set; }

        /// <summary>
        /// Ссылка на измененное <see cref="Entities.Person" />
        /// </summary>
        [ForeignKey("IdPerson")]
        public virtual Person Person { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Ссылка на измененное свойство
        /// </summary>
        public int IdProperty { get; set; }

        /// <see cref="LogType"/>
        public LogType Type { get; set; }
    }
}
