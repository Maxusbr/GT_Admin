using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;

namespace Getticket.Web.DAL.Repositories
{
    /// <see cref="IEventRepository" />
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        /// <see cref="IEventRepository.GetEvents" />
        public IList<Event> GetEvents()
        {
            var query = db.Events
                .Where(o => true)
                .Include(o => o.EventType);
            return GetAll(query);
        }
    }
}
