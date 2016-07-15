using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Sex
    /// </summary>
    public class Sex : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Sex(){}

        /// <summary>
        /// Название
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
