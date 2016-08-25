using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagEventLink
    {
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Tag"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="Entities.Event"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdEvent { get; set; }

        /// <summary>
        /// <see cref="Entities.TagEvent"/>
        /// </summary>
        [ForeignKey("IdTag")]
        public virtual TagEvent Tag { get; set; }

        /// <summary>
        /// <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }

    }
}
