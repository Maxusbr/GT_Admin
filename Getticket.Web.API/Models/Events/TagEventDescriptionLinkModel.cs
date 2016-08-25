using System.Collections.Generic;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagEventDescriptionLinkModel
    {

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="EventDescriptionModel"/>
        /// </summary>
        public int IdDescription { get; set; }


        public IEnumerable<TagModel> Tags { get; set; }
    }
}
