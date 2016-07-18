using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Медиа а файлы
    /// </summary>
    public class PersonMediaModel : BaseModel
    {
        public int id_Person { get; set; }
        [Required]public int id_MediaType { get; set; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        [Required]public string MediaLink { get; set; }
    }
}
