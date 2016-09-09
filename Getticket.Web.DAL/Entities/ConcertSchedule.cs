using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Расписание концерта
    /// </summary>
    public class ConcertSchedule: BaseEntity
    {
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

        /// <summary>
        /// День недели (если указан, период = 7 дней)
        /// </summary>
        public int? WeekDay { get; set; }

        /// <summary>
        /// Период повторения в днях
        /// </summary>
        public int? Period { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.ConcertDateRange"/>
        /// </summary>
        [Required]
        public int IdRange { get; set; }

        /// <summary>
        /// <see cref="Entities.ConcertDateRange"/>
        /// </summary>
        [ForeignKey("IdRange")]
        [JsonIgnore]
        public virtual ConcertDateRange Range { get; set; }
    }
}
