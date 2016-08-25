using System.Collections.Generic;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagEventMediaLinkModel
    {

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="EventMediaModel"/>
        /// </summary>
        public int IdMedia { get; set; }

        /// <see cref="TagModel"/>
        public IEnumerable<TagModel> Tags { get; set; }
    }
}
