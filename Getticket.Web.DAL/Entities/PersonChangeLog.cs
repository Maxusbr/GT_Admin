﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Лог изменения параметров <see cref="Entities.PersonChangeParam" /> для сущности <see cref="Entities.Person"/> сущностями <see cref="Entities.User" />
    /// </summary>
    public class PersonChangeLog : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonChangeLog(){}

        /// <summary>
        /// Внешний ключ для <see cref="Entities.Person"/>
        /// </summary>
        [Required]
        public int id_Person { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.PersonChangeParam"/>
        /// </summary>
        [Required]
        public int id_ChangeParam { get; set; }

        /// <summary>
        /// Значение характеристики до
        /// </summary>
        public string ChangeFrom { get; set; }

        /// <summary>
        /// Значение характеристики после
        /// </summary>
        [Required]public string ChangeTo { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.User"/>
        /// </summary>
        public int? id_WhoChange { get; set; }
        
        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Person")]
        [JsonIgnore]
        public virtual Person Person { get; set; }

        /// <summary>
        /// Изменяемая характеристика <see cref="Entities.PersonChangeParam"/>
        /// </summary>
        [ForeignKey("id_ChangeParam")]
        [JsonIgnore]
        public virtual PersonChangeParam PersonChangeParam { get; set; }

        /// <summary>
        /// Кто изменил <see cref="Entities.User"/>
        /// </summary>
        [ForeignKey("id_WhoChange")]
        [JsonIgnore]
        public virtual User User { get; set; }

    }
}
