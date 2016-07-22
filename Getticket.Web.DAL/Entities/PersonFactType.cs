using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип описания
    /// </summary>
    public class PersonFactType : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonFactType(){}

        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(300)]
        [Required]
        public string Name { get; set; }
        public string Descript { get; set; }
    }
}
