using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Events;

using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Infrastructure;

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
        public IEnumerable<EventModel> GetEvents()
        {
            return EventModelHelper.GetEventModels(_eventRepository.GetEvents());
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
                CountMedias = _eventRepository.GetCountMedias(id)
            };
        }

        /// <summary>
        /// Возвращает список связей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EntityCollection<EventConnectionModel>> GetConnection(int id)
        {
            var list = EventModelHelper.GetConnectionModels(_eventRepository.GetConnections(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangeEventConnection(item.id_Event, item.Id));
            }
            var types = list.GroupBy(o => o.id_ConnectionType).Select(o => o.Key);
            return types.Select(tp => new EntityCollection<EventConnectionModel> { List = list.Where(o => o.id_ConnectionType == tp), Type = tp });
        }

        /// <summary>
        /// Возвращает список моделей медиа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EntityCollection<EventMediaModel>> GetMedia(int id)
        {
            var list = EventModelHelper.GetMediaModels(_eventRepository.GetMedia(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangeEventMedia(item.id_Event, item.Id));
                item.Tags = TagModelHelper.GeTagModels(_tagRepository.GeEventMediaTags(item.Id));
            }
            var types = list.GroupBy(o => o.id_MediaType).Select(o => o.Key);
            return types.Select(tp => new EntityCollection<EventMediaModel> { List = list.Where(o => o.id_MediaType == tp), Type = tp });
        }

        /// <summary>
        /// Возвращает список моделей описаний
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EntityCollection<EventDescriptionModel>> GetDescriptions(int id)
        {
            var list = EventModelHelper.GetDescriptionModels(_eventRepository.GetDescriptions(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangeEventDescription(item.id_Event, item.Id));
            }
            var types = list.GroupBy(o => o.id_DescriptionType).Select(o => o.Key);
            return types.Select(tp => new EntityCollection<EventDescriptionModel> { List = list.Where(o => o.id_DescriptionType == tp), Type = tp });
        }

        /// <summary>
        /// Add or Update Event entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResponce SaveEvent(EventModel model, int userId)
        {
            var _event = EventModelHelper.GetEvent(model);
            var res = _eventRepository.SaveEvent(_event, userId);
            var response = res != null ? ServiceResponce
                .FromSuccess()
                .Result("Event save")
                .Add("EventId", _event.Id) : ServiceResponce.FromFailed().Result("Error save event");
            return response;
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

        /// <summary>
        /// Возвращает список типов описаний
        /// </summary>
        /// <returns></returns>
        public IList<EventDescriptionTypeModel> GetDescriptionTypes()
        {
            var result = _eventRepository.GetDescriptionTypes();
            return EventModelHelper.GetDescriptionTypeModels(result);
        }

        /// <summary>
        /// Добавить/Изменить типы описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateDescriptionTypes(IEnumerable<EventDescriptionTypeModel> models)
        {
            foreach (var item in models)
            {
                var result = _eventRepository.UpdateDescriptionType(new EventDescriptionType { Id = item.Id, Name = item.Name });
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
        public ServiceResponce DeleteDescriptionTypes(IEnumerable<EventDescriptionTypeModel> models)
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
    }

}