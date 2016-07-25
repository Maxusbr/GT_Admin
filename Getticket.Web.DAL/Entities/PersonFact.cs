﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Факты
    /// </summary>
    public class PersonFact : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonFact(){}

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Person"/>
        /// </summary>
        [Required]
        public int id_Person { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.PersonDescriptionType"/>
        /// </summary>
        [Required]
        public int id_FactType { get; set; }

        /// <summary>
        /// Текст факта
        /// </summary>
        public string FactText { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Person")]
        public virtual Person Person { get; set; }

        /// <summary>
        /// <see cref="PersonFactType"/>
        /// </summary>
        [ForeignKey("id_FactType")]
        public virtual PersonFactType FactType { get; set; }
    }
}