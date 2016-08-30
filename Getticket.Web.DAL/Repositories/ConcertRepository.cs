using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using Getticket.Web.DAL.IRepositories;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Repositories
{
    /// <see cref="IConcertRepository" />
    public class ConcertRepository : BaseRepository<Event>, IConcertRepository
    {
        /// <see cref="IConcertRepository.GetConcerts()" />
        public IList<Event> GetConcerts()
        {
            return db.Events.Where(o => o.IsReallyEvent)
                .Include(o => o.Hall)
                .Include(o => o.ConcertPlace)
                .Include(o => o.Series)
                .Include(o => o.Tickets)
                .ToList();
        }

        /// <see cref="IConcertRepository.GetConcerts(int)" />
        public IList<Event> GetConcerts(int eventId)
        {
            return db.Events.Where(o => o.IsReallyEvent && o.ParentId == eventId)
                .Include(o => o.Hall)
                .Include(o => o.Series)
                .Include(o => o.Tickets)
                .Include(o => o.ConcertPlace)
                .ToList();
        }

        /// <see cref="IConcertRepository.GetConcert" />
        public Event GetConcert(int id)
        {
            var result = db.Events.Where(o => o.IsReallyEvent && o.Id == id)
                .Include(o => o.Hall)
                .Include(o => o.Series)
                .Include(o => o.Tickets)
                .Include(o => o.ConcertPlace)
                .Include(o => o.ConcertPlace.CountryPlace)
                .FirstOrDefault();

            return result;
        }

        /// <see cref="IConcertRepository.GetConcertSeriesName" />
        public IList<SeriesName> GetConcertSeriesName()
        {
            return db.Series.ToList();
        }

        /// <see cref="IConcertRepository.GetConcertSchedules" />
        public IList<ConcertDateRange> GetConcertSchedules(int id)
        {
            return db.ConcertDateRanges.Where(o => o.IdEvent == id)
                .Include(o => o.Schedules).ToList();
        }

        /// <see cref="IConcertRepository.GetConcertProgramms" />
        public IList<ConcertProgramm> GetConcertProgramms(int id)
        {
            return db.ConcertProgramms.Where(o => o.IdEvent == id)
                .Include(o => o.Actors)
                .ToList();
        }

        /// <param name="placeId"></param>
        /// <see cref="IConcertRepository.GetHalls" />
        public IList<Hall> GetHalls(int placeId)
        {
            return db.Halls.Where(o => o.ConcertPlace.CountryPlace.Id == placeId).ToList();
        }

        /// <see cref="IConcertRepository.GetConcertPlace" />
        public IList<ConcertPlace> GetConcertPlace(int placeId)
        {
            return db.ConcertPlaces.Where(o => o.PlaceId == placeId)
                .Include(o => o.Halls).ToList();
        }

        /// <see cref="IConcertRepository.GetActorGroups" />
        public IEnumerable<ActorGroup> GetActorGroups()
        {
            return db.ActorGroups.ToList();
        }

        /// <see cref="IConcertRepository.AddConcert" />
        public Event AddConcert(Event model, int userId)
        {
            if (model.Id == 0)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;

            }
            else if (model.Id > 0)
            {
                var pr = db.Events.FirstOrDefault(o => o.Id == model.Id);
                return pr;
            }
            try
            {
                db.SaveChanges();
                SaveLog(null, model, model.Id, userId, LogType.Entity);
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.UpdateConcert" />
        public Event UpdateConcert(Event model, int userId)
        {
            var pr = db.Events.FirstOrDefault(o => o.Id == model.Id);
            if (pr == null) return null;
            db.Entry(pr).CurrentValues.SetValues(model);
            SaveLog(pr, model, model.Id, userId, LogType.Entity);
            try
            {
                db.SaveChanges();
                foreach (var el in model.Series)
                    SaveConcertSeries(model.Id, el.SeriesId);
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.SaveHall" />
        public Hall SaveHall(Hall model)
        {
            if (model.PlaceId == 0)
            {
                var plase = SaveConcertPlace(model.ConcertPlace);
                model.PlaceId = plase.Id;
            }

            if (model.Id == 0)
            {
                db.Entry(model).State = EntityState.Added;
            }
            else if (model.Id > 0)
            {
                var pr = db.Halls.FirstOrDefault(o => o.Id == model.Id);
                db.Entry(pr).CurrentValues.SetValues(model);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.SaveConcertPlace" />
        public ConcertPlace SaveConcertPlace(ConcertPlace model)
        {
            var pr = db.ConcertPlaces.FirstOrDefault(o => o.Name.ToLower().Equals(model.Name.ToLower()) && o.PlaceId == model.PlaceId);
            if (pr != null) return pr;
            if (model.Id == 0)
            {
                db.Entry(model).State = EntityState.Added;
            }
            else if (model.Id > 0)
            {
                pr = db.ConcertPlaces.FirstOrDefault(o => o.Id == model.Id);
                db.Entry(pr).CurrentValues.SetValues(model);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.SaveSeriesName" />
        public SeriesName SaveSeriesName(SeriesName model)
        {
            var pr = db.Series.FirstOrDefault(o => o.Name.ToLower().Equals(model.Name.ToLower()));
            if (pr != null) return pr;
            if (model.Id == 0)
            {
                db.Entry(model).State = EntityState.Added;
            }
            else if (model.Id > 0)
            {
                pr = db.Series.FirstOrDefault(o => o.Id == model.Id);
                db.Entry(pr).CurrentValues.SetValues(model);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.SaveConcertSeries" />
        public SeriesConcert SaveConcertSeries(int concertId, int seriesId)
        {
            var model = db.SeriesConcerts.FirstOrDefault(o => o.EventId == concertId && o.SeriesId == seriesId);
            if (model != null) return model;
            model = new SeriesConcert { EventId = concertId, SeriesId = seriesId };
            db.SeriesConcerts.Add(model);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.SaveConcertSchedule(int, ConcertSchedule)" />
        public ConcertSchedule SaveConcertSchedule(int dateRange, ConcertSchedule model)
        {
            if (model.Id == 0)
            {
                db.Entry(model).State = EntityState.Added;
            }
            else if (model.Id > 0)
            {
                var pr = db.ConcertSchedules.FirstOrDefault(o => o.Id == model.Id);
                db.Entry(pr).CurrentValues.SetValues(model);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.SaveConcertSchedule(int, ConcertDateRange, IEnumerable{ConcertSchedule})" />
        public ConcertDateRange SaveConcertSchedule(int eventId, ConcertDateRange model, IEnumerable<ConcertSchedule> schedules)
        {
            if (model.Id == 0)
            {
                db.Entry(model).State = EntityState.Added;
            }
            else if (model.Id > 0)
            {
                var pr = db.ConcertSchedules.FirstOrDefault(o => o.Id == model.Id);
                db.Entry(pr).CurrentValues.SetValues(model);
            }
            try
            {
                db.SaveChanges();
                foreach (var sch in schedules.Select(item => SaveConcertSchedule(model.Id, item)).Where(sch => sch != null))
                {
                    model.Schedules.Add(sch);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.SaveConcertProgramm(int, ConcertProgramm, IEnumerable{Actor})" />
        public ConcertProgramm SaveConcertProgramm(int eventId, ConcertProgramm model, IEnumerable<Actor> actors)
        {
            var res = SaveConcertProgramm(model);
            if (res != null)
                SaveActors(model.Id, actors);
            return res;
        }

        /// <see cref="IConcertRepository.SaveConcertProgramm(ConcertProgramm)" />
        public ConcertProgramm SaveConcertProgramm(ConcertProgramm model)
        {
            if (model.Id == 0)
            {
                db.Entry(model).State = EntityState.Added;
            }
            else if (model.Id > 0)
            {
                var pr = db.ConcertProgramms.FirstOrDefault(o => o.Id == model.Id);
                db.Entry(pr).CurrentValues.SetValues(model);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        private bool SaveActors(int programmId, IEnumerable<Actor> actors)
        {
            return actors.Select(o => SaveActor(programmId, o)).Any(o => o != null);
        }

        /// <see cref="IConcertRepository.SaveActor" />
        public Actor SaveActor(int programmId, Actor model)
        {
            if(model.Group != null)
            {
                var grp = SaveGroup(model.Group);
                model.IdGroup = grp.Id;
            }
            model.IdProgramm = programmId;
            if (model.Id == 0)
            {
                db.Entry(model).State = EntityState.Added;
            }
            else if (model.Id > 0)
            {
                var pr = db.Actors.FirstOrDefault(o => o.Id == model.Id);
                db.Entry(pr).CurrentValues.SetValues(model);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.SaveGroup" />
        public ActorGroup SaveGroup(ActorGroup model)
        {
            if (model.Id == 0)
            {
                db.Entry(model).State = EntityState.Added;
            }
            else if (model.Id > 0)
            {
                var pr = db.ActorGroups.FirstOrDefault(o => o.Id == model.Id);
                db.Entry(pr).CurrentValues.SetValues(model);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        /// <see cref="IConcertRepository.ExistProgramm" />
        public bool ExistProgramm(int id)
        {
            return db.ConcertProgramms.Any(o => o.IdEvent == id);
        }

        /// <see cref="IConcertRepository.ExistCalendar" />
        public bool ExistCalendar(int id)
        {
            return db.ConcertDateRanges.Any(o => o.IdEvent == id);
        }


        /// <see cref="IConcertRepository.SaveConcertTicket" />
        public ConcertTicket SaveConcertTicket(ConcertTicket model)
        {
            var pr = db.ConcertTickets.FirstOrDefault(o => o.Id == model.Id);
            if (pr == null)
            {
                db.Entry(model).State = EntityState.Added;
            }
            else if (model.Id > 0)
            {
                db.Entry(pr).CurrentValues.SetValues(model);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        private void SaveLog<T>(T from, T to, int eventId, int userId, LogType type) where T : BaseEntity
        {
            var log = new EventLog
            {
                Date = DateTime.Now,
                UserId = userId,
                EventId = eventId,
                IdProperty = to.Id,
                Type = type,
                ChengeFrom = from != null ? JsonConvert.SerializeObject(from) : null,
                ChangeTo = JsonConvert.SerializeObject(to)
            };
            db.Entry(log).State = System.Data.Entity.EntityState.Added;
            //db.PersonLogs.Add(log);
            //db.SaveChanges();
        }

    }
}
