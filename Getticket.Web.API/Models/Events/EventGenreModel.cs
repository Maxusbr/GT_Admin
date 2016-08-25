namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Сущность для жанра
    /// </summary>
    public class EventGenreModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Основной
        /// </summary>
        public bool IsMain { get; set; }
    }
}
