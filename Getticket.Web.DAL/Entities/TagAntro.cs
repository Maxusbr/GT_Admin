using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Характеристика
    /// </summary>
    public class TagAntro : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TagAntro(){}
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Person"/>
        /// </summary>
        [Required]
        public int IdPerson { get; set; }
        /// <summary>
        /// Внешний ключ для <see cref="PersonAntroName"/>
        /// </summary>
        [Required]
        public int IdAntroName { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        [Required]
        public int Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsMoreThan { get; set; }
        /// <summary>
        /// Где используется
        /// </summary>
        [ForeignKey("IdAntroName")]
        public virtual PersonAntroName AntroName { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("IdPerson")]
        public virtual Person Person { get; set; }
    }
}
