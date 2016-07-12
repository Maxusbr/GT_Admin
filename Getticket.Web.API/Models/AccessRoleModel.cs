using Getticket.Web.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель системных ролей <see cref="AccessRole"/> (используется для ответов API)
    /// </summary>
    public class AccessRoleModel
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Список системных ролей через ";"
        /// </summary>
        [Required]
        public string Roles { get; set; }

        /// <summary>
        /// Имя роли
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание роли
        /// </summary>
        public string Desciption { get; set; }
    }
}