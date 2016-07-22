using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Название антропометрической характеристики
    /// </summary>
    public class PersonAntroName : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonAntroName(){}

        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(300)]
        [Required]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }
    }
}
