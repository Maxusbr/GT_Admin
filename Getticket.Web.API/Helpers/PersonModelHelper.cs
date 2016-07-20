using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class PersonModelHelper
    {
        /// <summary>
        /// Оборачивает <paramref name="person"/> в модель
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static PersonModel GetPersonModel(Person person)
        {
            if (person == null)
            {
                return null;
            }
            var model = new PersonModel
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                Patronymic = person.Patronymic,
                IdSex = person.id_Sex,
                Sex = person.Sex.Name,
                Bithday = person.Bithday,
                NameLatin = person.NameLatin,
                LastNameLatin = person.LastNameLatin,
                PatronymicLatin = person.PatronymicLatin,
                IdBithplace = person.id_Bithplace,
                Place = person.Place?.Name,
                Country = person.Place?.Country?.Name
            };

            return model;
        }

        /// <summary>
        ///  Оборачивает <paramref name="persons"/> в модель
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        public static IList<PersonModel> GetPersonModels(IList<Person> persons)
        {
            return persons?.Select(GetPersonModel).ToList();
        }

        /// <summary>
        /// Оборачивает <paramref name="connections"/> в модели
        /// </summary>
        /// <param name="connections"></param>
        /// <returns></returns>
        public static IList<PersonConnectionModel> GetConnectionModels(IList<PersonConnection> connections)
        {
            var list = connections.Select(GetConnectionModel);
            return list.ToList();
        }

        /// <summary>
        /// Оборачивает <paramref name="connection"/> в модель
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static PersonConnectionModel GetConnectionModel(PersonConnection connection)
        {
            return connection != null ? new PersonConnectionModel
            {
                Id = connection.Id,
                id_ConnectionType = connection.id_ConnectionType,
                id_Event = connection.id_Event,
                id_Person = connection.id_Person,
                id_PersonConnectTo = connection.id_PersonConnectTo,
                PersonConnectTo = GetPersonModel(connection.PersonConnectTo),
                Event = GetEventModel(connection.Event),
                PersonConnectionType = connection.PersonConnectionType.Name,
                Description = connection.Description
            } : new PersonConnectionModel();
        }

        /// <summary>
        /// Оборачивает <paramref name="entity"/> в модель
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EventModel GetEventModel(Event entity)
        {
            return entity != null ? new EventModel
            {
                Id = entity.Id,
                Name = entity.Name,
                DateStartSold = entity.DateStartSold,
                DateStopSold = entity.DateStopSold,
                Description = entity.Description,
                EventDate = entity.EventDate,
                TicketReturn = entity.TicketReturn,
                EventType = entity.EventType?.Name
            } : new EventModel();
        }

        /// <summary>
        /// Оборачивает <paramref name="antros"/> в модели
        /// </summary>
        /// <param name="antros"></param>
        /// <returns></returns>
        public static IList<PersonAntroModel> GetPersonAntroModels(IList<PersonAntro> antros)
        {
            var list = antros.Select(GetPersonAntroModel);
            return list.ToList();
        }

        private static PersonAntroModel GetPersonAntroModel(PersonAntro antroEntity)
        {
            return antroEntity != null ? new PersonAntroModel
            {
                Id = antroEntity.Id,
                IdPerson = antroEntity.id_Person,
                IdAntro = antroEntity.id_Antro,
                Value = antroEntity.Value,
                AntroName = antroEntity.AntroName.Name
            } : new PersonAntroModel();
        }

        /// <summary>
        /// Оборачивает <paramref name="links"/> в модели
        /// </summary>
        /// <param name="links"></param>
        /// <returns></returns>
        public static IList<PersonSocialLinkModel> GetSocialLinkModels(IList<PersonSocialLink> links)
        {
            var list = links.Select(GetSocialLinkModel);
            return list.ToList();
        }

        private static PersonSocialLinkModel GetSocialLinkModel(PersonSocialLink link)
        {
            return link != null ? new PersonSocialLinkModel
            {
                Id = link.Id,
                id_Person = link.id_Person,
                IdSocialLinkType = link.id_SocialLinkType,
                Link = link.Link,
                PersonSocialLinkType = link.PersonSocialLinkType.Name
            } : new PersonSocialLinkModel();
        }

        /// <summary>
        /// Оборачивает <paramref name="listMedia"/> в модели
        /// </summary>
        /// <param name="listMedia"></param>
        /// <returns></returns>
        public static IList<PersonMediaModel> GetMediaModels(IList<PersonMedia> listMedia)
        {
            var list = listMedia.Select(GetMediaModel);
            return list.ToList();
        }

        private static PersonMediaModel GetMediaModel(PersonMedia media)
        {
            return media != null ? new PersonMediaModel
            {
                Id = media.Id,
                id_Person = media.id_Person,
                id_MediaType = media.id_MediaType,
                MediaLink = media.MediaLink
            } : new PersonMediaModel();
        }


        /// <summary>
        /// Оборачивает <paramref name="descriptions"/> в модели
        /// </summary>
        /// <param name="descriptions"></param>
        /// <returns></returns>
        public static IList<PersonDescriptionModel> GetDescriptionModels(IList<PersonDescription> descriptions)
        {
            var list = descriptions.Select(GetDescriptionModel);
            return list.ToList();
        }

        private static PersonDescriptionModel GetDescriptionModel(PersonDescription description)
        {
            return description != null ? new PersonDescriptionModel
            {
                Id = description.Id,
                id_Person = description.id_Person,
                id_DescriptionType = description.id_DescriptionType,
                PersonDescriptionType = description.PersonDescriptionType?.Name,
                DescriptionText = description.DescriptionText
            } : new PersonDescriptionModel();
        }

        /// <summary>
        /// Get Person entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Person GetPerson(PersonModel model)
        {
            if (model == null)
            {
                return null;
            }
            var person = new Person
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                Bithday = model.Bithday,
                NameLatin = model.NameLatin,
                LastNameLatin = model.LastNameLatin,
                PatronymicLatin = model.PatronymicLatin,
                id_Sex = model.IdSex,
                id_Bithplace = model.IdBithplace,
            };
            return person;
        }

        /// <summary>
        /// Get Antro names
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<PersonAntroNameModel> GetPersonAntroNameModels(IList<PersonAntroName> result)
        {
            return result.Select(o => new PersonAntroNameModel {Id = o.Id, Name = o.Name}).ToList();
        }

        /// <summary>
        /// Get connection type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<PersonConnectionTypeModel> GetConnectionTypeModels(IList<PersonConnectionType> result)
        {
            return result.Select(o => new PersonConnectionTypeModel {Id = o.Id, Name = o.Name}).ToList();
        }

        /// <summary>
        /// Get social link type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<PersonSocialLinkTypeModel> GetSocialLinkTypeModels(IList<PersonSocialLinkType> result)
        {
            return result.Select(o => new PersonSocialLinkTypeModel {Id = o.Id, Name = o.Name}).ToList();
        }

        /// <summary>
        /// Get media type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<PersonMediaTypeModel> GetMediaTypeModels(IList<PersonMediaType> result)
        {
            return result.Select(o => new PersonMediaTypeModel { Id = o.Id, Name = o.Name}).ToList();
        }

        /// <summary>
        /// Get description type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<PersonDescriptionTypeModel> GetDescriptionTypeModels(IList<PersonDescriptionType> result)
        {
            return result.Select(o => new PersonDescriptionTypeModel { Id = o.Id, Name = o.Name }).ToList();
        }
    }
}