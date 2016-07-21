using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Helpers
{
    public static class TimeSpanExtensions
    {
        public static int GetYears(this TimeSpan timespan)
        {
            return (int)((double)timespan.Days / 365.2425);
        }
    }
}