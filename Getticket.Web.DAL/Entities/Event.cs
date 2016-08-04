using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual EventCategory Category { get; set; }

        /// <summary>
        /// <see cref="Company"/>
        /// </summary>
        [ForeignKey("IdCompany")]
        public virtual Company Organizer { get; set; }

    }
}
