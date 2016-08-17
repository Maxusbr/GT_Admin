using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Источник
    /// </summary>
    public class UserPageCategory : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
    }
}
