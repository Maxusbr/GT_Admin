using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagPersonLink
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TagPersonLink(){}

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Tag"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="Entities.Person"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdPerson { get; set; }

        /// <summary>
        /// <see cref="Entities.Tag"/>
        /// </summary>
        [ForeignKey("IdTag")]
        [JsonIgnore]
        public virtual Tag Tag { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("IdPerson")]
        [JsonIgnore]
        public virtual Person Person { get; set; }

    }
}
