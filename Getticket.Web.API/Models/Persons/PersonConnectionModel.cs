using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Связи между Person и Event (используется для ответов API)
    /// </summary>
    public class PersonConnectionModel : BaseModel
    {
        public int id_Person { get; set; }
        public PersonModel Person { get; set; }

        public int? id_PersonConnectTo { get; set; }
        public PersonModel PersonConnectTo { get; set; }
        [Required]
        public int id_ConnectionType { get; set; }
        public string PersonConnectionType { get; set; }
        public string Description { get; set; }
        public int? id_Event { get; set; }
        public EventModel Event { get; set; }
        public LastChangeModel LastChange { get; set; }
    }
}
