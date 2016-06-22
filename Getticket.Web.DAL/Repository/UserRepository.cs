using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Getticket.Web.DAL.IRepositories;
using System.Linq.Expressions;

namespace Getticket.Web.DAL.Repository
{
    /// <summary>
    /// <see cref="IUserRepository" />
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private Expression<Func<User, bool>> UserNotDeleted = (u =>u.UserStatus.Status != UserStatusType.Deleted);

        /// <see cref="IUserRepository.FindAllNotDeleted" />
        public IList<User> FindAllNotDeleted()
        {
            IQueryable<User> query = db.Users.Where(UserNotDeleted);
            return GetAll(query);
        }

        /// <see cref="IUserRepository.FindOneById(int)" />
        public User FindOneById(int Id)
        {
            IQueryable<User> query = db.Users.Where(u => u.Id == Id);
            return GetOne(query);
        }

        /// <see cref="IUserRepository.FindAllByEmail(string)" />
        public IList<User> FindAllByEmail(string email)
        {
            IQueryable<User> query = db.Users
                .Where(UserNotDeleted)
                .Where(u => u.UserName.Equals(email));
            return GetAll(query);
        }

        /// <see cref="IUserRepository.Save(User)" />
        public override User Save(User Entity)
        {
            return base.Save(Entity);
        }

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

        public User FindOneByPhoneAndPassword(string Phone, string PasswordHash)
        {
            IQueryable<User> query = db.Users.Where(u => u.UserInfo.Phone.Equals(Phone) && u.PasswordHash.Equals(PasswordHash));
            User user = null;
            if (query.Any())
            {
                user = query.First();
            }
            return user;
        }

        public User FindOneByEmailAndPassword(string Email, string PasswordHash)
        {
            IQueryable<User> query = db.Users.Where(u => u.UserName.Equals(Email) && u.PasswordHash.Equals(PasswordHash));
            User user = null;
            if (query.Any())
            {
                user = query.First();
            }
            return user;
        }

        public User FindOneByEmailOrPhoneAndPassword(string Email, string Phone, string PasswordHash)
        {
            IQueryable<User> query = db.Users
                .Where(u => (u.UserName.Equals(Email) || u.UserInfo.Phone.Equals(Phone)) 
                            && u.PasswordHash.Equals(PasswordHash));

            User user = null;
            if (query.Any())
            {
                user = query.First();
            }
            return user;
        }

        public override bool Delete(User Entity)
        {
            return this.Delete(Entity.Id);
        }

        public Task<User> UpdateTask(User user)
        {
            User UserToSave = this.Save(user);
            return Task.FromResult(UserToSave);
        }
    }
}
