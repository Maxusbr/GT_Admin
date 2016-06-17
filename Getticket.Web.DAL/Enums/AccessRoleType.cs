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
        None = 0,
        Admin = 1
    }
}
