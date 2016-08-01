using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagLink : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TagLink(){}

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Tag"/>
        /// </summary>
        [Required]
        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="TagLinkType"/>
        /// </summary>
        [Required]
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

        /// <summary>
        /// <see cref="Entities.Tag"/>
        /// </summary>
        [ForeignKey("IdTag")]
        public virtual Tag Tag { get; set; }

        /// <summary>
        /// <see cref="TagLinkType"/>
        /// </summary>
        [ForeignKey("IdLinkType")]
        public virtual TagLinkType Type { get; set; }

    }
}
