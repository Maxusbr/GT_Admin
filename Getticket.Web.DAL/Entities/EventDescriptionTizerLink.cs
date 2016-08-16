using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Описание
    /// </summary>
    public class EventDescriptionTizerLink
    {
        /// <summary>
        /// Внешний ключ для тизера
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdTizer { get; set; }

        /// <summary>
        /// Внешний ключ для статического описания
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdStaticDescription { get; set; }

        /// <summary>
        /// <see cref="Entities.EventDescription"/>
        /// </summary>
        //[ForeignKey("IdTizer")]
        public virtual EventDescription Tizer { get; set; }

        /// <summary>
        /// Статическое описание
        /// </summary>
        //[ForeignKey("IdStaticDescription")]
        public virtual EventDescription Description { get; set; }
    }
}
