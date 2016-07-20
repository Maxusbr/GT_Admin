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
        [Required]public string Name { get; set; }

        /// <summary>
        /// Описание мероприятия
        /// </summary>
        public string Description { get; set; }

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
        /// Внешний ключ для <see cref="Entities.EventType"/>
        /// </summary>
        [Required]public int id_EventType { get; set; }
        /// <summary>
        /// Тип события
        /// </summary>
        [ForeignKey("id_EventType")]
        public virtual EventType EventType { get; set; }
    }
}
