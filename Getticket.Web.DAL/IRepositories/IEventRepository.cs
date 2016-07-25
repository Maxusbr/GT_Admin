using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// Интерфейс для работы с сущностью <see cref="Event" />
    /// </summary>
    public interface IEventRepository : IDisposable
    {
        /// <summary>
        /// Возвращает список <see cref="Event"/>
        /// </summary>
        /// <returns></returns>
        IList<Event> GetEvents();
    }
}
