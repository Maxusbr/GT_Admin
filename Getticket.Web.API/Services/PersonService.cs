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
    /// Сервис для управления Person
    /// (обновление, регистрация, удаление и т.п.)
    /// </summary>
    public class PersonService: IPersonService
    {
        private readonly IPersonRepository _personRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="personRepository"></param>
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        /// <summary>
        /// Воозвращает всех Persons
        /// </summary>
        /// <returns></returns>
        public IList<PersonModel> GetAll()
        {
            var persons = _personRepository.FindAllPerson();
            return PersonModelHelper.GetPersonModels(persons);
        }

        /// <summary>
        /// Возвращает страницу списка Persons с учетом параметров поиска <paramref name="searchParams"/>
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        public IList<PersonModel> GetPersons(int pageNumber, int pageSize, PersonSearchParams searchParams = null)
        {
            var page = new PageInfo(pageNumber, pageSize);
            var sex = searchParams?.SexId;
            var persons = _personRepository.FindPerson(page, searchParams?.Alphabetically, sex);
            var listPerson = PersonModelHelper.GetPersonModels(persons);
            foreach (var item in listPerson)
            {
                var models = _personRepository.GetConnections(item.Id);
                item.Connections = PersonModelHelper.GetConnectionModels(models);
                var con = item.Connections.FirstOrDefault(o => o.Event != null);
                item.EventName = con?.Event?.Name;
                item.EventType = con?.Event?.EventType;                
            }
            return listPerson;
        }

        /// <summary>
        /// Воозвращает модель PersonModel по <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonModel GetPerson(int id)
        {
            var result = _personRepository.FindPersonById(id);
            return PersonModelHelper.GetPersonModel(result);
        }

        /// <summary>
        /// Возвращает список названий антропометрических характеристик 
        /// </summary>
        /// <returns></returns>
        public IList<PersonAntroNameModel> GetAntroNames()
        {
            var result = _personRepository.GetAntroNames();
            return PersonModelHelper.GetPersonAntroNameModels(result);
        }

        /// <summary>
        /// Возвращает список моделей антропометрических характеристик 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<PersonAntroModel> GetPersonAntros(int id)
        {
            var result = _personRepository.GetPersonAntros(id);
            return PersonModelHelper.GetPersonAntroModels(result);
        }

        /// <summary>
        /// Возвращает список связей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EntityCollection<PersonConnectionModel>> GetConnection(int id)
        {
            var list = PersonModelHelper.GetConnectionModels(_personRepository.GetConnections(id));
            var types = list.GroupBy(o => o.id_ConnectionType).Select(o => o.Key);
            return types.Select(tp => new EntityCollection<PersonConnectionModel> { List = list.Where(o => o.id_ConnectionType == tp), Type = tp});
        }

        /// <summary>
        /// Возвращает список моделей интернет-ссылок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EntityCollection<PersonSocialLinkModel>> GetSocialLinks(int id)
        {
            var list = PersonModelHelper.GetSocialLinkModels(_personRepository.GetSocialLinks(id));
            var types = list.GroupBy(o => o.IdSocialLinkType).Select(o => o.Key);
            return types.Select(tp => new EntityCollection<PersonSocialLinkModel> { List = list.Where(o => o.IdSocialLinkType == tp), Type = tp });

        }

        /// <summary>
        /// Возвращает список моделей медиа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EntityCollection<PersonMediaModel>> GetMedia(int id)
        {
            var list = PersonModelHelper.GetMediaModels(_personRepository.GetMedia(id));
            var types = list.GroupBy(o => o.id_MediaType).Select(o => o.Key);
            return types.Select(tp => new EntityCollection<PersonMediaModel> { List = list.Where(o => o.id_MediaType == tp), Type = tp });
        }

        /// <summary>
        /// Возвращает список моделей описаний
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EntityCollection<PersonDescriptionModel>> GetDescriptions(int id)
        {
            var list = PersonModelHelper.GetDescriptionModels(_personRepository.GetDescriptions(id));
            var types = list.GroupBy(o => o.id_DescriptionType).Select(o => o.Key);
            return types.Select(tp => new EntityCollection<PersonDescriptionModel> {List = list.Where(o => o.id_DescriptionType == tp)});
        }

        /// <summary>
        /// Add or Update Person entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ServiceResponce SavePerson(PersonModel model)
        {
            var person = _personRepository.FindPersonById(model.Id);
            if (person == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Person with specified Id was not found");
            }
            person = PersonModelHelper.GetPerson(model);
            var res = _personRepository.SavePerson(person);
            var response = res != null ? ServiceResponce
                .FromSuccess()
                .Result("Person save")
                .Add("PersonId", person.Id) : ServiceResponce.FromFailed().Result("Error save person");
            return response;
        }

        /// <summary>
        /// Delete Person entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponce DeletePerson(int id)
        {
            var res = _personRepository.DeletePerson(id);
            var response = res ? ServiceResponce
                .FromSuccess()
                .Result("Person delete") :
                ServiceResponce
                .FromFailed()
                .Result("Error delete person");
            return response;
        }


        /// <summary>
        /// Добавить/Изменить имена антропометрических характеристик
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponce UpdateAntroNames(IEnumerable<PersonAntroNameModel> models)
        {
            foreach (var item in models)
            {
                var name = _personRepository.UpdateAntroName(new PersonAntroName { Id = item.Id, Name = item.Name });
                if (name == null) return ServiceResponce.FromFailed().Result($"Error add {item.Name}");
            }
            return ServiceResponce
                .FromSuccess()
                .Result("Antro names save complete");
        }

        /// <summary>
        /// Удалить имя антропометрической характеристики
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponce DeleteAntroNames(int id)
        {
            return _personRepository.DeleteAntroName(id) ?
                ServiceResponce
                .FromSuccess()
                .Result("Antro names delete complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error delete Antro names with id = {id}");
        }

        /// <summary>
        /// Добавить/обновить антропометрические характеристики для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateAntros(int pesonId, IEnumerable<PersonAntroModel> models)
        {
            var result = _personRepository.AddPersonAntros(
                models.Select(o => new PersonAntro
                {
                    Id = o.Id,
                    id_Antro = o.IdAntro,
                    id_Person = pesonId,
                    Value = o.Value
                }).ToList());
            return result ? ServiceResponce
                .FromSuccess()
                .Result("Antros save complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error save antros");
        }

        /// <summary>
        /// Удалить антропометрические характеристики для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponce DeleteAntros(int pesonId, IEnumerable<PersonAntroModel> models)
        {
            var result = _personRepository.DeletePersonAntros(models.Select(o => new PersonAntro
            {
                Id = o.Id,
                id_Antro = o.IdAntro,
                id_Person = pesonId,
                Value = o.Value
            }).ToList());
            return result ? ServiceResponce
                .FromSuccess()
                .Result("Antros delete complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error delete antros");
        }

        /// <summary>
        /// Возвращает список типов связи
        /// </summary>
        /// <returns></returns>
        public IList<PersonConnectionTypeModel> GetConnectionTypes()
        {
            var result = _personRepository.GetConnectionTypes();
            return PersonModelHelper.GetConnectionTypeModels(result);
        }

        /// <summary>
        /// Добавить/Изменить типы связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateConnectionTypes(IEnumerable<PersonConnectionTypeModel> models)
        {
            foreach (var item in models)
            {
                var result = _personRepository.UpdateConnectionType(new PersonConnectionType { Id = item.Id, Name = item.Name });
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
        public ServiceResponce DeleteConnectionTypes(IEnumerable<PersonConnectionTypeModel> models)
        {
            if (models.Any(item => !_personRepository.DeleteConnectionType(item.Id)))
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
        /// Добавить/Изменить связи для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateConnection(int pesonId, IEnumerable<PersonConnectionModel> models)
        {
            var result = _personRepository.AddConnections(
                models.Select(o => new PersonConnection
                {
                    Id = o.Id,
                    id_Person = pesonId,
                    id_ConnectionType = o.id_ConnectionType,
                    id_Event = o.id_Event,
                    id_PersonConnectTo = o.id_PersonConnectTo
                }).ToList());
            return result ? ServiceResponce
                .FromSuccess()
                .Result("Connections save complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error save connections");
        }

        /// <summary>
        /// Удалить связи для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteConnection(int pesonId, IEnumerable<PersonConnectionModel> models)
        {
            var result = _personRepository.DeleteConnections(models.Select(o => new PersonConnection
            {
                Id = o.Id,
                id_Person = pesonId,
                id_ConnectionType = o.id_ConnectionType,
                id_Event = o.id_Event,
                id_PersonConnectTo = o.id_PersonConnectTo
            }).ToList());
            return result ? ServiceResponce
                .FromSuccess()
                .Result("Connections delete complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error delete connections");
        }


        /// <summary>
        /// Возвращает список типов ссылок
        /// </summary>
        /// <returns></returns>
        public IList<PersonSocialLinkTypeModel> GetSocialLinkTipes()
        {
            var result = _personRepository.GetLinkTypes();
            return PersonModelHelper.GetSocialLinkTypeModels(result);
        }

        /// <summary>
        /// Добавить/Изменить типы ссылок
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateSocialLinkTypes(IEnumerable<PersonSocialLinkTypeModel> models)
        {
            foreach (var item in models)
            {
                var result = _personRepository.UpdateLinkType(new PersonSocialLinkType { Id = item.Id, Name = item.Name });
                if (result == null) return ServiceResponce
                 .FromFailed()
                 .Result($"Error save link type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Link type save complete");
        }

        /// <summary>
        /// Удалить типы ссылок
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteSocialLinkTypes(IEnumerable<PersonSocialLinkTypeModel> models)
        {
            if (models.Any(item => !_personRepository.DeleteLinkType(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete link type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Link type delete complete");
        }

        /// <summary>
        /// Добавить/Изменить ссылки для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateSocialLink(int pesonId, IEnumerable<PersonSocialLinkModel> models)
        {
            var result = _personRepository.UpdateSocialLinks(
                models.Select(o => new PersonSocialLink
                {
                    Id = o.Id,
                    id_Person = pesonId,
                    id_SocialLinkType = o.IdSocialLinkType
                }).ToList());
            return result ? ServiceResponce
                .FromSuccess()
                .Result("SocialLink save complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error save SocialLink");
        }

        /// <summary>
        /// Удалить ссылки
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteSocialLink(IEnumerable<PersonSocialLinkModel> models)
        {
            if (models.Any(item => !_personRepository.DeleteSocialLink(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete SocialLink");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("SocialLink delete complete");
        }

        /// <summary>
        /// Возвращает список типов медиа
        /// </summary>
        /// <returns></returns>
        public IList<PersonMediaTypeModel> GetMediaTypes()
        {
            var result = _personRepository.GetMediaTypes();
            return PersonModelHelper.GetMediaTypeModels(result);
        }

        /// <summary>
        /// Добавить/Изменить типы медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateMediaTypes(IEnumerable<PersonMediaTypeModel> models)
        {
            foreach (var item in models)
            {
                var result = _personRepository.UpdateMediaType(new PersonMediaType { Id = item.Id, Name = item.Name });
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
        public ServiceResponce DeleteMediaTypes(IEnumerable<PersonMediaTypeModel> models)
        {
            if (models.Any(item => !_personRepository.DeleteMediaType(item.Id)))
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
        /// Добавить/Изменить список медиа для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateMedia(int pesonId, IEnumerable<PersonMediaModel> models)
        {
            if (models.Select(item => _personRepository.UpdateMedia(new PersonMedia
            {
                Id = item.Id,
                id_Person = pesonId,
                id_MediaType = item.id_MediaType,
                MediaLink = item.MediaLink
            })).Any(result => result == null))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error save media");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Media save complete");
        }

        /// <summary>
        /// Удалить список медиа
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteMedia(IEnumerable<PersonMediaModel> models)
        {
            if (models.Any(item => !_personRepository.DeleteMedia(item.Id)))
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
        public IList<PersonDescriptionTypeModel> GetDescriptionTypes()
        {
            var result = _personRepository.GetDescriptionTypes();
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
                var result = _personRepository.UpdateDescriptionType(new PersonDescriptionType { Id = item.Id, Name = item.Name });
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
            if (models.Any(item => !_personRepository.DeleteDescriptionType(item.Id)))
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
        /// Добавить/Изменить список описаний для Person c Id = <paramref name="pesonId"/>
        /// </summary>
        /// <param name="pesonId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce UpdateDescriptions(int pesonId, IEnumerable<PersonDescriptionModel> models)
        {
            if (models.Select(item => _personRepository.UpdateDescription(new PersonDescription
            {
                Id = item.Id,
                id_Person = pesonId,
                id_DescriptionType = item.id_DescriptionType,
                DescriptionText = item.DescriptionText
            })).Any(result => result == null))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error save description");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Descriptions save complete");
        }

        /// <summary>
        /// Удалить список описаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteDescriptions(IEnumerable<PersonDescriptionModel> models)
        {
            if (models.Any(item => !_personRepository.DeleteDescription(item.Id)))
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