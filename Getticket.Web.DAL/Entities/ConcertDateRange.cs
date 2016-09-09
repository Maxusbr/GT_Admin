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
    /// Календарь концерта
    /// </summary>
    public class ConcertDateRange : BaseEntity
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
        [JsonIgnore]
        public virtual IList<ConcertSchedule> Schedules { get; set; }

        /// <summary>
        /// ForeignKey <see cref="Entities.Event"/>
        /// </summary>
        public int IdEvent { get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        //[ForeignKey("IdEvent")]
        [JsonIgnore]
        public virtual Event Event { get; set; }
    }
}
