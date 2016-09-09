using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Программа концерта
    /// </summary>
    public class ConcertProgramm : BaseEntity
    {
        /// <summary>
        /// Дата начала концерта
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания концерта
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        /// Время начала концерта
        /// </summary>
        public TimeSpan TimeStart { get; set; }

        /// <summary>
        /// Время окончания концерта
        /// </summary>
        public TimeSpan TimeEnd { get; set; }

        /// <summary>
        /// Продолжительность концерта
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ссылка на плейлист
        /// </summary>
        public string MediaLink { get; set; }

        /// <summary>
        /// Участники <see cref="Entities.Actor"/>
        /// </summary>
        [JsonIgnore]
        public virtual IList<Actor> Actors { get; set; }

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
    }
}
