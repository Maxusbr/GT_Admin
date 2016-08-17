namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagAntroLinkModel
    {
        /// <summary>
        /// Внешний ключ для <see cref="TagModel"/>
        /// </summary>

        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="TagAntroModel"/>
        /// </summary>

        public int IdTagAntro { get; set; }

        /// <summary>
        /// <see cref="TagModel"/>
        /// </summary>

        public TagModel Tag { get; set; }

        /// <summary>
        /// <see cref="TagAntroModel"/>
        /// </summary>

        public TagAntroModel Antro { get; set; }

    }
}
