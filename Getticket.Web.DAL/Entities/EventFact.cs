using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Факты
    /// </summary>
    public class EventFact : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public EventFact(){}

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Event"/>
        /// </summary>
        [Required]
        public int id_Event { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.EventFactType"/>
        /// </summary>
        [Required]
        public int id_FactType { get; set; }

        /// <summary>
        /// Текст факта
        /// </summary>
        public string FactText { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Источник
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Event")]
        [JsonIgnore]
        public virtual Event Event { get; set; }

        /// <summary>
        /// <see cref="EventFactType"/>
        /// </summary>
        [ForeignKey("id_FactType")]
        [JsonIgnore]
        public virtual EventFactType FactType { get; set; }
    }
}
