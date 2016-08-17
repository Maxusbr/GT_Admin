using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models.Events
{
    public class EventTagModel
    {
        public int EventId { get; set; }
        public IEnumerable<TagModel> Models { get; set; }
    }
}