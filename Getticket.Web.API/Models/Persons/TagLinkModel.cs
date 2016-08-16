using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagLinkModel
    {
        /// <summary>
        /// Внешний ключ для <see cref="TagModel"/>
        /// </summary>
        [Required]
        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="PersonModel"/>
        /// </summary>
        [Required]
        public int IdPerson { get; set; }

        /// <summary>
        /// <see cref="TagModel"/>
        /// </summary>
        public TagModel Tag { get; set; }

        /// <summary>
        /// <see cref="PersonModel"/>
        /// </summary>
        public PersonModel Person { get; set; }

    }
}
