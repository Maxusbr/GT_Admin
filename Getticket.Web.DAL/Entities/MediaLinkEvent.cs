using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связи между сущностями <see cref="Entities.PersonMedia" /> и <see cref="Entities.Event" />
    /// </summary>
    public class MediaLinkEvent
    {
        /// <summary>
        /// Внешний ключ для сущности <see cref="Entities.PersonMedia"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdMedia { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonMedia"/>
        /// </summary>
        public virtual PersonMedia Media { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Event"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdEvent { get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        public virtual Event Event { get; set; }

    }
}
