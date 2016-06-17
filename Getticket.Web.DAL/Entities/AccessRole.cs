using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Роли доступа пользователя к методам контроллера 
    /// </summary>
    class AccessRole : BaseEntity
    {
        /// <summary>
        /// Список всех ролей котоые имеет пользователь
        /// </summary>
        public AccessRoleType Role { get; set; }

        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание роли
        /// </summary>
        public string Desciption { get; set; }
    }
}
