using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Сущность для типа описаний событий
    /// </summary>
    public class EventDescriptionType : BaseEntity
    {
        /// <summary>
        /// Имя категории
        /// </summary>
        [MaxLength(200)]
        [Required]
        [Index("NameIndex", Order = 1, IsUnique = true)]
        public string Name { get; set; }

        /// <summary>
        /// Подробнее
        /// </summary>
        [MaxLength(200)]
        [Required]
        [Index("NameIndex", Order = 2, IsUnique = true)]
        public string Detail { get; set; }

        public DescriptionTypes Type { get; set; }
    }
}
