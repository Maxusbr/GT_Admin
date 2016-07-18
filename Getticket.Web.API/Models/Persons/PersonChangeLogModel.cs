
namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Запись лога изменения параметров (используется для ответов API)
    /// </summary>
    public class PersonChangeLogModel : BaseModel
    {
        /// <summary>
        /// Значение характеристики до
        /// </summary>
        public string ChangeFrom { get; set; }

        /// <summary>
        /// Значение характеристики после
        /// </summary>
        public string ChangeTo { get; set; }

        public int id_Person { get; set; }
        public PersonModel Person { get; set; }
        public int IdChangeParam { get; set; }
        public string PersonChangeParam { get; set; }

        public int? id_WhoChange { get; set; }
        public UserModel User { get; set; }

    }
}
