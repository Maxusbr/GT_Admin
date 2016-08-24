using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Категория события
    /// </summary>
    public class EventOrganizerModel : BaseModel
    {

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

    }
}