using Getticket.Web.DAL.Enums;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Тип описания
    /// </summary>
    public class PersonDescriptionTypeModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        public int Type { get; set; }
    }
}
