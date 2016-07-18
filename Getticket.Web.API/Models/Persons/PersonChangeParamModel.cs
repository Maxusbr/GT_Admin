
namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Название изменяемой характеристики (используется для ответов API)
    /// </summary>
    public class PersonChangeParamModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
    }
}
