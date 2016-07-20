using System;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Сущность для хранения событий
    /// </summary>
    public class EventModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
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
        /// Тип события
        /// </summary>
        public string EventType { get; set; }
    }
}
