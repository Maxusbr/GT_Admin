using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Тип медиа
    /// </summary>
    public class PersonMediaType : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonMediaType(){}

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string Name { get; set; }

    }
}
