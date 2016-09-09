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
    public class PersonDescription : BaseEntity
    {

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Person"/>
        /// </summary>
        [Required]
        public int id_Person { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.PersonDescriptionType"/>
        /// </summary>
        [Required]
        public int id_DescriptionType { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.UserPageCategory"/>
        /// </summary>
        public int? IdUserPageCategory { get; set; }

        /// <summary>
        /// Текст описания
        /// </summary>
        public string DescriptionText { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Статическое описание требуется?
        /// </summary>
        public bool RequiredStaticDescription { get; set; }

        /// <summary>
        /// Внешний ключ для схемы размещения
        /// </summary>
        public int? IdBlock { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Person")]
        [JsonIgnore]
        public virtual Person Person { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonDescriptionType"/>
        /// </summary>
        [ForeignKey("id_DescriptionType")]
        [JsonIgnore]
        public virtual PersonDescriptionType PersonDescriptionType { get; set; }

        /// <summary>
        /// Статическое описание
        /// </summary>
        [JsonIgnore]
        public PersonDescription StaticDescription { get; set; }

        /// <summary>
        /// размещение описания
        /// </summary>
        [ForeignKey("IdBlock")]
        [JsonIgnore]
        public virtual PageBlock PageBlock { get; set; }

        /// <summary>
        /// Источник
        /// </summary>
        [ForeignKey("IdUserPageCategory")]
        [JsonIgnore]
        public virtual UserPageCategory UserPageCategory { get; set; }

    }
}
