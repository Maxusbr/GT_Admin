﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PagedList;

namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Person
    /// </summary>
    public class PersonModel : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        [Required]
        public DateTime Bithday { get; set; }

        /// <summary>
        /// Имя (латинское)
        /// </summary>
        public string NameLatin { get; set; }

        /// <summary>
        /// Фамилия (латинское)
        /// </summary>
        public string LastNameLatin { get; set; }

        /// <summary>
        /// Отчество (латинское)
        /// </summary>
        public string PatronymicLatin { get; set; }
        [Required]
        public int IdBithplace { get; set; }
        public string Place { get; set; }
        [Required]
        public int IdSex { get; set; }
        public string Sex { get; set; }

        public PersonConnectionModel FirstConnection { get; set; }
        public IList<PersonConnectionModel> Connections { get; set; }
    }
}