using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class EventGenreLink : BaseEntity
    {
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Event"/>
        /// </summary>
        [Required]
        public int IdEvent { get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("IdEvent")]
        [JsonIgnore]
        public virtual Event Event { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="EventGenre"/>
        /// </summary>
        [Required]
        public int IdGenre { get; set; }

        /// <summary>
        /// Жанр <see cref="EventGenre"/>
        /// </summary>
        [ForeignKey("IdGenre")]
        [JsonIgnore]
        public virtual EventGenre Genre { get; set; }

        /// <summary>
        /// Основной
        /// </summary>
        public bool IsMain { get; set; }
    }
}
