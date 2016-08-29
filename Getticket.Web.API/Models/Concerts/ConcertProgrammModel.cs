using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Getticket.Web.API.Models.Events;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Программа концерта
    /// </summary>
    public class ConcertProgrammModel : BaseModel
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
        /// Участники <see cref="ActorModel"/>
        /// </summary>
        public virtual IEnumerable<ActorModel> Actors { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="EventModel"/>
        /// </summary>
        [Required]
        public int IdEvent { get; set; }

        /// <summary>
        /// Событие <see cref="EventModel"/>
        /// </summary>
        public virtual EventModel Event { get; set; }
    }
}
