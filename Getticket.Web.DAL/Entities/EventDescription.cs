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
        /// Тип события <see cref="EventDescriptionType"/>
        /// </summary>
        [ForeignKey("IdType")]
        public virtual EventDescriptionType DescriptionType { get; set; }
    }
}
