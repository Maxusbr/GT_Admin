using Getticket.Web.API.Helpers;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Repository
{
    public class UserRepository : BaseRepository<User>
    {

        public UserRepository()
        {
        }

        public IList<User> FindAllNotDeleted()
        {
            IQueryable<User> query = db.Users.Where(u => u.UserStatus.Status != UserStatusType.Deleted);
            IList<User> users = null;
            if (query.Any())
            {
                users = query.ToList();
            }
            return users;
        }

        public User FindById(int Id)
        {
            IQueryable<User> query = db.Users.Where(u => u.Id == Id);
            User user = null;
            if (query.Any())
            {
                user = query.First();
            }
            return user;
        }

        public IList<User> FindAllByEmail(string email)
        {
            IQueryable<User> query = db.Users.Where(u => u.UserName.Equals(email));
            IList<User> users = null;
            if (query.Any())
            {
                users = query.ToList();
            }
            return users;
        }

        public bool MarkDelete(int Id)
        {
            User user = this.FindById(Id);
            if (user == null)
            {
                return false;
            }
            user.UserStatus = UserStatusHelper.Deleted(user.UserStatus.Id);
            db.SaveChanges();
            return true;
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
