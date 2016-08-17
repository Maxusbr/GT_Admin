using System;

namespace Getticket.Web.API.Models.Events
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
        /// Подкатегория
        /// </summary>
        public string EventCategory { get; set; }

        /// <summary>
        /// Id Подкатегории
        /// </summary>
        public int? EventCategoryId { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public string EventParentCategory { get; set; }

        /// <summary>
        /// Id Категории
        /// </summary>
        public int EventParentCategoryId { get; set; }

        /// <summary>
        /// Возрастное ограничение
        /// </summary>
        public int AgeLimit { get; set; }

        /// <summary>
        /// Организатор
        /// </summary>
        public string Organizer { get; set; }
    }
}
