using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using System.Collections.Generic;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class AccessRoleModelHelper
    {
        /// <summary>
        /// Получает <see cref="AccessRoleModel"/> из <paramref name="role"/>
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static AccessRoleModel GetAccessRoleModel(AccessRole role)
        {
            if (role == null)
            {
                return null;
            }

            return new AccessRoleModel()
            {
                Id = role.Id,
                Name = role.Name,
                Desciption = role.Desciption,
                Roles = role.Role.ToString()
            };
        }

        /// <summary>
        /// Получает список <see cref="AccessRoleModel"/> из списка <paramref name="roles"/>
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static IList<AccessRoleModel> GetAccessRoleModel(IList<AccessRole> roles)
        {
            if (roles == null)
            {
                return null;
            }

            IList<AccessRoleModel> toReturn = new List<AccessRoleModel>(roles.Count);
            foreach(AccessRole rol in roles)
            {
                toReturn.Add(GetAccessRoleModel(rol));
            }
            return toReturn;
        }
    }
}