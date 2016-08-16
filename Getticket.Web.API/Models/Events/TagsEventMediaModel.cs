using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models.Events
{
    public class TagsEventMediaModel
    {
        public int IdMedia { get; set; }
        public IList<TagModel> Tags { get; set; }
    }
}