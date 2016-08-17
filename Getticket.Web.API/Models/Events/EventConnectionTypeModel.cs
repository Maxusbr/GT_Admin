using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Тип связи (используется для ответов API)
    /// </summary>
    public class EventConnectionTypeModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
