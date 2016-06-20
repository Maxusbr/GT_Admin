using Getticket.Web.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.Repository
{
    public class UserRepository : IDisposable
    {
        private GetticketDBContext db;

        public UserRepository()
        {
            this.db = new GetticketDBContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public User Add(User Entity)
        {
            db.Users.Add(Entity);
            db.SaveChanges();
            return Entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public User Update(User Entity)
        {
            User UserToSave = db.Users.Find(Entity.Id);
            if (UserToSave == null)
            {
                return null;
            }
            else
            {
                db.Entry(UserToSave).CurrentValues.SetValues(Entity);
                db.SaveChanges();
                return UserToSave;
            }
        }

        public IList<User> FindAll()
        {
            return db.Users.Where(item => item.UserStatus.Status != Enums.UserStatusType.Deleted).ToList();
        }

        public IList<User> FindAllDeleted()
        {
            throw new NotImplementedException();
        }

        public User Find(int Id)
        {
            return db.Users.Find(Id);
        }

        public bool Delete(int Id)
        {
            User user = db.Users.Find(Id);
            if (user == null)
            {
                return true;
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }

        public bool MarkDelete(int Id)
        {
            User user = db.Users.Find(Id);
            if (user == null)
            {
                return false;
            }
            user.UserStatus.Status = Enums.UserStatusType.Deleted;
            db.SaveChanges();
            return true;
        }

        public User FindOneByEmail(string Email)
        {
            IQueryable<User> query = db.Users.Where(item => item.UserName == Email);
            if (!query.Any())
            {
                return null;
            }
            else
            {
                return query.First();
            }
        }

        public List<User> FindAllByEmail(string email)
        {
            List<User> users = db.Users.Where(item => item.UserName == email).ToList();
            int count = users.Count;
            if (count == 0)
            {
                return null;
            }
            return users;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
