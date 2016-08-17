using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Описание
    /// </summary>
    public class EventDescriptionModel : BaseModel
    {
        /// <summary>
        /// Текст описания
        /// </summary>
        [Required]
        public string DescriptionText { get; set; }

        public int id_Event { get; set; }

        public int id_DescriptionType { get; set; }
        public string EventDescriptionType { get; set; }
        public string Status { get; set; }
        public bool RequiredStaticDescription { get; set; }
        public int? IdStaticDescription { get; set; }
        public EventDescriptionModel StaticDescription { get; set; }
        public int? IdBlock { get; set; }
        public PageBlockModel PageBlock { get; set; }
        public LastChangeModel LastChange { get; set; }
    }
}
