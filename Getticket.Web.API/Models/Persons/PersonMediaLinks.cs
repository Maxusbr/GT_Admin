using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Models.Events;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Ассоциации медиа
    /// </summary>
    public class PersonMediaLinks
    {
        public IEnumerable<PersonModel> PersonLinks { get; set; }
        public IEnumerable<EventModel> EventLinks { get; set; }
    }


}