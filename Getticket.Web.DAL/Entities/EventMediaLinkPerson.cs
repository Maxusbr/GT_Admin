using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связи между сущностями <see cref="Entities.EventMedia" /> и <see cref="Entities.Event" />
    /// </summary>
    public class EventMediaLinkPerson
    {

        /// <summary>
        /// Внешний ключ для сущности <see cref="Entities.EventMedia"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdMedia { get; set; }

        /// <summary>
        /// <see cref="Entities.EventMedia"/>
        /// </summary>
        public virtual EventMedia Media { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Person"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdPerson { get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
