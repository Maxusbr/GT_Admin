using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Тип связи (используется для ответов API)
    /// </summary>
    public class PersonConnectionTypeModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
