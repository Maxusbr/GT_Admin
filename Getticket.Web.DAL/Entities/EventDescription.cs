using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Сущность для описаний события
    /// </summary>
    public class EventDescription : BaseEntity
    {
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Event"/>
        /// </summary>
        [Required]
        public int IdEvent{ get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }

        /// <summary>
        /// Описание события
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="EventDescriptionType"/>
        /// </summary>
        [Required]
        public int IdType{ get; set; }

        /// <summary>
        /// Тип события <see cref="PersonDescriptionType"/>
        /// </summary>
        [ForeignKey("IdType")]
        public virtual PersonDescriptionType DescriptionType { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Статическое описание требуется?
        /// </summary>
        public bool RequiredStaticDescription { get; set; }

        /// <summary>
        /// Внешний ключ для схемы размещения
        /// </summary>
        public int? IdBlock { get; set; }

        /// <summary>
        /// Статическое описание
        /// </summary>
        public EventDescription StaticDescription { get; set; }

        /// <summary>
        /// размещение описания
        /// </summary>
        [ForeignKey("IdBlock")]
        public virtual PageBlock PageBlock { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.UserPageCategory"/>
        /// </summary>
        public int? IdUserPageCategory { get; set; }

        /// <summary>
        /// Источник
        /// </summary>
        [ForeignKey("IdUserPageCategory")]
        public virtual UserPageCategory UserPageCategory { get; set; }
    }
}
