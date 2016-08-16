using Getticket.Web.API.Models.Persons;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Схема размещения описания персоны
    /// </summary>
    public class PageSchemaModel : BaseModel
    {
        /// <summary>
        /// Стрраница перехода
        /// </summary>
        public int? PageType { get; set; }
        
        /// <summary>
        /// Внешний ключ для <see cref="PersonModel"/>
        /// </summary>
        public int? IdPerson { get; set; }
        
        /// <summary>
        /// Внешний ключ для <see cref="EventModel"/>
        /// </summary>
        public int? IdEvent { get; set; }
        
        /// <summary>
        /// Внешний ключ для <see cref="HallModel"/>
        /// </summary>
        public int? IdHall { get; set; }

        /// <summary>
        /// <see cref="PersonModel"/>
        /// </summary>
        public PersonModel Person { get; set; }

        /// <summary>
        /// <see cref="EventModel"/>
        /// </summary>
        public EventModel Event { get; set; }

    }
}
