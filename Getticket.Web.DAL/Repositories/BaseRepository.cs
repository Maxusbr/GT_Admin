using Getticket.Web.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Getticket.Web.DAL.Repositories
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IDisposable where T : BaseEntity
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        protected GetticketDBContext db;

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseRepository()
        {
            this.db = new GetticketDBContext();
        }

        /// <summary>
        /// Добавляет сущность в БД если ее Id = 0
        /// Пытается обновить ее и зависимые сущности если Id > 0
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
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
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return Entity;
        }

        /// <summary>
        /// Удаляет сущность из БД,
        /// Предполагается что сущность есть в БД;
        /// Для каскадного удаления зависимых сущностей НЕ РАБОТАЕТ!!!
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Очистка ресурсов класса
        /// </summary>
        public void Dispose()
        {
            db.Dispose();
        }

        /// <summary>
        /// IQueryable to List
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        protected IList<T> GetAll(IQueryable<T> query)
        {
            try {
                if (query.Any())
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get first Entity from IQueryable
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        protected T GetOne(IQueryable<T> query)
        {
            if (query.Any())
            {
                return query.First();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get many Entity
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IList<T> GetMany<TOrder>(Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order, 
            params Expression<Func<T, object>>[] includes)
        {
            var dbset = db.Set<T>();
            var query = dbset.OrderBy(order).Where(where);
            query = this.AppendIncludes(query, includes);

            return query.ToList();
        }

        private IQueryable<T> AppendIncludes(IQueryable<T> query, IEnumerable<Expression<Func<T, object>>> includes)
        {
            return includes.Aggregate(query, (current, inc) => current.Include(inc));
        }
    }
}
