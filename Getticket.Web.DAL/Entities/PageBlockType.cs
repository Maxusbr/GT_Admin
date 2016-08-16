using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип блока страницы
    /// </summary>
    public class PageBlockType : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(200)]
        [Required]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }
    }
}
