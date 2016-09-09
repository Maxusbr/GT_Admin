using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Зал
    /// </summary>
    public class Hall : BaseEntity
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
        /// <see cref="ConcertPlace"/>
        /// </summary>
        [ForeignKey("PlaceId")]
        [JsonIgnore]
        public virtual ConcertPlace ConcertPlace { get; set; }

        /// <summary>
        /// Список концертов
        /// </summary>
        [JsonIgnore]
        public virtual IList<Event> Events { get; set; }
    }
}
