using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Площадка
    /// </summary>
    public class ConcertPlace : BaseEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внешняя ссылка на <see cref="CountryPlace"/>
        /// </summary>
        public int PlaceId { get; set; }

        /// <summary>
        /// <see cref="CountryPlace"/>
        /// </summary>
        [ForeignKey("PlaceId")]
        public virtual CountryPlace CountryPlace { get; set; }

        /// <summary>
        /// Площадки
        /// </summary>
        public virtual ICollection<Hall> Halls { get; set; }
    }
}
