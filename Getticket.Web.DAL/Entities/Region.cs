using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Город
    /// </summary>
    public class Region : BaseEntity
    {

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
        public int Country_Id { get; set; }

        /// <summary>
        /// <see cref="Entities.Country"/>
        /// </summary>
        [ForeignKey("Country_Id")]
        [JsonIgnore]
        public virtual Country Country { get; set; }
    }
}
