using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Enums
{
    /// <summary>
    /// Тип изменяемой характеритики
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// Собитие, персона, мероприятие и т.д.
        /// </summary>
        Entity, 
        /// <summary>
        /// Описание
        /// </summary>
        Description,
        /// <summary>
        /// Факт
        /// </summary>
        Fact,
        /// <summary>
        /// Ссылки
        /// </summary>
        Connection,
        /// <summary>
        /// Медиа
        /// </summary>
        Media,
        /// <summary>
        /// Социальные сети
        /// </summary>
        Link,
        /// <summary>
        /// Теги
        /// </summary>
        Tag,
        /// <summary>
        /// Права и пользователи
        /// </summary>
        RightsUsers,
        /// <summary>
        /// Антропометрия
        /// </summary>
        Anthropometry,
        /// <summary>
        /// Другое
        /// </summary>
        Other
    }
}
