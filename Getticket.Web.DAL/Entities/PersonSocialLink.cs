using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int id_Person { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.PersonSocialLinkType"/>
        /// </summary>
        public int id_SocialMedia { get; set; }

        /// <summary>
        /// Ссылка
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Person")]
        public virtual Person Person { get; set; }

        /// <summary>
        /// <see cref="Entities.PersonSocialLinkType"/>
        /// </summary>
        [ForeignKey("id_SocialMedia")]
        public virtual PersonSocialLinkType PersonSocialLinkType { get; set; }
    }
}
