using System.ComponentModel.DataAnnotations;
using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagDescriptionLinkModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TagDescriptionLinkModel(){}

        /// <summary>
        /// Внешний ключ для <see cref="TagModel"/>
        /// </summary>
        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="PersonDescriptionModel"/>
        /// </summary>
        public int IdDescription { get; set; }

        /// <summary>
        /// <see cref="TagModel"/>
        /// </summary>
        public TagModel Tag { get; set; }

        /// <summary>
        /// <see cref="PersonDescriptionModel"/>
        /// </summary>
        public PersonDescriptionModel Description { get; set; }

    }
}
