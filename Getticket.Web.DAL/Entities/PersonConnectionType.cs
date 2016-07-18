using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип связи
    /// </summary>
    public class PersonConnectionType : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonConnectionType(){}

        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
    }
}
