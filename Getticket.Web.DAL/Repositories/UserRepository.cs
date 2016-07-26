using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Getticket.Web.DAL.IRepositories;
using System.Linq.Expressions;

namespace Getticket.Web.DAL.Repositories
{
    /// <summary>
    /// <see cref="IUserRepository" />
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Пользователь НЕ помечен как удаленный
        /// </summary>
        private Expression<Func<User, bool>> UserNotDeleted
            = (u => u.UserStatuses.Status != UserStatusType.MarkDeleted);

        /// <summary>
        /// Приглашенный пользователь
        /// </summary>
        private Expression<Func<User, bool>> UserInvited
            = (u => (u.UserStatuses.Status == UserStatusType.Invite
                    || u.UserStatuses.Status == UserStatusType.AcceptInvite));

        /// <see cref="IUserRepository.FindAllNotDeleted" />
        public IList<User> FindAllNotDeleted()
        {
            IQueryable<User> query = db.Users.Where(UserNotDeleted)
                .Include(o => o.UserInfo)
                .Include(o => o.UserStatuses)
                .Include(o => o.AccessRoles);
            return GetAll(query);
        }

        /// <see cref="IUserRepository.FindAllInvited" />
        public IList<User> FindAllInvited()
        {
            IQueryable<User> query = db.Users.Where(UserInvited)
                .Include(o => o.UserInfo)
                .Include(o => o.UserStatuses)
                .Include(o => o.AccessRoles);
            return GetAll(query);
        }

        /// <see cref="IUserRepository.FindOneById(int)" />
        public User FindOneById(int Id)
        {
            if (Id <= 0)
            {
                return null;
            }
            IQueryable<User> query = db.Users.Where(u => u.Id == Id)
                .Include(o => o.UserInfo)
                .Include(o => o.UserStatuses)
                .Include(o => o.AccessRoles);
            return GetOne(query);
        }

        /// <see cref="IUserRepository.FindOneByEmail(string)"/>
        public User FindOneByEmail(string Email)
        {
            if (Email == null)
            {
                return null;
            }
            IQueryable<User> query = db.Users.Where(u => u.UserName.Equals(Email))
                .Include(o => o.UserInfo)
                .Include(o => o.UserStatuses)
                .Include(o => o.AccessRoles);
            return GetOne(query);
        }

        /// <see cref="IUserRepository.CountByCredentails(string, string)" />
        public int CountByCredentails(string email, string phone)
        {
            IQueryable<User> query = db.Users
                .Where(UserNotDeleted);

            if (phone == null)
            {
                query = query.Where(u => u.UserName.Equals(email))
                    .Include(o => o.UserInfo)
                .Include(o => o.UserStatuses)
                .Include(o => o.AccessRoles);
            }
            else
            {
                query = query.Where(u => (u.UserName.Equals(email)) || (u.UserPhone.Equals(phone)))
                    .Include(o => o.UserInfo)
                .Include(o => o.UserStatuses)
                .Include(o => o.AccessRoles);
            }

            return query.Count();
        }

        /// <see cref="IUserRepository.FindAllByCredentails(string, string)" />
        public IList<User> FindAllByCredentails(string email, string phone)
        {
            IQueryable<User> query = db.Users
              .Where(UserNotDeleted);

            if (phone == null)
            {
                query = query.Where(u => u.UserName.Equals(email))
                    .Include(o => o.UserInfo)
                .Include(o => o.UserStatuses)
                .Include(o => o.AccessRoles);
            }
            else
            {
                query = query.Where(u => (u.UserName.Equals(email)) || (u.UserPhone.Equals(phone)))
                    .Include(o => o.UserInfo)
                .Include(o => o.UserStatuses)
                .Include(o => o.AccessRoles);
            }

            return GetAll(query);
        }

        /// <see cref="IUserRepository.Save(User)" />
        public override User Save(User Entity)
        {
            return base.Save(Entity);
        }

        /// <see cref="IUserRepository.Delete(int)">
        public bool Delete(int Id)
        {
            if (Id < 1)
            {
                return false;
            }
            IQueryable<User> query = db.Users.Where(u => u.Id == Id);
            if (!query.Any())
            {
                return false;
            }
            User user = query.First();
            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IUserRepository.Delete(User)" />
        public override bool Delete(User Entity)
        {
            return this.Delete(Entity.Id);
        }

        /// <see cref="IUserRepository.UpdateLastEnter" />
        public bool UpdateLastEnter(int id, DateTime dt)
        {
            var user = FindOneById(id);
            if (user == null) return false;
            user.LastEnter = dt;
            db.SaveChanges();
            return true;
        }

        /// <see cref="IUserRepository.DeleteUserByEmail(string)" />
        public bool DeleteUserByEmail(string userName)
        {
            throw new NotImplementedException();
        }


    }
}
