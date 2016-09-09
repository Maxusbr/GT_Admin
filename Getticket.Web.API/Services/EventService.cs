using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Events;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Infrastructure;
using CountsModel = Getticket.Web.API.Models.Events.CountsModel;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис для управления Event
    /// (обновление, регистрация, удаление и т.п.)
    /// </summary>
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ILogRepository _logRepository;
        private readonly ITagRepository _tagRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="eventRepository"></param>
        /// <param name="logRepository"></param>
        /// <param name="tagRepository"></param>
        public EventService(IEventRepository eventRepository, ILogRepository logRepository, ITagRepository tagRepository)
        {
            _eventRepository = eventRepository;
            _logRepository = logRepository;
            _tagRepository = tagRepository;
        }

        /// <see cref="IEventService.GetEvents" />
        public IEnumerable<EventModel> GetEvents(bool realy = false)
        {
            return EventModelHelper.GetEventModels(_eventRepository.GetEvents(realy));
        }

        /// <summary>
        /// Воозвращает модель EventModel по <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EventModel GetEvent(int id)
        {
            var result = _eventRepository.FindEventById(id);
            return EventModelHelper.GetEventModel(result);
        }

        /// <summary>
        /// <see cref="IEventService.GetCounts"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CountsModel GetCounts(int id)
        {
            return new CountsModel
            {
                CountDescriptions = _eventRepository.GetCountDescriptions(id),
                CountConnects = _eventRepository.GetCountConnects(id),
                CountMedias = _eventRepository.GetCountMedias(id),
                CountFacts = _eventRepository.GetCountFacts(id),
                //TODO Праваи пользователи
                CountLinks = 0
            };
        }

        /// <summary>
        /// Возвращает список связей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Models.Events.EntityCollection<EventConnectionModel>> GetConnection(int id)
        {
            var list = EventModelHelper.GetConnectionModels(_eventRepository.GetConnections(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangeEventConnection(item.id_Event, item.Id));
            }
            var types = list.GroupBy(o => o.id_ConnectionType).Select(o => o.Key);
            return types.Select(tp => new Models.Events.EntityCollection<EventConnectionModel> { List = list.Where(o => o.id_ConnectionType == tp), Type = tp });
        }

        /// <summary>
        /// Возвращает список моделей медиа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Models.Events.EntityCollection<EventMediaModel>> GetMedia(int id)
        {
            var list = EventModelHelper.GetMediaModels(_eventRepository.GetMedia(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangeEventMedia(item.id_Event, item.Id));
                item.Tags = TagModelHelper.GeTagModels(_tagRepository.GetEventMediaTags(item.Id));
                item.Links = new LinksModel
                {
                    PersonLinks = PersonModelHelper.GetPersonModels(_eventRepository.GetMediaPersonLinks(item.Id)),
                    EventLinks = EventModelHelper.GetEventModels(_eventRepository.GetMediaEventLinks(item.Id))
                };
            }
            var types = list.GroupBy(o => o.id_MediaType).Select(o => o.Key);
            return types.Select(tp => new Models.Events.EntityCollection<EventMediaModel> { List = list.Where(o => o.id_MediaType == tp), Type = tp });
        }

        /// <summary>
        /// Возвращает список моделей описаний
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EventDescriptionModel> GetDescriptions(int id)
        {
            var list = EventModelHelper.GetDescriptionModels(_eventRepository.GetDescriptions(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangeEventDescription(item.id_Event, item.Id));
            }
            return list;
            //var types = list.GroupBy(o => o.id_DescriptionType).Select(o => o.Key);
            //return types.Select(tp => new Models.Events.EntityCollection<EventDescriptionModel> { List = list.Where(o => o.id_DescriptionType == tp), Type = tp });
        }

        /// <summary>
        /// Add or Update Event entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public EventModel SaveEvent(EventModel model, int userId)
        {
            var _event = EventModelHelper.GetEvent(model);
            var org = _eventRepository.SaveOrganizer(model.Organizer);
            if (org != null)
                _event.IdCompany = org.Id;
            var res = _eventRepository.SaveEvent(_event, userId);
            return EventModelHelper.GetEventModel(res);
        }

        /// <summary>
        /// Delete Event entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponce DeleteEvent(int id)
        {
            var res = _eventRepository.DeleteEvent(id);
            var response = res ? ServiceResponce
                .FromSuccess()
                .Result("Event delete") :
                ServiceResponce
                .FromFailed()
                .Result("Error delete event");
            return response;
        }

        /// <summary>
        /// Возвращает список типов связи
        /// </summary>
        /// <returns></returns>
        public IList<EventConnectionTypeModel> GetConnectionTypes()
        {
            var result = _eventRepository.GetConnectionTypes();
            return EventModelHelper.GetConnectionTypeModels(result);
        }

        /// <summary>
        /// Добавить/Изменить типы связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateConnectionTypes(IEnumerable<EventConnectionTypeModel> models)
        {
            foreach (var item in models)
            {
                var result = _eventRepository.UpdateConnectionType(new ConnectionType { Id = item.Id, Name = item.Name });
                if (result == null) return ServiceResponce
                 .FromFailed()
                 .Result($"Error save connection type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Connection type save complete");
        }


        /// <summary>
        /// Удалить типы связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteConnectionTypes(IEnumerable<EventConnectionTypeModel> models)
        {
            if (models.Any(item => !_eventRepository.DeleteConnectionType(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete connection type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Connection type delete complete");
        }


        /// <summary>
        /// Добавить/Изменить связи для Event c Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResponce UpdateConnection(int eventId, IEnumerable<EventConnectionModel> models, int userId)
        {
            var result = _eventRepository.AddConnections(
                models.Select(o => new EventConnection
                {
                    Id = o.Id,
                    id_Person = eventId,
                    id_ConnectionType = o.id_ConnectionType,
                    id_Event = o.id_Event,
                    id_EventConnectTo = o.id_EventConnectTo,
                    Description = o.Description
                }).ToList(), userId);
            return result ? ServiceResponce
                .FromSuccess()
                .Result("Connections save complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error save connections");
        }

        /// <see cref="IEventService.UpdateConnection(EventConnectionModel, int)"/>
        public int UpdateConnection(EventConnectionModel model, int userId)
        {
            var result = _eventRepository.SaveConnection(new EventConnection
            {
                Id = model.Id,
                id_Person = model.id_Person,
                id_ConnectionType = model.id_ConnectionType,
                id_Event = model.id_Event,
                id_EventConnectTo = model.id_EventConnectTo,
                Description = model.Description
            }, userId);
            return result?.Id ?? -1;
        }

        /// <summary>
        /// Удалить связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteConnection(IEnumerable<EventConnectionModel> models)
        {
            var result = _eventRepository.DeleteConnections(models.Select(o => new EventConnection
            {
                Id = o.Id
            }).ToList());
            return result ? ServiceResponce
                .FromSuccess()
                .Result("Connections delete complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error delete connections");
        }

        /// <summary>
        /// Возвращает список типов медиа
        /// </summary>
        /// <returns></returns>
        public IList<MediaTypeModel> GetMediaTypes()
        {
            var result = _eventRepository.GetMediaTypes();
            return EventModelHelper.GetMediaTypeModels(result);
        }

        /// <summary>
        /// Добавить/Изменить типы медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateMediaTypes(IEnumerable<MediaTypeModel> models)
        {
            foreach (var item in models)
            {
                var result = _eventRepository.UpdateMediaType(new MediaType { Id = item.Id, Name = item.Name });
                if (result == null) return ServiceResponce
                 .FromFailed()
                 .Result($"Error save media type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Media type save complete");
        }

        /// <summary>
        /// Удалить типы медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteMediaTypes(IEnumerable<MediaTypeModel> models)
        {
            if (models.Any(item => !_eventRepository.DeleteMediaType(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete media type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Media type delete complete");
        }

        /// <summary>
        /// Добавить/Изменить список медиа для Event c Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool UpdateMedia(int eventId, IEnumerable<EventMediaModel> models, int userId)
        {
            return models.Select(item => _eventRepository.UpdateMedia(new EventMedia
            {
                Id = item.Id,
                IdEvent = eventId,
                IdMediaType = item.id_MediaType,
                MediaLink = item.MediaLink,
                Description = item.Description
            }, userId)).All(result => result != null);
        }

        /// <see cref="IEventService.UpdateMedia(EventMediaModel,int)"/>
        public int UpdateMedia(EventMediaModel model, int userId)
        {
            var result = _eventRepository.UpdateMedia(new EventMedia
            {
                Id = model.Id,
                IdEvent = model.id_Event,
                IdMediaType = model.id_MediaType,
                MediaLink = model.MediaLink,
                Description = model.Description
            }, userId);
            return result?.Id ?? -1;
        }

        /// <summary>
        /// Удалить список медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteMedia(IEnumerable<EventMediaModel> models)
        {
            if (models.Any(item => !_eventRepository.DeleteMedia(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete media");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Media delete complete");
        }

        /// <see cref="IPersonService.LinkMediaPerson"/>
        public bool LinkMediaPerson(int idMedia, int idPerson)
        {
            return _eventRepository.LinkMedia(new EventMediaLinkPerson { IdMedia = idMedia, IdPerson = idPerson });
        }

        /// <see cref="IPersonService.LinkMediaEvent"/>
        public bool LinkMediaEvent(int idMedia, int idEvent)
        {
            return _eventRepository.LinkMedia(new EventMediaLinkEvent { IdMedia = idMedia, IdEvent = idEvent });
        }

        /// <summary>
        /// Возвращает список типов описаний
        /// </summary>
        /// <returns></returns>
        public IList<PersonDescriptionTypeModel> GetDescriptionTypes()
        {
            var result = _eventRepository.GetDescriptionTypes();
            return PersonModelHelper.GetDescriptionTypeModels(result);
        }

        /// <summary>
        /// Добавить/Изменить типы описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateDescriptionTypes(IEnumerable<PersonDescriptionTypeModel> models)
        {
            foreach (var item in models)
            {
                var result = _eventRepository.UpdateDescriptionType(new PersonDescriptionType { Id = item.Id, Name = item.Name });
                if (result == null) return ServiceResponce
                 .FromFailed()
                 .Result($"Error save description type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Description type save complete");
        }

        /// <summary>
        /// Удалить типы описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponce DeleteDescriptionTypes(IEnumerable<PersonDescriptionTypeModel> models)
        {
            if (models.Any(item => !_eventRepository.DeleteDescriptionType(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete description type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Description type delete complete");
        }

        /// <summary>
        /// Добавить/Изменить список описаний для Event c Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResponce UpdateDescriptions(int eventId, IEnumerable<EventDescriptionModel> models, int userId)
        {
            if (models == null || models.Select(item => _eventRepository.UpdateDescription(new EventDescription
            {
                Id = item.Id,
                IdEvent = eventId,
                IdType = item.id_DescriptionType,
                Description = item.DescriptionText,
                Status = item.Status
            }, userId)).Any(result => result == null))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error save description");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Descriptions save complete");
        }

        /// <see cref="IEventService.UpdateDescriptions(EventDescriptionModel, int)"/>
        public int UpdateDescriptions(EventDescriptionModel model, int userId)
        {
            var result = _eventRepository.UpdateDescription(new EventDescription
            {
                Id = model.Id,
                IdEvent = model.id_Event,
                IdType = model.id_DescriptionType,
                Description = model.DescriptionText,
                Status = model.Status
            }, userId);
            if (result == null)
            {
                return -1;
            }
            return result.Id;
        }

        /// <summary>
        /// Удалить список описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteDescriptions(IEnumerable<EventDescriptionModel> models)
        {
            if (models.Any(item => !_eventRepository.DeleteDescription(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete description");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Descriptions delete complete");
        }



        #region facts

        /// <see cref="IEventService.GetFacts" />
        public IEnumerable<EventFactModel> GetFacts(int id)
        {
            var list = EventModelHelper.GetFactModels(_eventRepository.GetEventFacts(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangeEventFact(item.id_Event, item.Id));
            }
            //var types = list.GroupBy(o => o.id_FactType).Select(o => o.Key);
            //return types.Select(tp => new EntityCollection<EventFactModel> { List = list.Where(o => o.id_FactType == tp), Type = tp });
            return list;
        }

        /// <see cref="IEventService.GetFactsTypes"/>
        public IList<EventFactTypeModel> GetFactsTypes()
        {
            var result = _eventRepository.GetEventFactTypes();
            return EventModelHelper.GetFactTypeModels(result);
        }

        /// <see cref="IEventService.UpdateFactTypes"/>
        public ServiceResponce UpdateFactTypes(IEnumerable<EventFactTypeModel> models)
        {
            foreach (var item in models)
            {
                var result = _eventRepository.UpdateFactType(new EventFactType { Id = item.Id, Name = item.Name });
                if (result == null) return ServiceResponce
                 .FromFailed()
                 .Result($"Error save fact type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Fatc type save complete");
        }

        /// <see cref="IEventService.DeleteFactTypes"/>
        public ServiceResponce DeleteFactTypes(IEnumerable<EventFactTypeModel> models)
        {
            if (models.Any(item => !_eventRepository.DeleteFactType(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete fact type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Fact type delete complete");
        }

        /// <see cref="IEventService.UpdateFacts(int, IEnumerable{EventFactModel}, int)"/>
        public ServiceResponce UpdateFacts(int pesonId, IEnumerable<EventFactModel> models, int userId)
        {
            if (models.Select(item => _eventRepository.UpdateEventFact(new EventFact
            {
                Id = item.Id,
                id_Event = pesonId,
                id_FactType = item.id_FactType,
                FactText = item.FactText,
                Status = item.Status,
                Source = item.Source
            }, userId)).Any(result => result == null))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error save fact");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Facts save complete");
        }

        /// <see cref="IEventService.UpdateFacts(EventFactModel, int)"/>
        public int UpdateFacts(EventFactModel model, int userId)
        {
            var res = _eventRepository.UpdateEventFact(new EventFact
            {
                Id = model.Id,
                id_Event = model.id_Event,
                id_FactType = model.id_FactType,
                FactText = model.FactText,
                Status = model.Status,
                Source = model.Source
            }, userId);
            return res?.Id ?? -1;
        }

        /// <see cref="IEventService.DeleteFacts"/>
        public ServiceResponce DeleteFacts(IEnumerable<EventFactModel> models)
        {
            if (models.Any(item => !_eventRepository.DeleteEventFact(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete fact");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Facts delete complete");
        }

        #endregion




        /// <see cref="IEventService.GetCategories"/>
        public IList<EventCategoryModel> GetCategories()
        {
            return EventModelHelper.GetCategoryModels(_eventRepository.GetCategories());
        }

        /// <see cref="IEventService.SaveDescriptionSchema"/>
        public bool SaveDescriptionSchema(int id, PageBlockModel model, int eventId)
        {
            return _eventRepository.SaveDescriptionSchema(id,
                PageModelHelper.GetPageBlock(model), model.UserPageCategoryId != null ?
                new UserPageCategory
                {
                    Id = model.UserPageCategoryId ?? 0,
                    Name = model.UserPageCategory
                } : null, eventId);
        }

        /// <see cref="IEventService.SaveCategory"/>
        public EventCategoryModel SaveCategory(EventCategoryModel model)
        {
            return EventModelHelper.GetCategoryModels(_eventRepository.SaveCategory(
                new EventCategory
                {
                    Id = model.Id,
                    Name = model.Name,
                    IdParent = model.IdParent,
                    Description = model.Description
                }));
        }

        /// <see cref="IEventService.GetOrganizers"/>
        public IList<EventOrganizerModel> GetOrganizers()
        {
            return _eventRepository.GetOrganizers().Select(o => new EventOrganizerModel { Id = o.Id, Name = o.Name }).ToList();
        }
    }

}