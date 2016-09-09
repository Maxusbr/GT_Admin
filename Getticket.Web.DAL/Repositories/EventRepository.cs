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
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Repositories
{
    /// <see cref="IEventRepository" />
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        /// <see cref="IEventRepository.GetEvents" />
        public IList<Event> GetEvents(bool realy = false)
        {
            var query = db.Events
                .Where(o => o.IsReallyEvent == realy)
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


        #region Connections

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
            IList<EventConnection> answer = db.EventConnections.Where(o => o.id_Event == id)
                .Include(o => o.Event)
                .Include(o => o.Event.Category)
                .Include(o => o.Event.Category.ParentCategory)
                .Include(o => o.ConnectionType)
                .Include(o => o.EventConnectTo)
                .Include(o => o.Person)
                .ToList();

            return answer;
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

        #endregion


        #region descriptions

        /// <see cref="IEventRepository.GetDescriptionTypes" />
        public IList<PersonDescriptionType> GetDescriptionTypes()
        {
            return db.PersonDescriptionType.ToList();
        }

        /// <see cref="IEventRepository.UpdateDescriptionType" />
        public PersonDescriptionType UpdateDescriptionType(PersonDescriptionType type)
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
            var item = db.PersonDescriptionType.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonDescriptionType.Remove(item);
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

        #endregion


        #region Media

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

        /// <see cref="IPersonRepository.LinkMedia(MediaLinkPerson)" />
        public bool LinkMedia(EventMediaLinkPerson model)
        {
            if (model.IdPerson == 0 || model.IdMedia == 0) return false;
            var link =
                db.EventMediaLinkPersons.FirstOrDefault(
                    o => o.IdMedia == model.IdMedia && o.IdPerson == model.IdPerson);

            if (link == null)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
            }
            else
                return true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <see cref="IPersonRepository.LinkMedia(MediaLinkEvent)" />
        public bool LinkMedia(EventMediaLinkEvent model)
        {
            if (model.IdEvent == 0 || model.IdMedia == 0) return false;
            var link =
                db.EventMediaLinkEvents.FirstOrDefault(
                    o => o.IdMedia == model.IdMedia && o.IdEvent == model.IdEvent);

            if (link == null)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
            }
            else
                return true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region facts


        /// <see cref="IPersonRepository.GetPersonFactTypes" />
        public IList<EventFactType> GetEventFactTypes()
        {
            return db.EventFactTypes.ToList();
        }

        /// <see cref="IPersonRepository.UpdateFactType" />
        public EventFactType UpdateFactType(EventFactType type)
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

        /// <see cref="IPersonRepository.DeleteFactType" />
        public bool DeleteFactType(int id)
        {
            if (id <= 0) return false;
            var item = db.EventFactTypes.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.EventFactTypes.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetPersonFacts" />
        public IList<EventFact> GetEventFacts(int id)
        {
            return db.EventFacts.Where(o => o.id_Event == id)
                .Include(o => o.FactType).ToList();
        }

        /// <see cref="IPersonRepository.UpdatePersonFacts" />
        public bool UpdateEventFacts(IList<EventFact> facts, int userId)
        {
            return facts.All(fact => UpdateEventFact(fact, userId) != null);
        }

        /// <see cref="IPersonRepository.UpdatePersonFact" />
        public EventFact UpdateEventFact(EventFact fact, int userId)
        {
            if (fact.Id == 0)
            {
                db.Entry(fact).State = System.Data.Entity.EntityState.Added;
            }
            else if (fact.Id > 0)
            {
                var pr = db.EventFacts.FirstOrDefault(o => o.Id == fact.Id);
                SaveLog(pr, fact, fact.id_Event, userId, LogType.Fact);
                db.Entry(pr).CurrentValues.SetValues(fact);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return fact;
        }

        /// <see cref="IPersonRepository.DeletePersonFact" />
        public bool DeleteEventFact(int id)
        {
            if (id <= 0) return false;
            var item = db.EventFacts.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.EventFacts.Remove(item);
            db.SaveChanges();
            return true;
        }


        /// <see cref="IPersonRepository.GetCountFacts" />
        public int GetCountFacts(int id)
        {
            return db.EventFacts.Count(o => o.id_Event == id);
        }

        #endregion


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

        /// <see cref="IEventRepository.SaveDescriptionSchema" />
        public bool SaveDescriptionSchema(int id, PageBlock pageBlock, UserPageCategory cat, int eventId)
        {
            cat = SaveUserPageCategory(cat);
            var page = SavePage(pageBlock.Page);
            if (page == null) return false;
            pageBlock.IdPage = page.Id;
            var pageblock = SavePageBlock(pageBlock);
            if (pageblock == null) return false;
            var desc = db.EventDescriptions.FirstOrDefault(o => o.Id == id);
            if (desc == null)
            {
                desc = new EventDescription { IdType = 1, IdEvent = eventId };
                db.Entry(desc).State = EntityState.Added;
            }
            desc.IdBlock = pageblock.Id;
            desc.IdUserPageCategory = cat?.Id;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <see cref="IEventRepository.SaveCategory" />
        public EventCategory SaveCategory(EventCategory eventCategory)
        {
            if (eventCategory.Id == 0)
            {
                db.Entry(eventCategory).State = EntityState.Added;
            }
            else if (eventCategory.Id > 0)
            {
                var pr = db.EventCategories.FirstOrDefault(o => o.Id == eventCategory.Id);
                db.Entry(pr).CurrentValues.SetValues(eventCategory);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return eventCategory;
        }
        /// <see cref="IEventRepository.GetMediaPersonLinks" />
        public IList<Person> GetMediaPersonLinks(int id)
        {
            return db.EventMediaLinkPersons.Where(o => o.IdMedia == id).Include(o => o.Person).Select(o => o.Person).ToList();
        }
        /// <see cref="IEventRepository.GetMediaEventLinks" />
        public IList<Event> GetMediaEventLinks(int id)
        {
            return db.EventMediaLinkEvents.Where(o => o.IdMedia == id).Include(o => o.Event).Select(o => o.Event).ToList();
        }

        /// <see cref="IEventRepository.GetOrganizers" />
        public IList<Company> GetOrganizers()
        {
            return db.Companies.ToList();
        }

        /// <see cref="IEventRepository.SaveOrganizer" />
        public Company SaveOrganizer(string name)
        {
            var cmp = db.Companies.FirstOrDefault(o => o.Name.ToLower().Equals(name.ToLower()));
            if (cmp != null) return cmp;
            cmp = new Company { Name = name };
            db.Companies.Add(cmp);
            db.SaveChanges();
            return cmp;
        }

        private PageBlock SavePageBlock(PageBlock pageBlock)
        {
            if (pageBlock.Id == 0)
            {
                db.Entry(pageBlock).State = EntityState.Added;
            }
            else if (pageBlock.Id > 0)
            {
                var pr = db.PageBlocks.FirstOrDefault(o => o.Id == pageBlock.Id);
                db.Entry(pr).CurrentValues.SetValues(pageBlock);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return pageBlock;
        }

        private PageSchema SavePage(PageSchema page)
        {
            if (page.Id == 0)
            {
                db.Entry(page).State = EntityState.Added;
            }
            else if (page.Id > 0)
            {
                var pr = db.PageSchemas.FirstOrDefault(o => o.Id == page.Id);
                db.Entry(pr).CurrentValues.SetValues(page);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return page;
        }

        private UserPageCategory SaveUserPageCategory(UserPageCategory cat)
        {
            if (cat.Id == 0)
            {
                db.Entry(cat).State = EntityState.Added;
            }
            else if (cat.Id > 0)
            {
                var pr = db.UserPageCategories.FirstOrDefault(o => o.Id == cat.Id);
                db.Entry(pr).CurrentValues.SetValues(cat);
            }
            else
            {
                return null;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return cat;
        }

        private void SaveLog<T>(T from, T to, int eventId, int userId, LogType type) where T : BaseEntity
        {
            var log = new EventLog
            {
                Date = DateTime.UtcNow,
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
