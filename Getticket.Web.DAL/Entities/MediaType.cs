﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип медиа
    /// </summary>
    public class MediaType : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public MediaType(){}

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [MaxLength(300)]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }

    }
}
