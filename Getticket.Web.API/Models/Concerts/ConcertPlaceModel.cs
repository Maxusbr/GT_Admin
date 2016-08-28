using System.Collections.Generic;
using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Площадка
    /// </summary>
    public class ConcertPlaceModel : BaseModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внешняя ссылка на <see cref="CountryPlaceModel"/>
        /// </summary>
        public int PlaceId { get; set; }

        /// <summary>
        /// <see cref="CountryPlaceModel"/>
        /// </summary>
        public virtual CountryPlaceModel CountryPlace { get; set; }

        /// <summary>
        /// Площадки
        /// </summary>
        public virtual IEnumerable<HallModel> Halls { get; set; }
    }
}
