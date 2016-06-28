using System;

namespace Getticket.Web.DAL.Enums
{
    /// <summary>
    /// Роли доступа(с флагами) на контроллер;
    /// None - недопустима
    /// </summary>
    [Flags]
    public enum AccessRoleType
    {
        /// <summary>
        /// Пустая роль, не должна присатствовать ни у одного пользователя
        /// </summary>
        None = 0,
        Admin = 1
    }
}
