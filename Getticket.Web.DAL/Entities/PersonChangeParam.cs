﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Название изменяемой характеристики
    /// </summary>
    public class PersonChangeParam : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonChangeParam(){}

        /// <summary>
        /// Название
        /// </summary>
        [MaxLength(300)]
        [Required]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }
    }
}
