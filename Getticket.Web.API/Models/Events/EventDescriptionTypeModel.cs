namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Тип описания
    /// </summary>
    public class EventDescriptionTypeModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        public int Type { get; set; }
    }
}
