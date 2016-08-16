using System.ComponentModel.DataAnnotations;
using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Связи между Person и Event (используется для ответов API)
    /// </summary>
    public class EventConnectionModel : BaseModel
    {
        public int? id_Person { get; set; }
        public PersonModel Person { get; set; }

        public int? id_EventConnectTo { get; set; }
        public EventModel EventConnectTo { get; set; }
        [Required]
        public int id_ConnectionType { get; set; }
        public string EventConnectionType { get; set; }
        public string Description { get; set; }
        public int id_Event { get; set; }
        public EventModel Event { get; set; }
        public LastChangeModel LastChange { get; set; }
    }
}
