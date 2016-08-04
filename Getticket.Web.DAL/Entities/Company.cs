using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Компания
    /// </summary>
    public class Company : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Company(){}

        /// <summary>
        /// Название
        /// </summary>
        [MaxLength(200)]
        [Required]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }

        /// <summary>
        /// Описание компании
        /// </summary>
        public string Description { get; set; }
    }
}
