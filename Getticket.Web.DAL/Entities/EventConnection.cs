using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связи между сущностями <see cref="Entities.Event" /> и <see cref="Entities.Person" />
    /// </summary>
    public class EventConnection : BaseEntity
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
        [JsonIgnore]
        public virtual Event Event { get; set; }

        /// <summary>
        /// Характеристика связи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.ConnectionType"/>
        /// </summary>
        [Required]
        public int id_ConnectionType { get; set; }

        /// <summary>
        /// Тип связи <see cref="Entities.ConnectionType"/>
        /// </summary>
        [ForeignKey("id_ConnectionType")]
        [JsonIgnore]
        public virtual ConnectionType ConnectionType { get; set; }

        /// <summary>
        /// Внешний ключ для связи между сущностями <see cref="Entities.Person"/> и <see cref="Entities.Event"/>
        /// </summary>
        public int? id_Person { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Person")]
        [JsonIgnore]
        public virtual Person Person { get; set; }

        /// <summary>
        /// Внешний ключ для связи между сущностями <see cref="Entities.Event"/>
        /// </summary>
        public int? id_EventConnectTo { get; set; }

        /// <summary>
        /// <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("id_EventConnectTo")]
        [JsonIgnore]
        public virtual Event EventConnectTo { get; set; }
    }
}
