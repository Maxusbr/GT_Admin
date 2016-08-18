using Getticket.Web.DAL.Entities;
using System;
using System.Collections.Generic;
using Getticket.Web.DAL.Enums;
using Getticket.Web.DAL.Infrastructure;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// Интерфейс для работы с сущностью <see cref="Person" />
    /// </summary>
    public interface IPersonRepository : IDisposable
    {
        /// <summary>
        /// Находим <see cref="Person"/> с Id = <paramref name="id" /> 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Person FindPersonById(int id);

        /// <summary>
        /// Если <see cref="Person"/> новый - добавляем новую запись в БД.
        /// Если <see cref="Person"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Person SavePerson(Person person, int userId);

        /// <summary>
        /// Возвращает всех <see cref="Person"/>
        /// </summary>
        /// <returns></returns>
        IList<Person> FindAllPerson();

        /// <summary>
        /// Постраничный вывод <see cref="Person"/> с условиями сортировки
        /// </summary>
        /// <param name="page">Информация о странице (номер страницы, количество записей на странице)</param>
        /// <param name="alphabetically">Сортировка по алфавиту (А-Я или A-Z)</param>
        /// <param name="sexId"></param>
        /// <returns></returns>
        IList<Person> FindPerson(PageInfo page, string alphabetically, Sex? sexId = null);

        /// <summary>
        /// Удаляет <see cref="Person"/> из БД по его <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeletePerson(int id);

        /// <summary>
        /// Возвращает набор характеристик <see cref="PersonAntro"/> для сущности <see cref="Person"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonAntro> GetPersonAntros(int id);

        /// <summary>
        /// Возвращает список <see cref="PersonAntroName"/>
        /// </summary>
        /// <returns></returns>
        IList<PersonAntroName> GetAntroNames();

        /// <summary>
        /// Если <see cref="PersonAntroName"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonAntroName"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        PersonAntroName UpdateAntroName(PersonAntroName property);

        /// <summary>
        /// Удалить характеристику <see cref="PersonAntroName"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteAntroName(int id);

        /// <summary>
        /// Если <see cref="PersonAntro"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonAntro"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        PersonAntro UpdatePersonAntro(PersonAntro property, int userId);

        /// <summary>
        /// Добавляет/заменяет набор характеристик <paramref name="properties" />
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool AddPersonAntros(IList<PersonAntro> properties, int userId);

        /// <summary>
        /// Удаляет набор характеристик <paramref name="properties" />
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        bool DeletePersonAntros(IList<PersonAntro> properties);

        /// <summary>
        /// Возвращает список <see cref="PersonChangeParam"/>
        /// </summary>
        /// <returns></returns>
        IList<PersonChangeParam> GetChangeParams();

        /// <summary>
        /// Если <see cref="PersonChangeParam"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonChangeParam"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        PersonChangeParam UpdateChangeParam(PersonChangeParam param);

        /// <summary>
        /// Удалить параметр <see cref="PersonChangeParam"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteChangeParam(int id);

        /// <summary>
        /// Возвращает log изменений параметров.
        /// Если <paramref name="id" /> != null, возвращается лог для <see cref="Person"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonChangeLog> GetChangeLog(int? id = null);

        /// <summary>
        /// Добавляет записи изменений характеристик <see cref="PersonChangeLog"/>
        /// </summary>
        /// <param name="changes"></param>
        /// <returns></returns>
        bool AddChangeLogs(IList<PersonChangeLog> changes);

        /// <summary>
        /// Добавляет запись лога изменений характеристик <see cref="PersonChangeLog"/>
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        bool AddChangeLog(PersonChangeLog change);

        /// <summary>
        /// Возвращает список <see cref="ConnectionType"/>
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
        /// Возвращает список связей <see cref="PersonConnection"/> для <see cref="Person"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonConnection> GetConnections(int id);

        /// <summary>
        /// Добавляет записи связей <see cref="PersonConnection"/>
        /// </summary>
        /// <param name="connections"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool AddConnections(IList<PersonConnection> connections, int userId);

        /// <summary>
        /// Если <see cref="PersonConnection"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonConnection"/> уже существует - обновляет связь <see cref="PersonConnection"/>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        PersonConnection SaveConnection(PersonConnection connection, int userId);

        /// <summary>
        /// Удаляет записи связей <see cref="PersonConnection"/>
        /// </summary>
        /// <param name="connections"></param>
        /// <returns></returns>
        bool DeleteConnections(IList<PersonConnection> connections);

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
        /// Возвращает список описаний <see cref="PersonDescription"/> для <see cref="Person"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonDescription> GetDescriptions(int id);

        /// <summary>
        /// Если <see cref="PersonDescription"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonDescription"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        PersonDescription UpdateDescription(PersonDescription description, int userId);

        /// <summary>
        /// Удаляет описание <see cref="PersonDescription"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteDescription(int id);

        /// <summary>
        /// Связать описания
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool LinkDescriptions(PersonDescriptionTizerLink model);

        /// <summary>
        /// Связать Media и Person
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool LinkMedia(MediaLinkPerson model);

        /// <summary>
        /// Связать Media и Event
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool LinkMedia(MediaLinkEvent model);

        /// <summary>
        /// Возвращает список описаний <see cref="PersonMedia"/> для <see cref="Person"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonMedia> GetMedia(int id);

        /// <summary>
        /// Если <see cref="PersonMedia"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonMedia"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="media"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        PersonMedia UpdateMedia(PersonMedia media, int userId);

        /// <summary>
        /// Удаляет Media <see cref="PersonMedia"/>
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
        /// Возвращает список <see cref="PersonFactType"/>
        /// </summary>
        /// <returns></returns>
        IList<PersonFactType> GetPersonFactTypes();

        /// <summary>
        /// Если <see cref="PersonFactType"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonFactType"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        PersonFactType UpdateFactType(PersonFactType type);

        /// <summary>
        /// Удалить тип <see cref="PersonFactType"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteFactType(int id);

        /// <summary>
        /// Возвращает список ссылок <see cref="PersonFact"/> для <see cref="Person"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonFact> GetPersonFacts(int id);

        /// <summary>
        /// Если <see cref="PersonFact"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonFact"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="facts"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool UpdatePersonFacts(IList<PersonFact> facts, int userId);

        /// <summary>
        /// Обновляет/добавляет <see cref="PersonFact"/> в БД.
        /// </summary>
        /// <param name="fact"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        PersonFact UpdatePersonFact(PersonFact fact, int userId);

        /// <summary>
        /// Удаляет факты <see cref="PersonFact"/> по <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeletePersonFact(int id);

        /// <summary>
        /// Возвращает список <see cref="PersonSocialLinkType"/>
        /// </summary>
        /// <returns></returns>
        IList<PersonSocialLinkType> GetLinkTypes();

        /// <summary>
        /// Если <see cref="PersonSocialLinkType"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonSocialLinkType"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        PersonSocialLinkType UpdateLinkType(PersonSocialLinkType type);

        /// <summary>
        /// Удалить тип <see cref="PersonSocialLinkType"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteLinkType(int id);

        /// <summary>
        /// Возвращает список ссылок <see cref="PersonSocialLink"/> для <see cref="Person"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonSocialLink> GetSocialLinks(int id);

        /// <summary>
        /// Если <see cref="PersonSocialLink"/> новый - добавляем новую запись в БД.
        /// Если <see cref="PersonSocialLink"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="links"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool UpdateSocialLinks(IList<PersonSocialLink> links, int userId);

        /// <summary>
        /// Обновляет/добавляет <see cref="PersonSocialLink"/> в БД.
        /// </summary>
        /// <param name="link"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        PersonSocialLink UpdateSocialLink(PersonSocialLink link, int userId);

        /// <summary>
        /// Удаляет ссылки <see cref="PersonSocialLink"/> по <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteSocialLink(int id);

        /// <summary>
        /// Возвращает список <see cref="Country"/>
        /// </summary>
        /// <param name="foundName"></param>
        /// <returns></returns>
        IList<Country> GetCountries(string foundName);

        /// <summary>
        /// Если <see cref="Country"/> новый - добавляем новую запись в БД.
        /// Если <see cref="Country"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Country SaveCountry(Country country);

        /// <summary>
        /// Удалить тип <see cref="Country"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCountry(int id);

        /// <summary>
        /// Возвращает список <see cref="CountryPlace"/> для страны <see cref="Country"/> с Id = <paramref name="id" />
        /// </summary>
        /// <returns></returns>
        IList<CountryPlace> GetCountryPlaces(int id);

        /// <summary>
        /// Возвращает список <see cref="CountryPlace"/> 
        /// </summary>
        /// <returns></returns>
        IList<CountryPlace> GetCountryPlaces(string foundName);

        /// <summary>
        /// Если <see cref="CountryPlace"/> новый - добавляем новую запись в БД.
        /// Если <see cref="CountryPlace"/> уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        CountryPlace SaveCountryPlace(CountryPlace place);

        /// <summary>
        /// Удалить тип <see cref="CountryPlace"/> по ее <paramref name="id" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCountryPlace(int id);

        /// <summary>
        /// Добавить город
        /// </summary>
        /// <param name="country"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        int UpdatePlace(string country, string place);

        /// <summary>
        /// Возвращает количество описаний
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetCountDescriptions(int id);

        /// <summary>
        /// Возвращает количество фактов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetCountFacts(int id);

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
        /// <summary>
        /// Возвращает количество ссылок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetCountLinks(int id);
        /// <summary>
        /// Возвращает количество антропометрии
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetCountAntros(int id);

        /// <summary>
        /// Сохранить схему описания
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageBlock"></param>
        /// <param name="cat"></param>
        /// <returns></returns>
        bool SaveDescriptionSchema(int id, PageBlock pageBlock, UserPageCategory cat);

        /// <summary>
        /// Получить список источников
        /// </summary>
        /// <returns></returns>
        IList<UserPageCategory> GetUserPageCategory();

        /// <summary>
        /// Список ассоциаций персон и медиа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<Person> GetMediaPersonLinks(int id);

        /// <summary>
        /// Список ассоциаций мероприятий и медиа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<Event>  GetMediaEventLinks(int id);
    }
}
