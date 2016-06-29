using Getticket.Web.DAL.Entities;
using System.Collections.Generic;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.IRepositories;
using Getticket.Web.API.Helpers;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис предоставляющий доступ к системным ролям <see cref="AccessRole"/>
    /// </summary>
    public class AccessRolesService
    {
        private IAccessRoleRepository AccessRep;
        /// <summary>
        /// Конструктор
        /// </summary>
        public AccessRolesService(IAccessRoleRepository AccessRep)
        {
            this.AccessRep = AccessRep;
        }

        /// <summary>
        /// Получает список всех системных ролей
        /// и оборачивает их в <see cref="AccessRoleModel"/>
        /// </summary>
        /// <returns></returns>
        public IList<AccessRoleModel> GetAllRoles()
        {
            IList<AccessRole> roles = AccessRep.GetAll();
            return AccessRoleModelHelper.GetAccessRoleModel(roles);
        }

        /// <summary>
        /// Получает всех пользователей, которые имеют роль с идентификатором <paramref name="id"/>,
        /// затем оборачивает их в <see cref="UserModel"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<UserModel> GetUsersByRole(int id)
        {
            IList<User> users = AccessRep.GetAllByRole(id);
            return UserModelHelper.GetUserModel(users);
        }
    }
}