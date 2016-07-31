using System.Collections.Generic;


namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Модель Страна (используется для ответов API)
    /// </summary>
    public class CountryModel: BaseModel
    {
        public IList<CountryPlaceModel> Places { get; set; }
        public string Name { get; set; }
    }
}
