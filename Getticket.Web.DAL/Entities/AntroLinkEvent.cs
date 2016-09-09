using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связи между сущностями <see cref="Entities.PersonAntro" /> и <see cref="Entities.Event" />
    /// </summary>
    public class AntroLinkEvent
    {
        /// <summary>
        /// Внешний ключ для сущности <see cref="Entities.PersonAntro"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdAntro { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonAntro"/>
        /// </summary>
        [JsonIgnore]
        public virtual PersonAntro Antro { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Event"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdEvent { get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        [JsonIgnore]
        public virtual Event Event { get; set; }

    }
}
