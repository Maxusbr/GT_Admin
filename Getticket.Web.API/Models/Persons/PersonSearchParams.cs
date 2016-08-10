using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.API.Models.Persons
{
    public class PersonSearchParams
    {
        public Sex? SexId { get; set; }
        public string Alphabetically { get; set; }
    }
}