using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models.Persons
{
    public class EntityCollection<T>
    {
        public int Type { get; set; }
        public IEnumerable<T> List { get; set; }
        public int Count => List.Count();
    }
}