﻿using Getticket.Web.DAL.Enums;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Роли доступа пользователя к методам контроллера 
    /// </summary>
    public class AccessRole : BaseEntity
    {
        public AccessRole()
        {
            this.Users = new HashSet<User>();
        }

        /// <summary>
        /// Список всех ролей котоые имеет пользователь
        /// </summary>
        public AccessRoleType Role { get; set; }

        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание роли
        /// </summary>
        public string Desciption { get; set; }


        /// <summary>
        /// Ссылка на пользователей
        /// </summary>
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
