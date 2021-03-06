﻿using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Связи между сущностями <see cref="Entities.Person" /> и <see cref="Entities.Event" />
    /// </summary>
    public class PersonConnection : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonConnection(){}
        /// <summary>
        /// Характеристика связи
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Внешний ключ для <see cref="Entities.Person"/>
        /// </summary>
        [Required]
        public int id_Person { get; set; }

        /// <summary>
        /// Внешний ключ для <see cref="Entities.ConnectionType"/>
        /// </summary>
        [Required]
        public int id_ConnectionType { get; set; }

        /// <summary>
        /// Внешний ключ для связи между сущностями <see cref="Entities.Person"/>
        /// </summary>
        public int? id_PersonConnectTo { get; set; }

        /// <summary>
        /// Внешний ключ для связи между сущностями <see cref="Entities.Person"/> и <see cref="Entities.Event"/>
        /// </summary>
        public int? id_Event { get; set; }        

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Person")]
        [JsonIgnore]
        public virtual Person Person { get; set; }
        
        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_PersonConnectTo")]
        [JsonIgnore]
        public virtual Person PersonConnectTo { get; set; }

        /// <summary>
        /// Тип связи <see cref="Entities.ConnectionType"/>
        /// </summary>
        [ForeignKey("id_ConnectionType")]
        [JsonIgnore]
        public virtual ConnectionType PersonConnectionType { get; set; }

        /// <summary>
        /// Событие <see cref="Entities.Event"/>
        /// </summary>
        [ForeignKey("id_Event")]
        [JsonIgnore]
        public virtual Event Event { get; set; }

    }
}
