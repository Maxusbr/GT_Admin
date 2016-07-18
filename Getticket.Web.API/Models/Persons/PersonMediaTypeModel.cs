using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Тип медиа
    /// </summary>
    public class PersonMediaTypeModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]public string Name { get; set; }

    }
}
