using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Факты
    /// </summary>
    public class EventFactModel : BaseModel
    {
        /// <summary>
        /// Текст описания
        /// </summary>
        //[MaxLength(190)]
        [Required]
        public string FactText { get; set; }

        public int id_Event { get; set; }

        public int id_FactType { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public EventFactTypeModel FactType { get; set; }
        public LastChangeModel LastChange { get; set; }
    }
}
