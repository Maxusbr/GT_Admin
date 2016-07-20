using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Антропометрические характеристики
    /// </summary>
    public class PersonAntro : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonAntro(){}

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Person"/>
        /// </summary>
        [Required]
        [Index("PersonAntroIndex", 1, IsUnique = true)]
        public int id_Person { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="PersonAntroName"/>
        /// </summary>
        [Required]
        [Index("PersonAntroIndex", 2, IsUnique = true)]
        public int id_Antro { get; set; }

        /// <summary>
        /// Значение характеристики
        /// </summary>
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Person")]
        public virtual Person Person { get; set; }

        /// <summary>
        /// Наименование характеристики <see cref="PersonAntroName"/>
        /// </summary>
        [ForeignKey("id_Antro")]
        public virtual PersonAntroName AntroName { get; set; }
    }
}
