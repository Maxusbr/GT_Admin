using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Getticket.Web.DAL.Enums;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Ссылка на соц. сети
    /// </summary>
    public class PersonSocialLink : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonSocialLink(){}

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Person"/>
        /// </summary>
        [Required]
        public int id_Person { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.PersonSocialLinkType"/>
        /// </summary>
        [Required]
        public int id_SocialLinkType { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Ссылка
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Назначение
        /// </summary>
        public DestinationTypes Destination { get; set; }
        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Person")]
        [JsonIgnore]
        public virtual Person Person { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonSocialLinkType"/>
        /// </summary>
        [ForeignKey("id_SocialLinkType")]
        [JsonIgnore]
        public virtual PersonSocialLinkType PersonSocialLinkType { get; set; }
    }
}
