using System;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Расписание концерта
    /// </summary>
    public class ConcertScheduleModel: BaseModel
    {
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
        /// День недели (если указан, период = 7 дней)
        /// </summary>
        public int? WeekDay { get; set; }

        /// <summary>
        /// Период повторения в днях
        /// </summary>
        public int? Period { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="ConcertDateRangeModel"/>
        /// </summary>
        [Required]
        public int IdRange { get; set; }

        /// <summary>
        /// <see cref="ConcertDateRangeModel"/>
        /// </summary>
        public virtual ConcertDateRangeModel Range { get; set; }
    }
}
