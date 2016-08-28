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
        /// Внешний ключ серии
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <see cref="SeriesNameModel"/>
        /// </summary>
        public string Name { get; set; }
    }
}
