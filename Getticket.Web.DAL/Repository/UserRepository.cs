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
            return db.Users.ToList();
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

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
