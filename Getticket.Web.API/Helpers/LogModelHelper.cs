using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Log Helper
    /// </summary>
    public static class LogModelHelper
    {
        public static LastChangeModel GetLastChangeModel(PersonLog log)
        {
            return log != null ? new LastChangeModel { Date = log.Date, UserName = $"{log.User.Name} {log.User.LastName}" }
            : null;
        }
        public static LastChangeModel GetLastChangeModel(EventLog log)
        {
            return log != null ? new LastChangeModel { Date = log.Date, UserName = $"{log.User?.Name} {log.User?.LastName}" }
            : null;
        }
    }
}