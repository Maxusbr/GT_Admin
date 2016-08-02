using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Ключевые слова
    /// </summary>
    public class Tag : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Tag(){}

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }

        /// <summary>
        /// Где используется
        /// </summary>
        public virtual IList<string> UsesType { get; set; } = new List<string>();
    }
}
