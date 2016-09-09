using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Описание
    /// </summary>
    public class PersonDescriptionTizerLink
    {
        /// <summary>
        /// Внешний ключ для тизера
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdTizer { get; set; }

        /// <summary>
        /// Внешний ключ для статического описания
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdStaticDescription { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonDescription"/>
        /// </summary>
        //[ForeignKey("IdTizer")]
        [JsonIgnore]
        public virtual PersonDescription Tizer { get; set; }

        /// <summary>
        /// Статическое описание
        /// </summary>
        //[ForeignKey("IdStaticDescription")]
        [JsonIgnore]
        public virtual PersonDescription Description { get; set; }
    }
}
