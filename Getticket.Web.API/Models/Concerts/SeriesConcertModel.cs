using System.ComponentModel.DataAnnotations;
using Getticket.Web.API.Models.Events;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Серия событий
    /// </summary>
    public class SeriesConcertModel
    {
        /// <summary>
        /// Внешний ключ для концерта
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Внешний ключ серии
        /// </summary>
        [Required]
        public int SeriesId { get; set; }

        /// <summary>
        /// <see cref="EventModel"/>
        /// </summary>
        public virtual EventModel Event { get; set; }

        /// <summary>
        /// <see cref="SeriesNameModel"/>
        /// </summary>
        public virtual SeriesNameModel Series { get; set; }
    }
}
