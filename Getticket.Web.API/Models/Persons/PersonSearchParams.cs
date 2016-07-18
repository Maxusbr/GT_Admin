using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Models.Persons
{
    public class PersonSearchParams
    {
        public int SexId { get; set; }
        public string Alphabetically { get; set; }
    }
}