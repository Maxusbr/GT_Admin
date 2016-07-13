using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
