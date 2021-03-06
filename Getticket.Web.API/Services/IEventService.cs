﻿using Getticket.Web.DAL.IRepositories;
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
    /// Интерфейс сервиса для управления Event
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Возвращает список событий
        /// </summary>
        /// <returns></returns>
        IEnumerable<EventModel> GetEvents(bool realy = false);

        /// <summary>
        /// Воозвращает модель EventModel по <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EventModel GetEvent(int id);

        /// <summary>
        /// Возвращает количества описаний, фактов и т.д.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CountsModel GetCounts(int id);

        /// <summary>
        /// Возвращает список связей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Models.Events.EntityCollection<EventConnectionModel>> GetConnection(int id);

        /// <summary>
        /// Возвращает список моделей интернет-ссылок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Models.Events.EntityCollection<EventMediaModel>> GetMedia(int id);

        /// <summary>
        /// Возвращает список моделей описаний
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<EventDescriptionModel> GetDescriptions(int id);


        /// <summary>
        /// Add or Update Event entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        EventModel SaveEvent(EventModel model, int userId);

        /// <summary>
        /// Delete Event entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceResponce DeleteEvent(int id);

        /// <summary>
        /// Возвращает список типов связи
        /// </summary>
        /// <returns></returns>
        IList<EventConnectionTypeModel> GetConnectionTypes();

        /// <summary>
        /// Добавить/Изменить типы связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce UpdateConnectionTypes(IEnumerable<EventConnectionTypeModel> models);

        /// <summary>
        /// Удалить типы связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteConnectionTypes(IEnumerable<EventConnectionTypeModel> models);

        /// <summary>
        /// Добавить/Изменить связи для Event c Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ServiceResponce UpdateConnection(int eventId, IEnumerable<EventConnectionModel> models, int userId);

        /// <summary>
        /// Добавить/Изменить связи для Event c Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateConnection(EventConnectionModel model, int userId);

        /// <summary>
        /// Удалить связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteConnection(IEnumerable<EventConnectionModel> models);

        /// <summary>
        /// Возвращает список типов медиа
        /// </summary>
        /// <returns></returns>
        IList<MediaTypeModel> GetMediaTypes();

        /// <summary>
        /// Добавить/Изменить типы медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce UpdateMediaTypes(IEnumerable<MediaTypeModel> models);

        /// <summary>
        /// Удалить типы медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteMediaTypes(IEnumerable<MediaTypeModel> models);

        /// <summary>
        /// Добавить/Изменить список медиа для Event c Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool UpdateMedia(int eventId, IEnumerable<EventMediaModel> models, int userId);

        /// <summary>
        /// Добавить/Изменить медиа для Event
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateMedia(EventMediaModel model, int userId);

        /// <summary>
        /// Удалить список медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteMedia(IEnumerable<EventMediaModel> models);

        /// <summary>
        /// Добавить ссылку медиа на персону
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idPerson"></param>
        /// <returns></returns>
        bool LinkMediaPerson(int id, int idPerson);

        /// <summary>
        /// Добавить ссылку медиа на мероприятие
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        bool LinkMediaEvent(int id, int idEvent);

        /// <summary>
        /// Возвращает список типов описаний
        /// </summary>
        /// <returns></returns>
        IList<PersonDescriptionTypeModel> GetDescriptionTypes();

        /// <summary>
        /// Добавить/Изменить типы описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce UpdateDescriptionTypes(IEnumerable<PersonDescriptionTypeModel> models);

        /// <summary>
        /// Удалить типы описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        ServiceResponce DeleteDescriptionTypes(IEnumerable<PersonDescriptionTypeModel> models);

        /// <summary>
        /// Добавить/Изменить список описаний для Event c Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ServiceResponce UpdateDescriptions(int eventId, IEnumerable<EventDescriptionModel> models, int userId);

        /// <summary>
        /// Добавить/Изменить описание
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateDescriptions(EventDescriptionModel model, int userId);

        /// <summary>
        /// Удалить список описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteDescriptions(IEnumerable<EventDescriptionModel> models);


        #region facts

        /// <summary>
        /// Возвращает список моделей фактов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<EventFactModel> GetFacts(int id);

        /// <summary>
        /// Возвращает список типов фактов
        /// </summary>
        /// <returns></returns>
        IList<EventFactTypeModel> GetFactsTypes();

        /// <summary>
        /// Добавить/Изменить типы фактов
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce UpdateFactTypes(IEnumerable<EventFactTypeModel> models);

        /// <summary>
        /// Удалить типы фактов
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteFactTypes(IEnumerable<EventFactTypeModel> models);

        /// <summary>
        /// Добавить/Изменить список фактов для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ServiceResponce UpdateFacts(int pesonId, IEnumerable<EventFactModel> models, int userId);

        /// <summary>
        /// Добавить/Изменить список фактов для Person
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateFacts(EventFactModel model, int userId);

        /// <summary>
        /// Удалить факты
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteFacts(IEnumerable<EventFactModel> models);

        #endregion

        /// <summary>
        /// Получает список категорий событий
        /// </summary>
        /// <returns></returns>
        IList<EventCategoryModel> GetCategories();

        /// <summary>
        /// Сохранить схему описания
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        bool SaveDescriptionSchema(int id, PageBlockModel model, int eventId);

        /// <summary>
        /// Сохранить категорию
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        EventCategoryModel SaveCategory(EventCategoryModel model);

        /// <summary>
        /// Список организаторов
        /// </summary>
        /// <returns></returns>
        IList<EventOrganizerModel> GetOrganizers();
    }

}