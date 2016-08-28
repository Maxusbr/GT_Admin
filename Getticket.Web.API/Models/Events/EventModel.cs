using System;
using System.Collections.Generic;
using Getticket.Web.API.Models.Concerts;

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
        public int? EventParentCategoryId { get; set; }

        /// <summary>
        /// Возрастное ограничение
        /// </summary>
        public int AgeLimit { get; set; }

        /// <summary>
        /// Организатор
        /// </summary>
        public string Organizer { get; set; }

        /// <summary>
        /// Опубликован
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Ссылка на организатора
        /// </summary>
        public int? IdCompany { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="EventModel"/>
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// <see cref="EventModel"/>
        /// </summary>
        public virtual EventModel Parent { get; set; }
        /// <summary>
        /// Внешний ключ для <see cref="HallModel"/>
        /// </summary>
        public int? HallId { get; set; }
        /// <summary>
        /// Зал
        /// </summary>
        public virtual HallModel Hall { get; set; }
        /// <summary>
        /// Внешний ключ для <see cref="ConcertPlaceModel"/>
        /// </summary>
        public int? ConcertPlaceId { get; set; }
        /// <summary>
        /// Площадка
        /// </summary>

        public virtual ConcertPlaceModel ConcertPlace { get; set; }

        /// <summary>
        /// Серии концерта
        /// </summary>
        public virtual IList<SeriesConcertModel> Series { get; set; }

        /// <summary>
        /// Билеты
        /// </summary>
        public virtual ConcertTicketModel Tickets { get; set; }
    }
}
