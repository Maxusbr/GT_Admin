using System.Collections.Generic;
using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Person
    /// </summary>
    public class EventDetailModel: EventModel
    {
        public IList<PersonConnectionModel> Connection { get; set; }
        public IList<EventDescriptionModel> Descriptions { get; set; }
        public IList<EventMediaModel> MidiaList { get; set; }
        public IList<PersonChangeLogModel> LogChanges { get; set; }
    }
}
