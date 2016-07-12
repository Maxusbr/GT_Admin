using System;

namespace Getticket.Web.DAL.Enums {
    /// <summary>
    /// Роли доступа(с флагами) на контроллер;
    /// None - недопустима
    /// </summary>
    [Flags]
    public enum AccessRoleType {
        /*
         Usage of flags:
         None = 0,
         flg1 = 1 << 1,
         flg2 = 1 << 2,
         flg3 = 1 << 3,
         ...
         flgn = 1 << n
         */

        /// <summary>
        /// Пустая роль, не должна присатствовать ни у одного пользователя
        /// </summary>
        None =              0,

        /// <summary>
        /// Роль пользователя для управления ролями <see cref="AccessRoleType"/>
        /// </summary>
        AccessRoleManager = 1 << 0,

        /// <summary>
        /// Role for debug pupose only
        /// </summary>
        Admin =             1 << 1
    }
}
