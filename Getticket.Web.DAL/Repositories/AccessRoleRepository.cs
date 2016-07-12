using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Getticket.Web.DAL.Repositories
{
    /// <see cref="IAccessRoleRepository"/>
    public class AccessRoleRepository : BaseRepository<AccessRole>, IAccessRoleRepository
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AccessRoleRepository()
        {
            this.db.Configuration.LazyLoadingEnabled = false;
        }

        /// <see cref="IAccessRoleRepository.GetAll"/>
        public IList<AccessRole> GetAll()
        {
            IQueryable<AccessRole> query = db.AccessRoles.Where(ar => true);
            return GetAll(query);
        }

        /// <see cref="IAccessRoleRepository.GetAllByRole"/>
        public IList<User> GetAllByRole(int Id)
        {
            IQueryable<AccessRole> query = db.AccessRoles
                .Include("Users")
                .Include("Users.UserStatus")
                .Include("Users.UserInfo")
                .Where(ar => ar.Id == Id);

            AccessRole role = GetOne(query);
            if (role == null || !role.Users.Any())
            {
                return null;
            }
            else
            {
                return role.Users.ToList();
            }
        }

        /// <see cref="IAccessRoleRepository.GetOneById(int)"/>
        public AccessRole GetOneById(int id) {
            IQueryable<AccessRole> query = db.AccessRoles
                .Where(ar => ar.Id == id);
            return GetOne(query);
        }
    }
}
