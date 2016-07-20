using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Город
    /// </summary>
    public class CountryPlace : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CountryPlace(){}

        /// <summary>
        /// Название
        /// </summary>
        [MaxLength(500)]
        [Required]
        [Index("CountryPlaceNameIndex", 1, IsUnique = true)]
        public string Name { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Country"/>
        /// </summary>
        [Required]
        [Index("CountryPlaceNameIndex", 2, IsUnique = true)]
        public int id_Country { get; set; }

        /// <summary>
        /// <see cref="Entities.Country"/>
        /// </summary>
        [ForeignKey("id_Country")]
        public virtual Country Country { get; set; }
    }
}
