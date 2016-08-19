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
        IList<Event> GetEvents(bool realy = false);

        /// <summary>
        /// Находим <see cref="Event"/> с Id = <paramref name="id" /> 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Event FindEventById(int id);

        /// <summary>
        /// Если <see cref="Event"/> новый - добавляем новую запись в БД.
        /// Если <see cref="Event"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Event SaveEvent(Event person, int userId);

        /// <summary>
        /// Удаляет <see cref="Event"/> из БД по его <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteEvent(int id);

        /// <summary>
        /// Возвращает список <see cref="EventConnectionType"/>
        /// </summary>
        /// <returns></returns>
        IList<ConnectionType> GetConnectionTypes();

        /// <summary>
        /// Если <see cref="ConnectionType"/> новый - добавляем новую запись в БД.
        /// Если <see cref="ConnectionType"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ConnectionType UpdateConnectionType(ConnectionType type);

        /// <summary>
        /// Удалить тип <see cref="ConnectionType"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteConnectionType(int id);

        /// <summary>
        /// Возвращает список связей <see cref="EventConnection"/> для <see cref="Event"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<EventConnection> GetConnections(int id);

        /// <summary>
        /// Добавляет записи связей <see cref="EventConnection"/>
        /// </summary>
        /// <param name="connections"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool AddConnections(IList<EventConnection> connections, int userId);

        /// <summary>
        /// Если <see cref="EventConnection"/> новый - добавляем новую запись в БД.
        /// Если <see cref="EventConnection"/> уже существует - обновляет связь <see cref="EventConnection"/>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        EventConnection SaveConnection(EventConnection connection, int userId);

        /// <summary>
        /// Удаляет записи связей <see cref="EventConnection"/>
        /// </summary>
        /// <param name="connections"></param>
        /// <returns></returns>
        bool DeleteConnections(IList<EventConnection> connections);

        /// <summary>
        /// Возвращает список <see cref="PersonDescriptionType"/>
        /// </summary>
        /// <returns></returns>
        IList<PersonDescriptionType> GetDescriptionTypes();

        /// <summary>
        /// Если <see cref="PersonDescriptionType"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonDescriptionType"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        PersonDescriptionType UpdateDescriptionType(PersonDescriptionType type);

        /// <summary>
        /// Удалить тип <see cref="PersonDescriptionType"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteDescriptionType(int id);

        /// <summary>
        /// Возвращает список описаний <see cref="EventDescription"/> для <see cref="Event"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<EventDescription> GetDescriptions(int id);

        /// <summary>
        /// Если <see cref="EventDescription"/> новый - добавляем новую запись в БД.
        /// Если <see cref="EventDescription"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        EventDescription UpdateDescription(EventDescription description, int userId);

        /// <summary>
        /// Удаляет описание <see cref="EventDescription"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteDescription(int id);

        /// <summary>
        /// Возвращает список описаний <see cref="EventMedia"/> для <see cref="Event"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<EventMedia> GetMedia(int id);

        /// <summary>
        /// Если <see cref="EventMedia"/> новый - добавляем новую запись в БД.
        /// Если <see cref="EventMedia"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="media"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        EventMedia UpdateMedia(EventMedia media, int userId);

        /// <summary>
        /// Удаляет Media <see cref="EventMedia"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteMedia(int id);

        /// <summary>
        /// Возвращает список <see cref="MediaType"/>
        /// </summary>
        /// <returns></returns>
        IList<MediaType> GetMediaTypes();

        /// <summary>
        /// Если <see cref="MediaType"/> новый - добавляем новую запись в БД.
        /// Если <see cref="MediaType"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        MediaType UpdateMediaType(MediaType type);

        /// <summary>
        /// Удаляет Media <see cref="MediaType"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteMediaType(int id);

        /// <summary>
        /// Связать Media и Person
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool LinkMedia(EventMediaLinkPerson model);

        /// <summary>
        /// Связать Media и Event
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool LinkMedia(EventMediaLinkEvent model);

        /// <summary>
        /// Возвращает количество описаний
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetCountDescriptions(int id);
        /// <summary>
        /// Возвращает количество связей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetCountConnects(int id);
        /// <summary>
        /// Возвращает количество медиа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetCountMedias(int id);



        #region facts


        /// <see cref="IPersonRepository.GetPersonFactTypes" />
        IList<EventFactType> GetEventFactTypes();

        /// <see cref="IPersonRepository.UpdateFactType" />
        EventFactType UpdateFactType(EventFactType type);

        /// <see cref="IPersonRepository.DeleteFactType" />
        bool DeleteFactType(int id);

        /// <see cref="IPersonRepository.GetPersonFacts" />
        IList<EventFact> GetEventFacts(int id);

        /// <see cref="IPersonRepository.UpdatePersonFacts" />
        bool UpdateEventFacts(IList<EventFact> facts, int userId);

        /// <see cref="IPersonRepository.UpdatePersonFact" />
        EventFact UpdateEventFact(EventFact fact, int userId);

        /// <see cref="IPersonRepository.DeletePersonFact" />
        bool DeleteEventFact(int id);


        /// <see cref="IPersonRepository.GetCountFacts" />
        int GetCountFacts(int id);

        #endregion




        /// <summary>
        /// Возвращает список категорий
        /// </summary>
        /// <returns></returns>
        IList<EventCategory> GetCategories();

        /// <summary>
        /// Сохранить схему описания
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageBlock"></param>
        /// <param name="cat"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        bool SaveDescriptionSchema(int id, PageBlock pageBlock, UserPageCategory cat, int eventId);

        /// <summary>
        /// Сохранить категорию
        /// </summary>
        /// <param name="eventCategory"></param>
        /// <returns></returns>
        EventCategory SaveCategory(EventCategory eventCategory);
    }
}
