﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип связи
    /// </summary>
    public class EventConnectionType : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(200)]
        [Required]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }
    }
}