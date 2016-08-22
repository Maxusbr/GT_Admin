using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagEventMediaLink
    {
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Tag"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="EventMedia"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdMedia { get; set; }

        /// <summary>
        /// <see cref="Entities.Tag"/>
        /// </summary>
        [ForeignKey("IdTag")]
        public virtual Tag Tag { get; set; }

        /// <summary>
        /// <see cref="EventMedia"/>
        /// </summary>
        [ForeignKey("IdMedia")]
        public virtual EventMedia Media { get; set; }

    }
}
