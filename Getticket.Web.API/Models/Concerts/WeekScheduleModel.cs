using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Превью расписания концерта
    /// </summary>
    public class WeekScheduleModel
    {
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        /// <summary>
        /// Время начала концерта
        /// </summary>
        public TimeSpan TimeStart { get; set; }
        /// <summary>
        /// Время окончания концерта
        /// </summary>
        public TimeSpan? TimeEnd { get; set; }

        /// <summary>
        /// Продолжительность концерта
        /// </summary>
        public TimeSpan? Duration { get; set; }

        public IEnumerable<int> WeekDays { get; set; }

    }
}
