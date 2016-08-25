using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Медиа а файлы
    /// </summary>
    public class EventMediaModel : BaseModel
    {
        public int id_Event { get; set; }
        public string Name { get; set; }
        [Required]public int id_MediaType { get; set; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        [Required]public string MediaLink { get; set; }
        public string MediaType { get; set; }
        public string Description { get; set; }
        public LastChangeModel LastChange { get; set; }
        public IList<TagModel> Tags { get; set; }
        public LinksModel Links { get; set; }
    }
}
