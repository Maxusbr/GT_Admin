using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Helpers;
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
        IList<PersonConnectionModel> GetConnection(int id);

        /// <summary>
        /// Возвращает список моделей интернет-ссылок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonSocialLinkModel> GetSocialLinks(int id);

        /// <summary>
        /// Возвращает список моделей интернет-ссылок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonMediaModel> GetMedia(int id);

        /// <summary>
        /// Возвращает список моделей описаний
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<PersonDescriptionModel> GetDescriptions(int id);

        /// <summary>
        /// Add or Update Person entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SavePerson(PersonModel model);

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
        /// <returns></returns>
        ServiceResponce UpdateAntros(int pesonId, IEnumerable<PersonAntroModel> models);

        /// <summary>
        /// Удалить антропометрические характеристики для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        ServiceResponce DeleteAntros(int pesonId, IEnumerable<PersonAntroModel> models);

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
        /// <returns></returns>
        ServiceResponce UpdateConnection(int pesonId, IEnumerable<PersonConnectionModel> models);

        /// <summary>
        /// Удалить связи для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteConnection(int pesonId, IEnumerable<PersonConnectionModel> models);

        /// <summary>
        /// Возвращает список типов ссылок
        /// </summary>
        /// <returns></returns>
        IList<PersonSocialLinkTypeModel> GetSocialLinkTipes();

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
        /// <returns></returns>
        ServiceResponce UpdateSocialLink(int pesonId, IEnumerable<PersonSocialLinkModel> models);

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
        IList<PersonMediaTypeModel> GetMediaTypes();

        /// <summary>
        /// Добавить/Изменить типы медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce UpdateMediaTypes(IEnumerable<PersonMediaTypeModel> models);

        /// <summary>
        /// Удалить типы медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteMediaTypes(IEnumerable<PersonMediaTypeModel> models);

        /// <summary>
        /// Добавить/Изменить список медиа для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce UpdateMedia(int pesonId, IEnumerable<PersonMediaModel> models);

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
        /// <returns></returns>
        ServiceResponce UpdateDescriptions(int pesonId, IEnumerable<PersonDescriptionModel> models);

        /// <summary>
        /// Удалить список описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        ServiceResponce DeleteDescriptions(IEnumerable<PersonDescriptionModel> models);
    }

}