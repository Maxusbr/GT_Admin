using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class EventGenreLinkModel
    {
        /// <summary>
        /// Внешний ключ для <see cref="EventModel"/>
        /// </summary>
        public int IdEvent { get; set; }

        /// <summary>
        /// Жанр <see cref="EventGenreModel"/>
        /// </summary>
        public IEnumerable<EventGenreModel> Genres { get; set; }
    }
}
