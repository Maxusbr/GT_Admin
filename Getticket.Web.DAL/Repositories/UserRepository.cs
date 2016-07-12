﻿using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
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
            = (u =>u.UserStatus.Status != UserStatusType.MarkDeleted);

        /// <summary>
        /// Приглашенный пользователь
        /// </summary>
        private Expression<Func<User, bool>> UserInvited 
            = (u => (u.UserStatus.Status == UserStatusType.Invite 
                    || u.UserStatus.Status == UserStatusType.AcceptInvite));

        /// <see cref="IUserRepository.FindAllNotDeleted" />
        public IList<User> FindAllNotDeleted()
        {
            IQueryable<User> query = db.Users.Where(UserNotDeleted);
            return GetAll(query);
        }

        /// <see cref="IUserRepository.FindAllInvited" />
        public IList<User> FindAllInvited()
        {
            IQueryable<User> query = db.Users.Where(UserInvited);
            return GetAll(query);
        }

        /// <see cref="IUserRepository.FindOneById(int)" />
        public User FindOneById(int Id)
        {
            if (Id <= 0)
            {
                return null;
            }
            IQueryable<User> query = db.Users.Where(u => u.Id == Id);
            return GetOne(query);
        }

        /// <see cref="IUserRepository.FindOneByEmail(string)"/>
        public User FindOneByEmail(string Email) {
            if (Email == null) {
                return null;
            }
            IQueryable<User> query = db.Users.Where(u => u.UserName.Equals(Email));
            return GetOne(query);
        }

        /// <see cref="IUserRepository.CountByCredentails(string, string)" />
        public int CountByCredentails(string email, string phone)
        {
            IQueryable<User> query = db.Users
                .Where(UserNotDeleted);

            if (phone == null)
            {
                query = query.Where(u => u.UserName.Equals(email));
            }
            else
            {
                query = query.Where(u => (u.UserName.Equals(email)) || (u.Phone.Equals(phone)));
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
                query = query.Where(u => u.UserName.Equals(email));
            }
            else
            {
                query = query.Where(u => (u.UserName.Equals(email)) || (u.Phone.Equals(phone)));
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

        /// <see cref="IUserRepository.DeleteUserByEmail(string)" />
        public bool DeleteUserByEmail(string userName)
        {
            throw new NotImplementedException();
        }


    }
}