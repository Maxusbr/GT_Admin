﻿using System;
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
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Repositories
{
    /// <see cref="IEventRepository" />
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        /// <see cref="IEventRepository.GetEvents" />
        public IList<Event> GetEvents()
        {
            var query = db.Events
                .Where(o => o.IsReallyEvent)
                .Include(o => o.Category)
                .Include(o => o.Category.ParentCategory)
                .Include(o => o.Organizer);
            return GetAll(query);
        }

        /// <see cref="IEventRepository.FindEventById" />
        public Event FindEventById(int id)
        {
            if (id <= 0) return null;
            var _event = db.Events.Where(u => u.Id == id)
                .Include(o => o.Category)
                .FirstOrDefault();
            return _event;
        }

        /// <see cref="IEventRepository.SaveEvent" />
        public Event SaveEvent(Event _event, int userId)
        {
            if (_event.Id == 0)
            {
                db.Entry(_event).State = System.Data.Entity.EntityState.Added;
            }
            else if (_event.Id > 0)
            {
                var pr = db.Events.FirstOrDefault(o => o.Id == _event.Id);
                SaveLog(pr, _event, _event.Id, userId, LogType.Entity);
                db.Entry(pr).CurrentValues.SetValues(_event);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return _event;
        }

        /// <see cref="IEventRepository.DeleteEvent" />
        public bool DeleteEvent(int id)
        {
            if (id <= 0) return false;
            var _event = db.Events.FirstOrDefault(u => u.Id == id);
            if (_event == null) return false;
            db.Events.Remove(_event);
            db.SaveChanges();
            return true;
        }
        

        /// <see cref="IEventRepository.GetConnectionTypes" />
        public IList<ConnectionType> GetConnectionTypes()
        {
            return db.ConnectionTypes.ToList();
        }

        /// <see cref="IEventRepository.UpdateConnectionType" />
        public ConnectionType UpdateConnectionType(ConnectionType type)
        {
            if (type.Id == 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Added;
            }
            else if (type.Id > 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return type;
        }

        /// <see cref="IEventRepository.DeleteConnectionType" />
        public bool DeleteConnectionType(int id)
        {
            if (id <= 0) return false;
            var item = db.ConnectionTypes.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.ConnectionTypes.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IEventRepository.GetConnections" />
        public IList<EventConnection> GetConnections(int id)
        {
            return db.EventConnections.Where(o => o.id_Event == id)
                .Include(o => o.Event)
                .Include(o => o.Event.Category)
                .Include(o => o.Event.Category.ParentCategory)
                .Include(o => o.ConnectionType)
                .Include(o => o.EventConnectTo)
                .ToList();
        }

        /// <see cref="IEventRepository.AddConnections" />
        public bool AddConnections(IList<EventConnection> connections, int userId)
        {
            return connections.All(el => SaveConnection(el, userId) != null);
        }

        /// <see cref="IEventRepository.SaveConnection" />
        public EventConnection SaveConnection(EventConnection connection, int userId)
        {
            if (connection.Id == 0)
            {
                db.Entry(connection).State = System.Data.Entity.EntityState.Added;
            }
            else if (connection.Id > 0)
            {
                var pr = db.EventConnections.FirstOrDefault(o => o.Id == connection.Id);
                SaveLog(pr, connection, connection.id_Event, userId, LogType.Connection);
                db.Entry(pr).CurrentValues.SetValues(connection);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return connection;
        }

        /// <see cref="IEventRepository.DeleteConnections" />
        public bool DeleteConnections(IList<EventConnection> connections)
        {
            foreach (var connect in connections.Select(el => db.EventConnections.FirstOrDefault(o => o.Id == el.Id)))
            {
                if (connect == null) return false;
                db.EventConnections.Remove(connect);
            }
            db.SaveChanges();
            return true;
        }

        /// <see cref="IEventRepository.GetDescriptionTypes" />
        public IList<EventDescriptionType> GetDescriptionTypes()
        {
            return db.EventDescriptionTypes.ToList();
        }

        /// <see cref="IEventRepository.UpdateDescriptionType" />
        public EventDescriptionType UpdateDescriptionType(EventDescriptionType type)
        {
            if (type.Id == 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Added;
            }
            else if (type.Id > 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return type;
        }

        /// <see cref="IEventRepository.DeleteDescriptionType" />
        public bool DeleteDescriptionType(int id)
        {
            if (id <= 0) return false;
            var item = db.EventDescriptionTypes.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.EventDescriptionTypes.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IEventRepository.GetDescriptions" />
        public IList<EventDescription> GetDescriptions(int id)
        {
            var listLink = db.EventDescriptionTizerLinks.Include(o => o.Tizer).Where(o => o.Tizer.IdEvent == id).ToList();

            var list = new List<EventDescription>();

            foreach (var el in listLink)
            {
                var item = db.EventDescriptions.Where(o => o.Id == el.IdTizer)
                    .Include(o => o.DescriptionType)
                    .Include(o => o.PageBlock)
                    .Include(o => o.PageBlock.Page)
                    .FirstOrDefault();
                if (item == null) continue;
                item.StaticDescription = db.EventDescriptions.Where(o => o.Id == el.IdStaticDescription)
                    .Include(o => o.DescriptionType)
                    .Include(o => o.PageBlock)
                    .Include(o => o.PageBlock.Page).FirstOrDefault();
                list.Add(item);
            }
            var list1 = listLink.Select(s => s.IdTizer).Distinct();
            var list2 = listLink.Select(s => s.IdStaticDescription).Distinct();
            list.AddRange(
                db.EventDescriptions.Where(o => o.IdEvent == id && (!list1.Contains(o.Id) && !list2.Contains(o.Id)))
                .Include(o => o.DescriptionType)
                    .Include(o => o.PageBlock)
                    .Include(o => o.PageBlock.Page)
                );
            return list;
        }

        /// <see cref="IEventRepository.UpdateDescription" />
        public EventDescription UpdateDescription(EventDescription description, int userId)
        {
            if (description.Id == 0)
            {
                db.Entry(description).State = System.Data.Entity.EntityState.Added;
            }
            else if (description.Id > 0)
            {
                var pr = db.EventDescriptions.FirstOrDefault(o => o.Id == description.Id);
                SaveLog(pr, description, description.IdEvent, userId, LogType.Description);
                db.Entry(pr).CurrentValues.SetValues(description);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return description;
        }

        /// <see cref="IEventRepository.DeleteDescription" />
        public bool DeleteDescription(int id)
        {
            if (id <= 0) return false;
            var item = db.EventDescriptions.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.EventDescriptions.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IEventRepository.GetMedia" />
        public IList<EventMedia> GetMedia(int id)
        {
            return db.EventMedias.Where(o => o.IdEvent == id).Include(o => o.MediaType).ToList();
        }

        /// <see cref="IEventRepository.UpdateMedia" />
        public EventMedia UpdateMedia(EventMedia media, int userId)
        {
            if (media.Id == 0)
            {
                db.Entry(media).State = System.Data.Entity.EntityState.Added;
            }
            else if (media.Id > 0)
            {
                var pr = db.EventMedias.FirstOrDefault(o => o.Id == media.Id);
                SaveLog(pr, media, media.IdEvent, userId, LogType.Media);
                db.Entry(pr).CurrentValues.SetValues(media);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return media;
        }

        /// <see cref="IEventRepository.DeleteMedia" />
        public bool DeleteMedia(int id)
        {
            if (id <= 0) return false;
            var item = db.EventMedias.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.EventMedias.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IEventRepository.GetMediaTypes" />
        public IList<MediaType> GetMediaTypes()
        {
            return db.MediaTypes.ToList();
        }

        /// <see cref="IEventRepository.UpdateMediaType" />
        public MediaType UpdateMediaType(MediaType type)
        {
            if (type.Id == 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Added;
            }
            else if (type.Id > 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return type;
        }

        /// <see cref="IEventRepository.DeleteMediaType" />
        public bool DeleteMediaType(int id)
        {
            if (id <= 0) return false;
            var item = db.MediaTypes.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.MediaTypes.Remove(item);
            db.SaveChanges();
            return true;
        }

        
        /// <see cref="IEventRepository.GetCountDescriptions" />
        public int GetCountDescriptions(int id)
        {
            return db.EventDescriptions.Count(o => o.IdEvent == id);
        }

        /// <see cref="IEventRepository.GetCountConnects" />
        public int GetCountConnects(int id)
        {
            return db.EventConnections.Count(o => o.id_Event == id);
        }

        /// <see cref="IEventRepository.GetCountMedias" />
        public int GetCountMedias(int id)
        {
            return db.EventMedias.Count(o => o.IdEvent == id);
        }

        /// <see cref="IEventRepository.GetCategories" />
        public IList<EventCategory> GetCategories()
        {
            return db.EventCategories.ToList();
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
                ChengeFrom = JsonConvert.SerializeObject(from),
                ChangeTo = JsonConvert.SerializeObject(to)
            };
            db.Entry(log).State = System.Data.Entity.EntityState.Added;
            //db.PersonLogs.Add(log);
            //db.SaveChanges();
        }
    }
}
