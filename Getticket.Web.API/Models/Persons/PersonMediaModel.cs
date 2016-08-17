using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Медиа а файлы
    /// </summary>
    public class PersonMediaModel : BaseModel
    {
        public string Name { get; set; }
        public int id_Person { get; set; }
        [Required]public int id_MediaType { get; set; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        [Required]public string MediaLink { get; set; }
        [Required]public int MediaTypeId { get; set; }
        public string MediaType { get; set; }
        public string Description { get; set; }
        public LastChangeModel LastChange { get; set; }
        public IList<TagModel> Tags { get; set; }
    }
}
