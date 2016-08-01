using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель типа связанного объекта
    /// </summary>
    public class TagLinkTypeModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public string Name { get; set; }
    }
}