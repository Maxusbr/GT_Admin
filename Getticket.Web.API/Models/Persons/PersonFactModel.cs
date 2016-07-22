namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Факты
    /// </summary>
    public class PersonFactModel : BaseModel
    {
        /// <summary>
        /// Текст описания
        /// </summary>
        public string FactText { get; set; }

        public int id_Person { get; set; }

        public int id_FactType { get; set; }
        public PersonFactTypeModel FactType { get; set; }
    }
}
