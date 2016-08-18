using System;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.DAL.Enums;

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
                Sex = (int)person.Sex,
                Bithday = person.Bithday,
                NameLatin = person.NameLatin,
                LastNameLatin = person.LastNameLatin,
                PatronymicLatin = person.PatronymicLatin,
                MediaLink = person.MediaLink,
                IdBithplace = person.id_Bithplace,
                Place = person.Place?.Name,
                Country = person.Place?.Region?.Country?.Name,
                ZodiacYear = GetZodiacYears(person.Bithday),
                ZodiacMonth = GetZodiacMonth(person.Bithday),
                BirthdayTxt = person.Bithday.ToLongDateString(),
                Age = (DateTime.Now - person.Bithday).GetYears()
            };

            return model;
        }

        private static string GetZodiacMonth(DateTime birthday)
        {
            var y = birthday.Year;
            if (birthday <= new DateTime(y, 1, 20))
            {
                return "Козерог";
            }
            else if (birthday <= new DateTime(y, 2, 20))
            {
                return "Водолей";
            }
            else if (birthday <= new DateTime(y, 3, 20))
            {
                return "Рыбы";
            }
            else if (birthday <= new DateTime(y, 4, 20))
            {
                return "Овен";
            }
            else if (birthday <= new DateTime(y, 5, 20))
            {
                return "Телец";
            }
            else if (birthday <= new DateTime(y, 6, 21))
            {
                return "Близнецы";
            }
            else if (birthday <= new DateTime(y, 7, 22))
            {
                return "Рак";
            }
            else if (birthday <= new DateTime(y, 8, 23))
            {
                return "Лев";
            }
            else if (birthday <= new DateTime(y, 9, 23))
            {
                return "Дева";
            }
            else if (birthday <= new DateTime(y, 10, 23))
            {
                return "Весы";
            }
            else if (birthday <= new DateTime(y, 11, 22))
            {
                return "Скорпион";
            }
            else if (birthday <= new DateTime(y, 12, 21))
            {
                return "Стрелец";
            }
            else
            {
                return "Козерог";
            }
        }

        private static string GetZodiacYears(DateTime bithday)
        {
            switch (bithday.Year % 12)
            {
                case 0:
                    return "Обезьяна";
                case 1:
                    return "Петух";
                case 2:
                    return "Собака";
                case 3:
                    return "Свинья";
                case 4:
                    return "Крыса";
                case 5:
                    return "Бык";
                case 6:
                    return "Тигр";
                case 7:
                    return "Кролик";
                case 8:
                    return "Дракон";
                case 9:
                    return "Змея";
                case 10:
                    return "Лошадь";
                case 11:
                    return "Коза";
                default:
                    return "";
            }
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
                Event = EventModelHelper.GetEventModel(connection.Event),
                PersonConnectionType = connection.PersonConnectionType.Name,
                Description = connection.Description
            } : new PersonConnectionModel();
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
                PersonSocialLinkType = link.PersonSocialLinkType?.Name,
                Description = link.Description,
                Destination = (int)link.Destination
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
                Name = media.Name,
                id_Person = media.id_Person,
                id_MediaType = media.id_MediaType,
                MediaLink = media.MediaLink,
                MediaType = media.MediaType.Name,
                Description = media.Description
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
            var result = description != null ? new PersonDescriptionModel
            {
                Id = description.Id,
                id_Person = description.id_Person,
                id_DescriptionType = description.id_DescriptionType,
                PersonDescriptionType = description.PersonDescriptionType.Name,
                DescriptionText = description.DescriptionText,
                Status = description.Status,
                IdStaticDescription = description.StaticDescription?.Id,
                IdBlock = description.IdBlock,
                RequiredStaticDescription = description.RequiredStaticDescription,
                PageBlock = PageModelHelper.GetPageBlockModel(description.PageBlock),
                StaticDescription = description.StaticDescription != null ? GetDescriptionModel(description.StaticDescription) : null,
            } : new PersonDescriptionModel();
            if (result.PageBlock == null) return result;
            result.PageBlock.UserPageCategoryId = description?.IdUserPageCategory;
            result.PageBlock.UserPageCategory = description?.UserPageCategory?.Name;
            return result;
        }

        /// <summary>
        /// Оборачивает <paramref name="facts"/> в модели
        /// </summary>
        /// <param name="facts"></param>
        /// <returns></returns>
        public static IList<PersonFactModel> GetFactModels(IList<PersonFact> facts)
        {
            var list = facts.Select(GetFactModel);
            return list.ToList();
        }

        private static PersonFactModel GetFactModel(PersonFact fact)
        {
            return fact != null ? new PersonFactModel
            {
                Id = fact.Id,
                id_Person = fact.id_Person,
                id_FactType = fact.id_FactType,
                FactType = new PersonFactTypeModel { Id = fact.FactType.Id, Name = fact.FactType.Name, Descript = fact.FactType.Descript ?? "" },
                FactText = fact.FactText,
                Status = fact.Status,
                Source = fact.Source
            } : new PersonFactModel();
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
                MediaLink = model.MediaLink,
                Sex = (Sex)model.Sex,
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
            return result.Select(o => new PersonAntroNameModel { Id = o.Id, Name = o.Name }).ToList();
        }

        /// <summary>
        /// Get connection type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<PersonConnectionTypeModel> GetConnectionTypeModels(IList<ConnectionType> result)
        {
            return result.Select(o => new PersonConnectionTypeModel { Id = o.Id, Name = o.Name }).ToList();
        }

        /// <summary>
        /// Get social link type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<PersonSocialLinkTypeModel> GetSocialLinkTypeModels(IList<PersonSocialLinkType> result)
        {
            return result.Select(o => new PersonSocialLinkTypeModel { Id = o.Id, Name = o.Name }).ToList();
        }

        /// <summary>
        /// Get media type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<MediaTypeModel> GetMediaTypeModels(IList<MediaType> result)
        {
            return result.Select(o => new MediaTypeModel { Id = o.Id, Name = o.Name }).ToList();
        }

        /// <summary>
        /// Get description type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<PersonDescriptionTypeModel> GetDescriptionTypeModels(IList<PersonDescriptionType> result)
        {
            return result.Select(o => new PersonDescriptionTypeModel { Id = o.Id, Name = o.Name, Type = (int)o.Type }).ToList();
        }

        /// <summary>
        /// Get fact type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<PersonFactTypeModel> GetFactTypeModels(IList<PersonFactType> result)
        {
            return result.Select(o => new PersonFactTypeModel { Id = o.Id, Name = o.Name, Descript = o.Descript ?? "" }).ToList();
        }


        /// <summary>
        /// Get country models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IList<CountryModel> GetCountryModels(IList<Country> result)
        {
            return result.Select(o => new CountryModel { Id = o.Id, Name = o.Name }).ToList();
        }

        /// <summary>
        /// Get country place models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<CountryPlaceModel> GetCountryPlaceModels(IList<CountryPlace> result)
        {
            return result.Select(o => new CountryPlaceModel
            {
                Id = o.Id,
                Name = o.Name,
                IdCountry = o.Region.Country_Id,
                CountryName = o.Region.Country.Name
            }).ToList();
        }
    }
}