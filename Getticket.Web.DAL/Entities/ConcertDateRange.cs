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
        public virtual IList<ConcertSchedule> Schedules { get; set; }

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
