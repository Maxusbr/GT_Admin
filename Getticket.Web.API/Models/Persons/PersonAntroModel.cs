
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Антропометрические характеристики (используется для ответов API)
    /// </summary>
    public class PersonAntroModel : BaseModel
    {

        /// <summary>
        /// Значение характеристики
        /// </summary>
        public string Value { get; set; }

        public int IdPerson { get; set; }
        [Required]
        public int IdAntro { get; set; }
        public string AntroName { get; set; }
        public LastChangeModel LastChange { get; set; }
        public LinksModel Links { get; set; }
    }
}
