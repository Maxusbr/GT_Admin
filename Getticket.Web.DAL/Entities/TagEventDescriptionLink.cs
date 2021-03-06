﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связь ключевых слов
    /// </summary>
    public class TagEventDescriptionLink
    {
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Tag"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int IdTag { get; set; }

        /// <summary>
        /// Внешний ключ для типа связанного объекта <see cref="EventDescription"/>
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int IdDescription { get; set; }

        /// <summary>
        /// <see cref="Entities.Tag"/>
        /// </summary>
        [ForeignKey("IdTag")]
        [JsonIgnore]
        public virtual Tag Tag { get; set; }

        /// <summary>
        /// <see cref="EventDescription"/>
        /// </summary>
        [ForeignKey("IdDescription")]
        [JsonIgnore]
        public virtual EventDescription Description { get; set; }

    }
}
