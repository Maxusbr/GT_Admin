using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models.Persons
{
    public class CountsModel
    {
        public int CountDescriptions { get; set; }
        public int CountFacts { get; set; }
        public int CountConnects { get; set; }
        public int CountMedias { get; set; }
        public int CountLinks { get; set; }
        public int CountAntros { get; set; }

    }
}