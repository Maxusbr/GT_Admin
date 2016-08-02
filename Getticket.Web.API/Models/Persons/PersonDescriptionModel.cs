using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Описание
    /// </summary>
    public class PersonDescriptionModel : BaseModel
    {
        /// <summary>
        /// Текст описания
        /// </summary>
        [Required]
        public string DescriptionText { get; set; }

        public int id_Person { get; set; }

        public int id_DescriptionType { get; set; }
        public string PersonDescriptionType { get; set; }
        public string Status { get; set; }
    }
}
