using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип события
    /// </summary>
    public class EventType : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public EventType(){}

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [MaxLength(200)]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }

    }
}
