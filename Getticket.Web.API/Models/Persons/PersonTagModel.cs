using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models.Persons
{
    public class PersonTagModel
    {
        public int personId { get; set; }
        public IEnumerable<TagModel> models { get; set; }
    }
}