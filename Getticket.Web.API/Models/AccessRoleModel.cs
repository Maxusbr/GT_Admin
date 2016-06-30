using Getticket.Web.DAL.Entities;

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
        public int Id { get; set; }

        /// <summary>
        /// Список системных ролей через ";"
        /// </summary>
        public string Roles { get; set; }

        /// <summary>
        /// Имя роли
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание роли
        /// </summary>
        public string Desciption { get; set; }
    }
}