using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип описания
    /// </summary>
    public class PersonDescriptionType : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonDescriptionType(){}

        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(300)]
        [Required]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }

        public DescriptionTypes Type { get; set; }
    }
}
