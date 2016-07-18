using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Страна
    /// </summary>
    public class Country : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Country(){}

        /// <summary>
        /// Название
        /// </summary>
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
    }
}
