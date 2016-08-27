using System.Collections.Generic;
using Getticket.Web.API.Models.Events;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Зал
    /// </summary>
    public class HallModel : BaseModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внешняя ссылка на <see cref="ConcertPlaceModel"/>
        /// </summary>
        public int PlaceId { get; set; }

        /// <summary>
        /// <see cref="ConcertPlaceModel"/>
        /// </summary>
        public virtual ConcertPlaceModel ConcertPlace { get; set; }

        /// <summary>
        /// Список концертов
        /// </summary>
        public virtual IList<EventModel> Events { get; set; }
    }
}
