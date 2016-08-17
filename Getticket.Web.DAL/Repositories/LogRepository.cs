using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using Getticket.Web.DAL.Infrastructure;
using Getticket.Web.DAL.IRepositories;

namespace Getticket.Web.DAL.Repositories
{
    /// <summary>
    /// <see cref="ITagRepository"/>
    /// </summary>
    public class LogRepository : BaseRepository<PersonLog>, ILogRepository
    {

        /// <see cref="ILogRepository.GetPersonLogs" />
        public IList<PersonLog> GetPersonLogs(int personId)
        {
            return
                db.PersonLogs.Where(o => o.IdPerson == personId && o.Type == LogType.Entity)
                    .OrderByDescending(o => o.Date)
                    .Include(o => o.User)
                    .ToList();
        }

        /// <see cref="ILogRepository.GetLastChangePerson" />
        public PersonLog GetLastChangePerson(int personId)
        {
            return db.PersonLogs.OrderByDescending(o => o.Date)
                .FirstOrDefault(o => o.IdPerson == personId && o.Type == LogType.Entity); ;
        }

        /// <see cref="ILogRepository.GetLastChangePersonDescription" />
        public PersonLog GetLastChangePersonDescription(int personId, int id)
        {
            return
                db.PersonLogs.OrderByDescending(o => o.Date).Include(o => o.User)
                    .FirstOrDefault(o => o.IdPerson == personId && o.IdProperty == id && o.Type == LogType.Description);
        }

        /// <see cref="ILogRepository.GetLastChangePersonFact" />
        public PersonLog GetLastChangePersonFact(int personId, int id)
        {
            return
                db.PersonLogs.OrderByDescending(o => o.Date).Include(o => o.User)
                    .FirstOrDefault(o => o.IdPerson == personId && o.IdProperty == id && o.Type == LogType.Fact);
        }

        /// <see cref="ILogRepository.GetLastChangePersonConnection" />
        public PersonLog GetLastChangePersonConnection(int personId, int id)
        {
            return
                db.PersonLogs.OrderByDescending(o => o.Date).Include(o => o.User)
                    .FirstOrDefault(o => o.IdPerson == personId && o.IdProperty == id && o.Type == LogType.Connection);
        }

        /// <see cref="ILogRepository.GetLastChangePersonMedia" />
        public PersonLog GetLastChangePersonMedia(int personId, int id)
        {
            return
                db.PersonLogs.OrderByDescending(o => o.Date).Include(o => o.User)
                    .FirstOrDefault(o => o.IdPerson == personId && o.IdProperty == id && o.Type == LogType.Media);
        }

        /// <see cref="ILogRepository.GetLastChangePersonLink" />
        public PersonLog GetLastChangePersonLink(int personId, int id)
        {
            return
                db.PersonLogs.OrderByDescending(o => o.Date).Include(o => o.User)
                    .FirstOrDefault(o => o.IdPerson == personId && o.IdProperty == id && o.Type == LogType.Link);
        }

        /// <see cref="ILogRepository.GetLastChangePersonAntro" />
        public PersonLog GetLastChangePersonAntro(int personId, int id)
        {
            return
                db.PersonLogs.OrderByDescending(o => o.Date).Include(o => o.User)
                    .FirstOrDefault(o => o.IdPerson == personId && o.IdProperty == id && o.Type == LogType.Anthropometry);
        }

        /// <see cref="ILogRepository.GetLastChangeEventConnection" />
        public EventLog GetLastChangeEventConnection(int idEvent, int id)
        {
            return db.EventLogs.OrderByDescending(o => o.Date)
                .FirstOrDefault(o => o.EventId == idEvent && o.Type == LogType.Entity);
        }

        /// <see cref="ILogRepository.GetLastChangeEventMedia" />
        public EventLog GetLastChangeEventMedia(int idEvent, int id)
        {
            return
                db.EventLogs.OrderByDescending(o => o.Date).Include(o => o.User)
                    .FirstOrDefault(o => o.EventId == idEvent && o.IdProperty == id && o.Type == LogType.Media);
        }

        /// <see cref="ILogRepository.GetLastChangeEventDescription" />
        public EventLog GetLastChangeEventDescription(int idEvent, int id)
        {
            return
                db.EventLogs.OrderByDescending(o => o.Date).Include(o => o.User)
                    .FirstOrDefault(o => o.EventId == idEvent && o.IdProperty == id && o.Type == LogType.Description);
        }
    }
}
