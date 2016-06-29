using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель системных ролей <see cref="AccessRole"/> (используется для ответов API)
    /// </summary>
    public class AccessRoleModel
    {
        public int Id { get; set; }

        public AccessRoleType Role { get; set; }

        public string Name { get; set; }

        public string Desciption { get; set; }
    }
}