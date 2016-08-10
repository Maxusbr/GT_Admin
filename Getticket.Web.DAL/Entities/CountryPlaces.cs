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
        /// Название
        /// </summary>
        [MaxLength(50)]
        [Index("CountryPlaceNameIndex", 2, IsUnique = true)]
        public string Abr { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Region"/>
        /// </summary>
        [Required]
        [Index("CountryPlaceNameIndex", 3, IsUnique = true)]
        public int id_Region { get; set; }

        /// <summary>
        /// <see cref="Entities.Country"/>
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// <see cref="Entities.Region"/>
        /// </summary>
        [ForeignKey("id_Region")]
        public virtual Region Region { get; set; }

    }
}
