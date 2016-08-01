using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagLinkModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="TagModel"/>
        /// </summary>
        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="TagLinkTypeModel"/>
        /// </summary>
        public int IdLinkType { get; set; }

        /// <summary>
        /// Характеристика связи
        /// </summary>
        public string FeatureName { get; set; }

        /// <summary>
        /// Тип характеристики
        /// </summary>
        public string FeatureType { get; set; }

        /// <summary>
        /// Условие характеристики
        /// </summary>
        public string ConditionFeatureValue { get; set; }

        /// <summary>
        /// Значение характеристики
        /// </summary>
        public string FeatureValue { get; set; }

        /// <see cref="TagModel"/>
        public TagModel Tag { get; set; }
    }
}