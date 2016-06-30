using Getticket.Web.DAL.Entities;
using System.Collections.Generic;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.IRepositories;
using Getticket.Web.API.Helpers;
using Getticket.Web.DAL.Enums;
using System;

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

        /// <summary>
        /// Сохраняет, обновляет <see cref="AccessRole"/> роль пользователя в БД
        /// </summary>
        /// <returns></returns>
        public ServiceResponce SaveRole()
        {


            throw new NotImplementedException();
        }

        /// <summary>
        /// Предоставляет карту ключ -> значение для доступных типов <see cref="AccessRoleType"/>
        /// </summary>
        /// <returns></returns>
        public IDictionary<int, string> GetAvailableRoleTypes()
        {
            IDictionary<int, string> rolesNames = new Dictionary<int, string>();

            foreach (AccessRoleType role in Enum.GetValues(typeof(AccessRoleType)))
            {
                if (role != AccessRoleType.None)
                {
                    rolesNames.Add((int) role, role.ToString());
                }
            }

            return rolesNames;
        }
    }
}