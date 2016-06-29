using System;

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
        public string Name { get; set; }

        /// <summary>
        /// Описание мероприятия
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата начала продаж (билетов?)
        /// </summary>
        public DateTime DateStartSold { get; set; }

        /// <summary>
        /// Дата окончания продаж (билетов?)
        /// </summary>
        public DateTime DateStopSold { get; set; }

        /// <summary>
        /// Дата события
        /// </summary>
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Дата до которой можно вернуть билет
        /// </summary>
        public DateTime TicketReturn { get; set; }
    }
}
