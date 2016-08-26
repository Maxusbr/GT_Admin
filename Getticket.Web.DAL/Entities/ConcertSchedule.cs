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
    /// Календарь концерта
    /// </summary>
    public class ConcertSchedule: BaseEntity
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
        /// Повторяющийся концерт
        /// </summary>
        public bool IsRepeated { get; set; }

        /// <summary>
        /// День недели (если указан, период = 7 дней)
        /// </summary>
        public int? WeekDay { get; set; }

        /// <summary>
        /// Период повторения в днях
        /// </summary>
        public int? Period { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Event"/>
        /// </summary>
        [Required]
        public int IdEvent { get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }
    }
}
