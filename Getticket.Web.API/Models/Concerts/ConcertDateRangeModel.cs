using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Getticket.Web.API.Models.Events;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Календарь концерта
    /// </summary>
    public class ConcertDateRangeModel : BaseModel
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
        /// Повторяющийся концерт
        /// </summary>
        public bool IsRepeated { get; set; }

        /// <summary>
        /// Расписание концерта
        /// </summary>
        public virtual IEnumerable<ConcertScheduleModel> Schedules { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="EventModel"/>
        /// </summary>
        [Required]
        public int IdEvent { get; set; }

        /// <summary>
        /// Событие <see cref="EventModel"/>
        /// </summary>
        public virtual EventModel Event { get; set; }
    }
}
