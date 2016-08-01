using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель ключевых слов
    /// </summary>
    public class TagModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Слово
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Где используется
        /// </summary>
        public IList<string> UsesType { get; set; }
    }
}