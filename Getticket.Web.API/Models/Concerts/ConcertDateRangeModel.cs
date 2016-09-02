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
        /// Ссылка на концерт
        /// </summary>
        public int IdEvent { get; set; }

        /// <summary>
        /// Расписание концерта
        /// </summary>
        public virtual IEnumerable<WeekScheduleModel> WeekSchedules { get; set; }

        /// <summary>
        /// Расписание концерта
        /// </summary>
        public virtual IEnumerable<RangeScheduleModel> RangeSchedules { get; set; }

        public virtual IEnumerable<PreviewScheduleModel> PreviewWeek { get; set; }
        public virtual IEnumerable<PreviewScheduleModel> PreviewRange { get; set; }

        public ConcertScheduleModel OneSchedule { get; set; }
    }
}
