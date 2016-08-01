using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип связанного объекта
    /// </summary>
    public class TagLinkType : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TagLinkType(){}

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [MaxLength(300)]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }

    }
}
