using System;
using Getticket.Web.API.Models.Events;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Билеты на концерт
    /// </summary>
    public class ConcertTicketModel : BaseModel
    {
        /// <summary>
        /// Дата начала доступности
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания доступности
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        /// Время начала доступности
        /// </summary>
        public TimeSpan TimeStart { get; set; }

        /// <summary>
        /// Время окончания доступности
        /// </summary>
        public TimeSpan TimeEnd { get; set; }

        /// <summary>
        /// Продолжительность доступности
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Ссылка на организатора
        /// </summary>
        public string OrganizerLink { get; set; }

        /// <summary>
        /// Отображать форму подписки при пустом <see cref="OrganizerLink"/>
        /// </summary>
        public bool ShowFormWhileEmpty { get; set; }

        /// <summary>
        /// Отображать форму подписки по завершении времени
        /// </summary>
        public bool ShowFormWhileEndTime { get; set; }

        /// <summary>
        /// Событие <see cref="EventModel"/>
        /// </summary>
        public virtual EventModel Event { get; set; }
    }
}
