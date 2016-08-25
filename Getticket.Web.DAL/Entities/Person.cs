using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Person
    /// </summary>
    public class Person : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Person(){}

        /// <summary>
        /// Имя
        /// </summary>
        [Required]public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        [Required]public DateTime Bithday { get; set; }

        /// <summary>
        /// Внешний ключ для место рождения
        /// </summary>
        public int? id_Bithplace { get; set; }

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
        /// <summary>
        /// Псевдоним
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Ссылка на фото
        /// </summary>
        public string MediaLink { get; set; }
        /// <summary>
        /// Место рождения <see cref="CountryPlace"/>
        /// </summary>
        [ForeignKey("id_Bithplace")]
        public virtual CountryPlace Place { get; set; }

        /// <summary>
        /// Пол <see cref="Enums.Sex"/>
        /// </summary>
        public Sex Sex { get; set; }
    }
}
