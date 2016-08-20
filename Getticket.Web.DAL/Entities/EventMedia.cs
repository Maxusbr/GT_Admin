﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Медиа а файлы
    /// </summary>
    public class EventMedia : BaseEntity
    {
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Event"/>
        /// </summary>
        [Required]
        public int IdEvent { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string MediaLink { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.MediaType"/>
        /// </summary>
        [Required]
        public int IdMediaType { get; set; }

        /// <summary>
        /// Описание медиа
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }

        /// <summary>
        /// <see cref="Entities.MediaType"/>
        /// </summary>
        [ForeignKey("IdMediaType")]
        public virtual MediaType MediaType { get; set; }

    }
}
