using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using Getticket.Web.DAL.Infrastructure;
using UserPageCategoryModel = Getticket.Web.API.Models.UserPageCategoryModel;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис для управления Person
    /// (обновление, регистрация, удаление и т.п.)
    /// </summary>
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ILogRepository _logRepository;
        private readonly ITagRepository _tagRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="personRepository"></param>
        /// <param name="logRepository"></param>
        public PersonService(IPersonRepository personRepository, ILogRepository logRepository, ITagRepository tagRepository)
        {
            _personRepository = personRepository;
            _logRepository = logRepository;
            _tagRepository = tagRepository;
        }

        /// <summary>
        /// Воозвращает всех Persons
        /// </summary>
        /// <returns></returns>
        public IList<PersonModel> GetAll()
        {
            var persons = _personRepository.FindAllPerson();
            var listPerson = PersonModelHelper.GetPersonModels(persons);
            foreach (var item in listPerson)
            {
                var models = _personRepository.GetConnections(item.Id);
                item.Connections = PersonModelHelper.GetConnectionModels(models);
                var con = item.Connections.FirstOrDefault(o => o.Event != null);
                item.EventName = con?.Event?.Name;
                item.EventType = con?.Event?.EventCategory;
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangePerson(item.Id));
            }
            return listPerson;
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
                item.EventType = con?.Event?.EventCategory;
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangePerson(item.Id));
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
        /// <see cref="IPersonService.GetCounts"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CountsModel GetCounts(int id)
        {
            return new CountsModel
            {
                CountDescriptions = _personRepository.GetCountDescriptions(id),
                CountFacts = _personRepository.GetCountFacts(id),
                CountConnects = _personRepository.GetCountConnects(id),
                CountMedias = _personRepository.GetCountMedias(id),
                CountLinks = _personRepository.GetCountLinks(id),
                CountAntros = _personRepository.GetCountAntros(id)
            };
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
            var result = PersonModelHelper.GetPersonAntroModels(_personRepository.GetPersonAntros(id));
            foreach (var item in result)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangePersonAntro(item.IdPerson, item.Id));
            }
            return result;
        }

        /// <summary>
        /// Возвращает список связей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EntityCollection<PersonConnectionModel>> GetConnection(int id)
        {
            var list = PersonModelHelper.GetConnectionModels(_personRepository.GetConnections(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangePersonConnection(item.id_Person, item.Id));
            }
            var types = list.GroupBy(o => o.id_ConnectionType).Select(o => o.Key);
            return types.Select(tp => new EntityCollection<PersonConnectionModel> { List = list.Where(o => o.id_ConnectionType == tp), Type = tp });
        }

        /// <summary>
        /// Возвращает список моделей интернет-ссылок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EntityCollection<PersonSocialLinkModel>> GetSocialLinks(int id)
        {
            var list = PersonModelHelper.GetSocialLinkModels(_personRepository.GetSocialLinks(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangePersonLink(item.id_Person, item.Id));
            }
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
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangePersonMedia(item.id_Person, item.Id));
                item.Tags = TagModelHelper.GeTagModels(_tagRepository.GePersonMediaTags(item.Id));
            }
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
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangePersonDescription(item.id_Person, item.Id));
            }
            var types = list.GroupBy(o => o.id_DescriptionType).Select(o => o.Key);
            return types.Select(tp => new EntityCollection<PersonDescriptionModel> { List = list.Where(o => o.id_DescriptionType == tp), Type = tp });
        }

        /// <see cref="IPersonService.GetListDescriptions" />
        public IEnumerable<PersonDescriptionModel> GetListDescriptions(int id)
        {
            var list = PersonModelHelper.GetDescriptionModels(_personRepository.GetDescriptions(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangePersonDescription(item.id_Person, item.Id));
            }
            return list;
        }

        /// <see cref="IPersonService.GetFacts" />
        public IEnumerable<PersonFactModel> GetFacts(int id)
        {
            var list = PersonModelHelper.GetFactModels(_personRepository.GetPersonFacts(id));
            foreach (var item in list)
            {
                item.LastChange = LogModelHelper.GetLastChangeModel(_logRepository.GetLastChangePersonFact(item.id_Person, item.Id));
            }
            //var types = list.GroupBy(o => o.id_FactType).Select(o => o.Key);
            //return types.Select(tp => new EntityCollection<PersonFactModel> { List = list.Where(o => o.id_FactType == tp), Type = tp });
            return list;
        }

        /// <summary>
        /// Add or Update Person entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResponce SavePerson(PersonModel model, int userId)
        {
            var person = PersonModelHelper.GetPerson(model);
            var res = _personRepository.SavePerson(person, userId);
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
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResponce UpdateAntros(int pesonId, IEnumerable<PersonAntroModel> models, int userId)
        {
            var result = _personRepository.AddPersonAntros(
                models.Select(o => new PersonAntro
                {
                    Id = o.Id,
                    id_Antro = o.IdAntro,
                    id_Person = pesonId,
                    Value = o.Value
                }).ToList(), userId);
            return result ? ServiceResponce
                .FromSuccess()
                .Result("Antros save complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error save antros");
        }

        /// <summary>
        /// Удалить антропометрические характеристики
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponce DeleteAntros(IEnumerable<PersonAntroModel> models)
        {
            var result = _personRepository.DeletePersonAntros(models.Select(o => new PersonAntro
            {
                Id = o.Id,
                id_Antro = o.IdAntro,
                id_Person = o.IdPerson,
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
                var result = _personRepository.UpdateConnectionType(new ConnectionType { Id = item.Id, Name = item.Name });
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
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResponce UpdateConnection(int pesonId, IEnumerable<PersonConnectionModel> models, int userId)
        {
            var result = _personRepository.AddConnections(
                models.Select(o => new PersonConnection
                {
                    Id = o.Id,
                    id_Person = pesonId,
                    id_ConnectionType = o.id_ConnectionType,
                    id_Event = o.id_Event,
                    id_PersonConnectTo = o.id_PersonConnectTo,
                    Description = o.Description
                }).ToList(), userId);
            return result ? ServiceResponce
                .FromSuccess()
                .Result("Connections save complete") :
                ServiceResponce
                .FromFailed()
                .Result($"Error save connections");
        }

        /// <see cref="IPersonService.UpdateConnection(PersonConnectionModel, int)"/>
        public int UpdateConnection(PersonConnectionModel model, int userId)
        {
            var res = _personRepository.SaveConnection(new PersonConnection
            {
                Id = model.Id,
                id_Person = model.id_Person,
                id_ConnectionType = model.id_ConnectionType,
                id_Event = model.id_Event,
                id_PersonConnectTo = model.id_PersonConnectTo,
                Description = model.Description
            }, userId);
            return res?.Id ?? -1;
        }

        /// <summary>
        /// Удалить связи
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public ServiceResponce DeleteConnection(IEnumerable<PersonConnectionModel> models)
        {
            var result = _personRepository.DeleteConnections(models.Select(o => new PersonConnection
            {
                Id = o.Id,
                id_Person = o.id_Person,
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
        public IList<PersonSocialLinkTypeModel> GetSocialLinkTypes()
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
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResponce UpdateSocialLink(int pesonId, IEnumerable<PersonSocialLinkModel> models, int userId)
        {
            var result = _personRepository.UpdateSocialLinks(
                models.Select(o => new PersonSocialLink
                {
                    Id = o.Id,
                    id_Person = pesonId,
                    id_SocialLinkType = o.IdSocialLinkType,
                    Link = o.Link,
                    Description = o.Description,
                    Destination = (DestinationTypes)o.Destination
                }).ToList(), userId);
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
        public IList<MediaTypeModel> GetMediaTypes()
        {
            var result = _personRepository.GetMediaTypes();
            return PersonModelHelper.GetMediaTypeModels(result);
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
                var result = _personRepository.UpdateMediaType(new MediaType { Id = item.Id, Name = item.Name });
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
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool UpdateMedia(int pesonId, IEnumerable<PersonMediaModel> models, int userId)
        {
            return models.Select(item => _personRepository.UpdateMedia(new PersonMedia
            {
                Id = item.Id,
                id_Person = pesonId,
                id_MediaType = item.id_MediaType,
                MediaLink = item.MediaLink,
                Description = item.Description,
                Name = item.Name
            }, userId)).All(result => result != null);
        }

        /// <see cref="IPersonService.UpdateMedia(PersonMediaModel, int)"/>
        public bool UpdateMedia(PersonMediaModel model, int userId)
        {
            var result = _personRepository.UpdateMedia(new PersonMedia
            {
                Id = model.Id,
                id_Person = model.id_Person,
                id_MediaType = model.id_MediaType,
                MediaLink = model.MediaLink,
                Description = model.Description,
                Name = model.Name
            }, userId);
            if (result == null) return false;
            if (!model.Tags.Any()) return true;
            return model.Tags.Select(item => _tagRepository.AddTagLink(new TagPersonMediaLink
            {
                IdTag = item.Id,
                IdMedia = result.Id,
                Tag = new Tag
                {
                    Id = item.Id,
                    Name = item.Name
                }
            })).All(res => res != null);
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
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResponce UpdateDescriptions(int pesonId, IEnumerable<PersonDescriptionModel> models, int userId)
        {
            if (models == null || models.Select(item => _personRepository.UpdateDescription(new PersonDescription
            {
                Id = item.Id,
                id_Person = pesonId,
                id_DescriptionType = item.id_DescriptionType,
                DescriptionText = item.DescriptionText,
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


        public int UpdateDescriptions(PersonDescriptionModel model, int userId)
        {
            var result = _personRepository.UpdateDescription(new PersonDescription
            {
                Id = model.Id,
                id_Person = model.id_Person,
                id_DescriptionType = model.id_DescriptionType,
                DescriptionText = model.DescriptionText,
                Status = model.Status,
                RequiredStaticDescription = model.RequiredStaticDescription,
                IdBlock = model.IdBlock,
                IdUserPageCategory = model.PageBlock?.UserPageCategoryId
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

        /// <see cref="IPersonService.LinkDescriptions"/>
        public bool LinkDescriptions(int idTizer, int idDesc)
        {
            if (idTizer == 0 || idDesc == 0) return false;
            return
                _personRepository.LinkDescriptions(new PersonDescriptionTizerLink
                {
                    IdTizer = idTizer,
                    IdStaticDescription = idDesc
                });
        }

        /// <see cref="IPersonService.GetFactsTypes"/>
        public IList<PersonFactTypeModel> GetFactsTypes()
        {
            var result = _personRepository.GetPersonFactTypes();
            return PersonModelHelper.GetFactTypeModels(result);
        }

        /// <see cref="IPersonService.UpdateFactTypes"/>
        public ServiceResponce UpdateFactTypes(IEnumerable<PersonFactTypeModel> models)
        {
            foreach (var item in models)
            {
                var result = _personRepository.UpdateFactType(new PersonFactType { Id = item.Id, Name = item.Name });
                if (result == null) return ServiceResponce
                 .FromFailed()
                 .Result($"Error save fact type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Fatc type save complete");
        }

        /// <see cref="IPersonService.DeleteFactTypes"/>
        public ServiceResponce DeleteFactTypes(IEnumerable<PersonFactTypeModel> models)
        {
            if (models.Any(item => !_personRepository.DeleteFactType(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete fact type");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Fact type delete complete");
        }

        /// <see cref="IPersonService.UpdateFacts(int, IEnumerable{PersonFactModel}, int)"/>
        public ServiceResponce UpdateFacts(int pesonId, IEnumerable<PersonFactModel> models, int userId)
        {
            if (models.Select(item => _personRepository.UpdatePersonFact(new PersonFact
            {
                Id = item.Id,
                id_Person = pesonId,
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

        /// <see cref="IPersonService.UpdateFacts(PersonFactModel, int)"/>
        public int UpdateFacts(PersonFactModel model, int userId)
        {
            var res = _personRepository.UpdatePersonFact(new PersonFact
            {
                Id = model.Id,
                id_Person = model.id_Person,
                id_FactType = model.id_FactType,
                FactText = model.FactText,
                Status = model.Status,
                Source = model.Source
            }, userId);
            return res?.Id ?? -1;
        }

        /// <see cref="IPersonService.DeleteFacts"/>
        public ServiceResponce DeleteFacts(IEnumerable<PersonFactModel> models)
        {
            if (models.Any(item => !_personRepository.DeletePersonFact(item.Id)))
            {
                return ServiceResponce
                    .FromFailed()
                    .Result($"Error delete fact");
            }

            return ServiceResponce
                .FromSuccess()
                .Result("Facts delete complete");
        }

        /// <see cref="IPersonService.GetCountries"/>
        public IList<CountryModel> GetCountries(string foundName)
        {
            var result = _personRepository.GetCountries(foundName);
            return PersonModelHelper.GetCountryModels(result);
        }

        /// <see cref="IPersonService.GetCountryPlaces"/>
        public IList<CountryPlaceModel> GetCountryPlaces(string foundName)
        {
            var result = _personRepository.GetCountryPlaces(foundName);
            return PersonModelHelper.GetCountryPlaceModels(result);
        }

        /// <see cref="IPersonService.UpdatePlace"/>
        public int UpdatePlace(string country, string place)
        {
            return _personRepository.UpdatePlace(country, place);
        }

        /// <see cref="IPersonService.SaveDescriptionSchema"/>
        public bool SaveDescriptionSchema(int id, PageBlockModel model)
        {
            return _personRepository.SaveDescriptionSchema(id,
                PageModelHelper.GetPageBlock(model),
                new UserPageCategory
                {
                    Id = model.UserPageCategoryId ?? 0,
                    Name = model.UserPageCategory
                });
        }

        /// <see cref="IPersonService.GetUserPageCategory"/>
        public IList<UserPageCategoryModel> GetUserPageCategory()
        {
            var result = _personRepository.GetUserPageCategory();
            return result.Select(o => new UserPageCategoryModel { Id = o.Id, Name = o.Name }).ToList();
        }
    }

}