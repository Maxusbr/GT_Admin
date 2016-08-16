using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Тип блока страницы
    /// </summary>
    public class PageBlockTypeModel : BaseModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
