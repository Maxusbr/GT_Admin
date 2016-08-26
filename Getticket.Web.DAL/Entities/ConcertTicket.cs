using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Билеты на концерт
    /// </summary>
    public class ConcertTicket : BaseEntity
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

        ///// <summary>
        ///// Внешний ключ для <see cref="Entities.Event"/>
        ///// </summary>
        //[Required]
        //public int IdEvent { get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        //[ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }
    }
}
