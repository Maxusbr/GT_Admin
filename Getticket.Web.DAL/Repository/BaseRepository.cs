using Getticket.Web.DAL.Entities;
using System;

namespace Getticket.Web.DAL.Repository
{
    public class BaseRepository<T> : IDisposable where T : BaseEntity
    {
        protected GetticketDBContext db;

        public BaseRepository()
        {
            this.db = new GetticketDBContext();
        }

        public virtual T Save(T Entity)
        {
            if (Entity.Id == 0)
            {
                db.Entry(Entity).State = System.Data.Entity.EntityState.Added;
            }
            else if (Entity.Id > 0)
            {
                db.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return Entity;
        }

        public virtual bool Delete(T Entity)
        {
            if (Entity.Id < 1)
            {
                return false;
            }
            db.Entry(Entity).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
