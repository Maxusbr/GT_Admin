using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Описание последнего изменения Entity
    /// </summary>
    public class LastChangeModel
    {
        /// <summary>
        /// Дата
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Название изменяемой характеристики
        /// </summary>
        public string NameProperty { get; set; }

    }
}