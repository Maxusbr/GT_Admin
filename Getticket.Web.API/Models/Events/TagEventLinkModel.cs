using System.Collections.Generic;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagEventLinkModel
    {
        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="EventModel"/>
        /// </summary>
        public int IdEvent { get; set; }

        /// <see cref="TagEventModel"/>
        public IEnumerable<TagEventModel> Tags { get; set; }
    }
}
