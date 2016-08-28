using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Сущность для хранения событий
    /// </summary>
    public class Event : BaseEntity
    {
        /// <summary>
        /// Имя события
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание события
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Мероприятие или Событие, true - Мероприятие
        /// </summary>
        public bool IsReallyEvent { get; set; }

        /// <summary>
        /// Дата начала продаж (билетов?)
        /// </summary>
        public DateTime? DateStartSold { get; set; }

        /// <summary>
        /// Дата окончания продаж (билетов?)
        /// </summary>
        public DateTime? DateStopSold { get; set; }

        /// <summary>
        /// Дата события
        /// </summary>
        public DateTime? EventDate { get; set; }

        /// <summary>
        /// Дата до которой можно вернуть билет
        /// </summary>
        public DateTime? TicketReturn { get; set; }

        /// <summary>
        /// Опубликовано
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Возрастное ограничение
        /// </summary>
        public int AgeLimit { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="EventCategory"/>
        /// </summary>
        [Required]
        public int IdCategory { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Company"/>
        /// </summary>
        public int? IdCompany { get; set; }

        /// <summary>
        /// <see cref="EventCategory"/>
        /// </summary>
        [ForeignKey("IdCategory")]
        [JsonIgnore]
        public virtual EventCategory Category { get; set; }

        /// <summary>
        /// <see cref="Company"/>
        /// </summary>
        [ForeignKey("IdCompany")]
        [JsonIgnore]
        public virtual Company Organizer { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Event"/>
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// <see cref="Event"/>
        /// </summary>
        [ForeignKey("ParentId")]
        [JsonIgnore]
        public virtual Event Parent { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Hall"/>
        /// </summary>
        public int? HallId { get; set; }
        /// <summary>
        /// Зал
        /// </summary>
        [ForeignKey("HallId")]
        [JsonIgnore]
        public virtual Hall Hall { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="ConcertPlaceId"/>
        /// </summary>
        public int? ConcertPlaceId { get; set; }
        /// <summary>
        /// Площадка
        /// </summary>
        [ForeignKey("ConcertPlaceId")]
        [JsonIgnore]
        public virtual ConcertPlace ConcertPlace { get; set; }

        /// <summary>
        /// Серии концерта
        /// </summary>
        [JsonIgnore]
        public virtual IList<SeriesConcert> Series { get; set; }

        /// <summary>
        /// Билеты
        /// </summary>
        [JsonIgnore]
        public virtual ConcertTicket Tickets { get; set; }
    }
}
