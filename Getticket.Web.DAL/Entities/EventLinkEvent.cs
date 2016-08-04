using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связи между сущностями <see cref="Entities.Event" /> и <see cref="Entities.Event" />
    /// </summary>
    public class EventLinkEvent : BaseEntity
    {
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Event"/>
        /// </summary>
        [Required]
        public int id_Event { get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("id_Event")]
        public virtual Event Event { get; set; }

        /// <summary>
        /// Характеристика связи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.EventConnectionType"/>
        /// </summary>
        [Required]
        public int id_ConnectionType { get; set; }

        /// <summary>
        /// Тип связи <see cref="Entities.EventConnectionType"/>
        /// </summary>
        [ForeignKey("id_ConnectionType")]
        public virtual EventConnectionType EventConnectionType { get; set; }

        /// <summary>
        /// Внешний ключ для связи между сущностями <see cref="Entities.Event"/>
        /// </summary>
        public int? id_EventConnectTo { get; set; }

        /// <summary>
        /// <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("id_EventConnectTo")]
        public virtual Event EventConnectTo { get; set; }
    }
}
