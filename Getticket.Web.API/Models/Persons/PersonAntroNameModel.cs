using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Название антропометрической характеристики (используется для ответов API)
    /// </summary>
    public class PersonAntroNameModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
