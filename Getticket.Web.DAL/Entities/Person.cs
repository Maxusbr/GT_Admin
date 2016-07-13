using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime Bithday { get; set; }

        /// <summary>
        /// Внешний ключ для место рождения
        /// </summary>
        public int id_Bithplace { get; set; }

        /// <summary>
        /// Внешний ключ для пола
        /// </summary>
        public int id_Sex { get; set; }

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
        /// Место рождения <see cref="CountryPlace"/>
        /// </summary>
        [ForeignKey("id_Bithplace")]
        public virtual CountryPlace Place { get; set; }

        /// <summary>
        /// Пол <see cref="Entities.Sex"/>
        /// </summary>
        [ForeignKey("id_Sex")]
        public virtual Sex Sex { get; set; }
    }
}
