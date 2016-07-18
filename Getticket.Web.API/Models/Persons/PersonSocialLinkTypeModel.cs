using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Тип ссылки
    /// </summary>
    public class PersonSocialLinkTypeModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]public string Name { get; set; }
    }
}
