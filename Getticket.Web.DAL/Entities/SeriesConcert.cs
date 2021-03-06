﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Серия событий
    /// </summary>
    public class SeriesConcert
    {
        /// <summary>
        /// Внешний ключ для концерта
        /// </summary>
        [Required]
        [Key, Column(Order = 1)]
        public int EventId { get; set; }

        /// <summary>
        /// Внешний ключ серии
        /// </summary>
        [Required]
        [Key, Column(Order = 2)]
        public int SeriesId { get; set; }

        /// <summary>
        /// <see cref="Entities.Event"/>
        /// </summary>
        [JsonIgnore]
        public virtual Event Event { get; set; }

        /// <summary>
        /// <see cref="Entities.SeriesName"/>
        /// </summary>
        [JsonIgnore]
        public virtual SeriesName Series { get; set; }
    }
}
