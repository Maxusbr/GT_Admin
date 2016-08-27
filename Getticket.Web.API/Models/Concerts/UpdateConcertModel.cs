using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Models.Events;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Модель для обновления концерта
    /// </summary>
    public class UpdateConcertModel
    {
        /// <summary>
        /// Концерт (включая серию, зал и билеты)
        /// </summary>
        public EventModel Concert { get; set; }

        /// <summary>
        /// Календарь концерта
        /// </summary>
        public IEnumerable<ConcertDateRangeModel> Schedules { get; set; }

        /// <summary>
        /// Программа концерта
        /// </summary>
        public IEnumerable<ConcertProgrammModel> Programms { get; set; }

    }
}