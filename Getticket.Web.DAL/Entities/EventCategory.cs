using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Сущность для категорий событий
    /// </summary>
    public class EventCategory : BaseEntity
    {
        /// <summary>
        /// Имя категории
        /// </summary>
        [MaxLength(300)]
        [Required]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }

        /// <summary>
        /// Описание категории
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="EventCategory"/>
        /// </summary>
        public int? IdParent{ get; set; }

        /// <summary>
        /// Тип события
        /// </summary>
        [ForeignKey("IdParent")]
        public virtual EventCategory ParentCategory { get; set; }
    }
}
