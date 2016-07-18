using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : class
    {
        T Save(T Entity);
        bool Delete(T Entity);
        IList<T> GetAll(IQueryable<T> query);
        T GetOne(IQueryable<T> query);
    }
}
