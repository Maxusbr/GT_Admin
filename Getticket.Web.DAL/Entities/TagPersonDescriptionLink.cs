using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagPersonDescriptionLink
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TagPersonDescriptionLink(){}

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Tag"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="PersonDescription"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdDescription { get; set; }

        /// <summary>
        /// <see cref="Entities.Tag"/>
        /// </summary>
        [ForeignKey("IdTag")]
        public virtual Tag Tag { get; set; }

        /// <summary>
        /// <see cref="PersonDescription"/>
        /// </summary>
        [ForeignKey("IdDescription")]
        public virtual PersonDescription Description { get; set; }

    }
}
