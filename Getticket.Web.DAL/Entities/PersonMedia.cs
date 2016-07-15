using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Медиа а файлы
    /// </summary>
    public class PersonMedia : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonMedia(){}

        /// <summary>
        /// Внешний ключ для <see cref="Person"/>
        /// </summary>
        public int id_Person { get; set; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string MediaLink { get; set; }

        /// <summary>
        /// <see cref="Entities.Person"/>
        /// </summary>
        [ForeignKey("id_Person")]
        public virtual Person Person { get; set; }
    }
}
