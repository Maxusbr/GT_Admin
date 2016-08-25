using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель пользователя (используется для ответов API)
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public UserStatusType Status { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public DateTime? LastEnter { get; set; }
        public string Roles { get; set; }
        public int RoleId { get; set; }
    }
}