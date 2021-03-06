﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип ссылки
    /// </summary>
    public class PersonSocialLinkType : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonSocialLinkType(){}

        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(300)]
        [Required]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }
    }
}
