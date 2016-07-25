using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Getticket.Web.DAL.Repositories
{
    /// <see cref="IAccessRoleRepository"/>
    public class AccessRoleRepository : BaseRepository<AccessRoles>, IAccessRoleRepository
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AccessRoleRepository()
        {
            this.db.Configuration.LazyLoadingEnabled = false;
        }

        /// <see cref="IAccessRoleRepository.GetAll"/>
        public IList<AccessRoles> GetAll()
        {
            IQueryable<AccessRoles> query = db.AccessRoles.Where(ar => true);
            return GetAll(query);
        }

        /// <see cref="IAccessRoleRepository.GetAllByRole"/>
        public IList<User> GetAllByRole(int Id)
        {
            IQueryable<AccessRoles> query = db.AccessRoles
                .Include("Users")
                .Include("Users.UserStatuses")
                .Include("Users.UserInfo")
                .Where(ar => ar.Id == Id);

            AccessRoles role = GetOne(query);
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
        public AccessRoles GetOneById(int id) {
            IQueryable<AccessRoles> query = db.AccessRoles
                .Where(ar => ar.Id == id);
            return GetOne(query);
        }
    }
}
