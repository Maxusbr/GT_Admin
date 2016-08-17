using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Тип медиа
    /// </summary>
    public class MediaTypeModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]public string Name { get; set; }

    }
}
