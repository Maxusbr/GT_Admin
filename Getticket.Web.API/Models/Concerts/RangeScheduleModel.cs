using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models.Concerts
{
    public class RangeScheduleModel
    {
        /// <summary>
        /// Дата начала концерта
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания концерта
        /// </summary>
        public DateTime? DateEnd { get; set; }

        public string DateRange => DateStart.ToString("dd.MM.yyyy") + (DateEnd != null ? $"-{DateEnd?.ToString("dd.MM.yyyy")}" : "");

        /// <summary>
        /// Расписание концертов
        /// </summary>
        public IEnumerable<ConcertScheduleModel> Schedules { get; set; }
    }
}