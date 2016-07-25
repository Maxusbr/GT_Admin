using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using System.Collections.Generic;
using System.Linq;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.Repositories
{
    /// <summary>
    /// <see cref="IAuthRepository" />
    /// </summary>
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AuthRepository()
        {
            // Отключаем ленивую загрузку для ускорения работы
            this.db.Configuration.LazyLoadingEnabled = false;
        }

        /// <see cref="IAuthRepository.FindAllByName(string, string, UserStatusType)"/>
        public IList<User> FindAllByName(string UserName, string PasswordHash, UserStatusType Status)
        {
            IQueryable<User> query = db.Users
                .Include("AccessRoles")
                .Where(u => (u.Password.Equals(PasswordHash)
                              && u.UserStatuses.Status == Status
                              && u.UserName.Equals(UserName)));
            return GetAll(query);
        }

        /// <see cref="IAuthRepository.FindAllByNamePhone(string, string, string, UserStatusType)"/>
        public IList<User> FindAllByNamePhone(string UserName, string Phone, string PasswordHash, UserStatusType Status)
        {
            IQueryable<User> query = db.Users
                .Include("AccessRoles")
                .Where(u => (u.Password.Equals(PasswordHash)
                              && u.UserStatuses.Status == Status
                              && (u.UserName.Equals(UserName)
                                   || u.UserPhone.Equals(Phone))));
            return GetAll(query);
        }

        /// <see cref="IAuthRepository.FindAllByPhone(string, string, UserStatusType)"/>
        public IList<User> FindAllByPhone(string Phone, string PasswordHash, UserStatusType Status)
        {
            IQueryable<User> query = db.Users
                .Include("AccessRoles")
                .Where(u => (u.Password.Equals(PasswordHash)
                              && u.UserStatuses.Status == Status
                              && u.UserPhone.Equals(Phone)));
            return GetAll(query);
        }
    }
}
