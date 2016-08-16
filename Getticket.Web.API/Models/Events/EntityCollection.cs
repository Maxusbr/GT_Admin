using System.Collections.Generic;
using System.Linq;

namespace Getticket.Web.API.Models.Events
{
    public class EntityCollection<T>
    {
        public int Type { get; set; }
        public IEnumerable<T> List { get; set; }
        public int Count => List.Count();
    }
}