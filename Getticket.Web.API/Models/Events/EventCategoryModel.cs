using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models.Events
{
    /// <summary>
    /// Категория события
    /// </summary>
    public class EventCategoryModel: BaseModel
    {
        public string Name { get; set; }

        /// <summary>
        /// Описание категории
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Родительская категория
        /// </summary>
        public int? IdParent { get; set; }
    }
}