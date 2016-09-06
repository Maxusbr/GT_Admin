
namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Город (используется для ответов API)
    /// </summary>
    public class CountryPlaceModel : BaseModel
    {
        public int IdCountry { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        public string CountryName { get; set; }
        public string Abr { get; set; }
    }
}
