using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Ссылка на соц. сети
    /// </summary>
    public class PersonSocialLinkModel : BaseModel
    {
        /// <summary>
        /// Ссылка
        /// </summary>
        [Required]public string Link { get; set; }

        public int id_Person { get; set; }

        [Required]public int IdSocialLinkType { get; set; }
        public string PersonSocialLinkType { get; set; }
    }
}
