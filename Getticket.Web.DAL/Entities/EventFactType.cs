using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип описания
    /// </summary>
    public class EventFactType : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public EventFactType(){}

        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(300)]
        [Required]
        public string Name { get; set; }
        public string Descript { get; set; }
    }
}
