﻿using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Infrastructure;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Интерфейс сервиса для управления Person
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Воозвращает всех Persons
        /// </summary>
        /// <returns></returns>
        IList<PersonModel> GetAll();

        /// <summary>
        /// Возвращает страницу списка Persons с учетом параметров поиска <paramref name="searchParams"/>
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        IList<PersonModel> GetPersons(int pageNumber, int pageSize, PersonSearchParams searchParams = null);

        /// <summary>
        /// Воозвращает модель PersonModel по <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonModel GetPerson(int id);

        /// <summary>
        /// Возвращает количества описаний, фактов и т.д.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CountsModel GetCounts(int id);

        /// <summary>
        /// Возвращает список названий антропометрических характеристик 
        /// </summary>
        /// <returns></returns>
        IList<PersonAntroNameModel> GetAntroNames();

        /// <summary>
        /// Возвращает список моделей антропометрических характеристик 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonAntroModel> GetPersonAntros(int id);

        /// <summary>
        /// Возвращает список связей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<EntityCollection<PersonConnectionModel>> GetConnection(int id);

        /// <summary>
        /// Возвращает список моделей интернет-ссылок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<EntityCollection<PersonSocialLinkModel>> GetSocialLinks(int id);

        /// <summary>
        /// Возвращает список моделей интернет-ссылок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<EntityCollection<PersonMediaModel>> GetMedia(int id);

        /// <summary>
        /// Возвращает список моделей описаний
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<EntityCollection<PersonDescriptionModel>> GetDescriptions(int id);

        /// <summary>
        /// Возвращает список моделей описаний
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<PersonDescriptionModel> GetListDescriptions(int id);

        /// <summary>
        /// Возвращает список моделей фактов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<PersonFactModel> GetFacts(int id);

        /// <summary>
        /// Add or Update Person entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ServiceResponce SavePerson(PersonModel model, int userId);

        /// <summary>
        /// Delete Person entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceResponce DeletePerson(int id);

        /// <summary>
        /// Добавить/Изменить имена антропометрических характеристик
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        ServiceResponce UpdateAntroNames(IEnumerable<PersonAntroNameModel> models);

        /// <summary>
        /// Удалить имя антропометрической характеристики
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        ServiceResponce DeleteAntroNames(int id);

        /// <summary>
        /// Добавить/обновить антропометрические характеристики для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ServiceResponce UpdateAntros(int pesonId, IEnumerable<PersonAntroModel> models, int userId);

        /// <summary>
        /// Добавить/обновить антропометрические характеристики для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateAntros(PersonAntroModel model, int userId);

        /// <summary>
        /// Удалить антропометрические характеристики
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        ServiceResponce DeleteAntros(IEnumerable<PersonAntroModel> models);

        /// <summary>
        /// Возвращает список типов связи
        /// </summary>
        /// <returns></returns>
        IList<PersonConnectionTypeModel> GetConnectionTypes();

        /// <summary>
        /// Добавить/Изменить типы связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce UpdateConnectionTypes(IEnumerable<PersonConnectionTypeModel> models);

        /// <summary>
        /// Удалить типы связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteConnectionTypes(IEnumerable<PersonConnectionTypeModel> models);

        /// <summary>
        /// Добавить/Изменить связи для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ServiceResponce UpdateConnection(int pesonId, IEnumerable<PersonConnectionModel> models, int userId);
        /// <summary>
        /// Добавить/Изменить связи для Person
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateConnection(PersonConnectionModel model, int userId);

        /// <summary>
        /// Удалить связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteConnection(IEnumerable<PersonConnectionModel> models);

        /// <summary>
        /// Возвращает список типов ссылок
        /// </summary>
        /// <returns></returns>
        IList<PersonSocialLinkTypeModel> GetSocialLinkTypes();

        /// <summary>
        /// Добавить/Изменить типы ссылок
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce UpdateSocialLinkTypes(IEnumerable<PersonSocialLinkTypeModel> models);

        /// <summary>
        /// Удалить типы ссылок
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteSocialLinkTypes(IEnumerable<PersonSocialLinkTypeModel> models);

        /// <summary>
        /// Добавить/Изменить ссылки для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ServiceResponce UpdateSocialLink(int pesonId, IEnumerable<PersonSocialLinkModel> models, int userId);

        /// <summary>
        /// Удалить ссылки
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteSocialLink(IEnumerable<PersonSocialLinkModel> models);

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
        /// Добавить/Изменить список медиа для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool UpdateMedia(int pesonId, IEnumerable<PersonMediaModel> models, int userId);

        /// <summary>
        /// Добавить/Изменить медиа
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateMedia(PersonMediaModel model, int userId);

        /// <summary>
        /// Связать Media и Person
        /// </summary>
        /// <param name="idMedia"></param>
        /// <param name="idPerson"></param>
        /// <returns></returns>
        bool LinkMediaPerson(int idMedia, int idPerson);

        /// <summary>
        /// Связать Media и Event
        /// </summary>
        /// <param name="idMedia"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        bool LinkMediaEvent(int idMedia, int idEvent);

        /// <summary>
        /// Связать Antro и Person
        /// </summary>
        /// <param name="idAntro"></param>
        /// <param name="idPerson"></param>
        /// <returns></returns>
        bool LinkAntroPerson(int idAntro, int idPerson);

        /// <summary>
        /// Связать Antro и Event
        /// </summary>
        /// <param name="idAntro"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        bool LinkAntroEvent(int idAntro, int idEvent);

        /// <summary>
        /// Удалить список медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteMedia(IEnumerable<PersonMediaModel> models);

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
        /// Добавить/Изменить список описаний для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ServiceResponce UpdateDescriptions(int pesonId, IEnumerable<PersonDescriptionModel> models, int userId);

        /// <summary>
        /// Добавить/Изменить описание
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateDescriptions(PersonDescriptionModel model, int userId);

        /// <summary>
        /// Удалить список описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteDescriptions(IEnumerable<PersonDescriptionModel> models);

        /// <summary>
        /// Связывает описания
        /// </summary>
        /// <returns></returns>
        bool LinkDescriptions(int idTizer, int idDesc);

        /// <summary>
        /// Возвращает список типов фактов
        /// </summary>
        /// <returns></returns>
        IList<PersonFactTypeModel> GetFactsTypes();

        /// <summary>
        /// Добавить/Изменить типы фактов
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce UpdateFactTypes(IEnumerable<PersonFactTypeModel> models);

        /// <summary>
        /// Удалить типы фактов
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteFactTypes(IEnumerable<PersonFactTypeModel> models);

        /// <summary>
        /// Добавить/Изменить список фактов для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ServiceResponce UpdateFacts(int pesonId, IEnumerable<PersonFactModel> models, int userId);

        /// <summary>
        /// Добавить/Изменить список фактов для Person
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateFacts(PersonFactModel model, int userId);

        /// <summary>
        /// Удалить факты
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteFacts(IEnumerable<PersonFactModel> models);

        /// <summary>
        /// Возвращает список <see cref="CountryModel"/> 
        /// </summary>
        /// <param name="foundName"></param>
        /// <returns></returns>
        IList<CountryModel> GetCountries(string foundName);

        /// <summary>
        /// Возвращает список <see cref="CountryPlaceModel"/> 
        /// </summary>
        /// <param name="foundName"></param>
        /// <returns></returns>
        IList<CountryPlaceModel> GetCountryPlaces(string foundName);

        /// <summary>
        /// Возвращает список <see cref="CountryPlaceModel"/> 
        /// </summary>
        /// <param name="idCountry"></param>
        /// <param name="foundName"></param>
        /// <returns></returns>
        IList<CountryPlaceModel> GetCountryPlaces(int idCountry, string foundName);

        /// <summary>
        /// Добавить город
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdatePlace(CountryPlaceModel model);

        /// <summary>
        /// Сохранить схему описания
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="parsonId"></param>
        /// <returns></returns>
        bool SaveDescriptionSchema(int id, PageBlockModel model, int parsonId);

        /// <summary>
        /// Возвращает список моделей источников
        /// </summary>
        /// <returns></returns>
        IList<UserPageCategoryModel> GetUserPageCategory();

        
    }

}