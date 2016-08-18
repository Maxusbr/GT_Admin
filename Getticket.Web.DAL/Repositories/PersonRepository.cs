using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using Getticket.Web.DAL.Infrastructure;
using Getticket.Web.DAL.IRepositories;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Repositories
{
    /// <summary>
    /// <see cref="IPersonRepository"/>
    /// </summary>
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        /// <see cref="IPersonRepository.FindPersonById" />
        public Person FindPersonById(int id)
        {
            if (id <= 0) return null;
            var person = db.Person.Where(u => u.Id == id)
                .Include(o => o.Place)
                .FirstOrDefault();
            return person;
        }

        /// <see cref="IPersonRepository.SavePerson" />
        public Person SavePerson(Person person, int userId)
        {
            if (person.Id == 0)
            {
                db.Entry(person).State = System.Data.Entity.EntityState.Added;
            }
            else if (person.Id > 0)
            {
                var pr = db.Person.FirstOrDefault(o => o.Id == person.Id);
                SaveLog(pr, person, person.Id, userId, LogType.Entity);
                db.Entry(pr).CurrentValues.SetValues(person);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return person;
        }

        /// <see cref="IPersonRepository.FindAllPerson" />
        public IList<Person> FindAllPerson()
        {
            Expression<Func<Person, bool>> where = x => true;
            return GetMany(where, x => x.LastName, x => x.Place);
        }

        /// <see cref="IPersonRepository.FindPerson" />
        public IList<Person> FindPerson(PageInfo page, string alphabetically, Sex? sexId = null)
        {
            var orderby = !string.IsNullOrEmpty(alphabetically) && alphabetically.Equals("A-Z");
            Expression<Func<Person, bool>> where = x => true;
            if (sexId != null)
            {
                where = where.And(x => x.Sex == sexId);
            }
            return GetMany(where, x => orderby ? x.LastNameLatin : x.LastName, x => x.Place);
        }

        /// <see cref="IPersonRepository.DeletePerson" />
        public bool DeletePerson(int id)
        {
            if (id <= 0) return false;
            var person = db.Person.FirstOrDefault(u => u.Id == id);
            if (person == null) return false;
            db.Person.Remove(person);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetPersonAntros" />
        public IList<PersonAntro> GetPersonAntros(int id)
        {
            return db.PersonAntro.Where(o => o.id_Person == id)
                .Include(e => e.AntroName).ToList();
        }

        /// <see cref="IPersonRepository.GetAntroNames" />
        public IList<PersonAntroName> GetAntroNames()
        {
            return db.PersonAntroNames.ToList();
        }

        /// <see cref="IPersonRepository.UpdateAntroName" />
        public PersonAntroName UpdateAntroName(PersonAntroName property)
        {
            if (property.Id == 0)
            {
                db.Entry(property).State = System.Data.Entity.EntityState.Added;
            }
            else if (property.Id > 0)
            {
                db.Entry(property).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return property;
        }

        /// <see cref="IPersonRepository.DeleteAntroName" />
        public bool DeleteAntroName(int id)
        {
            if (id <= 0) return false;
            var name = db.PersonAntroNames.FirstOrDefault(u => u.Id == id);
            if (name == null) return false;
            db.PersonAntroNames.Remove(name);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.UpdatePersonAntro" />
        public PersonAntro UpdatePersonAntro(PersonAntro property, int userId)
        {
            if (property.Id == 0)
            {
                db.Entry(property).State = System.Data.Entity.EntityState.Added;
            }
            else if (property.Id > 0)
            {
                var pr = db.PersonAntro.FirstOrDefault(o => o.Id == property.Id);
                SaveLog(pr, property, property.id_Person, userId, LogType.Anthropometry);
                db.Entry(pr).CurrentValues.SetValues(property);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return property;
        }



        /// <see cref="IPersonRepository.AddPersonAntros(IList{PersonAntro}, int)" />
        public bool AddPersonAntros(IList<PersonAntro> properties, int userId)
        {
            return properties.Select(property => UpdatePersonAntro(property, userId)).All(rec => rec != null);
        }

        /// <see cref="IPersonRepository.AddPersonAntros(PersonAntro, int)" />
        public int AddPersonAntros(PersonAntro property, int userId)
        {
            var res = UpdatePersonAntro(property, userId);
            return res?.Id ?? -1;
        }

        /// <see cref="IPersonRepository.DeletePersonAntros" />
        public bool DeletePersonAntros(IList<PersonAntro> properties)
        {
            foreach (var rec in properties.Select(prop => db.PersonAntro.FirstOrDefault(o => o.Id == prop.Id)))
            {
                if (rec == null) return false;
                db.PersonAntro.Remove(rec);
            }
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetChangeParams" />
        public IList<PersonChangeParam> GetChangeParams()
        {
            return db.PersonChangeParam.ToList();
        }

        /// <see cref="IPersonRepository.UpdateChangeParam" />
        public PersonChangeParam UpdateChangeParam(PersonChangeParam param)
        {
            if (param.Id == 0)
            {
                db.Entry(param).State = System.Data.Entity.EntityState.Added;
            }
            else if (param.Id > 0)
            {
                db.Entry(param).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return param;
        }

        /// <see cref="IPersonRepository.DeleteChangeParam" />
        public bool DeleteChangeParam(int id)
        {
            if (id <= 0) return false;
            var param = db.PersonChangeParam.FirstOrDefault(u => u.Id == id);
            if (param == null) return false;
            db.PersonChangeParam.Remove(param);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetChangeLog" />
        public IList<PersonChangeLog> GetChangeLog(int? id = null)
        {
            return id == null ? db.PersonChangeLog.Where(w => true)
                .Include(o => o.Person)
                .Include(o => o.PersonChangeParam)
                .Include(o => o.id_WhoChange != null ? o.User : null).ToList() :
                db.PersonChangeLog.Where(o => o.id_Person == id)
                .Include(o => o.PersonChangeParam)
                .Include(o => o.id_WhoChange != null ? o.User : null).ToList();
        }

        /// <see cref="IPersonRepository.AddChangeLogs" />
        public bool AddChangeLogs(IList<PersonChangeLog> changes)
        {
            return changes.All(AddChangeLog);
        }

        /// <see cref="IPersonRepository.AddChangeLog" />
        public bool AddChangeLog(PersonChangeLog change)
        {
            db.Entry(change).State = System.Data.Entity.EntityState.Added;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <see cref="IPersonRepository.GetConnectionTypes" />
        public IList<ConnectionType> GetConnectionTypes()
        {
            return db.ConnectionTypes.ToList();
        }

        /// <see cref="IPersonRepository.UpdateConnectionType" />
        public ConnectionType UpdateConnectionType(ConnectionType type)
        {
            if (type.Id == 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Added;
            }
            else if (type.Id > 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return type;
        }

        /// <see cref="IPersonRepository.DeleteConnectionType" />
        public bool DeleteConnectionType(int id)
        {
            if (id <= 0) return false;
            var item = db.ConnectionTypes.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.ConnectionTypes.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetConnections" />
        public IList<PersonConnection> GetConnections(int id)
        {
            return db.PersonConnections.Where(o => o.id_Person == id)
                .Include(o => o.Event)
                .Include(o => o.Event.Category)
                .Include(o => o.Event.Category.ParentCategory)
                .Include(o => o.PersonConnectionType)
                .Include(o => o.PersonConnectTo)
                .ToList();
        }

        /// <see cref="IPersonRepository.AddConnections" />
        public bool AddConnections(IList<PersonConnection> connections, int userId)
        {
            return connections.All(el => SaveConnection(el, userId) != null);
        }

        /// <see cref="IPersonRepository.SaveConnection" />
        public PersonConnection SaveConnection(PersonConnection connection, int userId)
        {
            if (connection.Id == 0)
            {
                db.Entry(connection).State = System.Data.Entity.EntityState.Added;
            }
            else if (connection.Id > 0)
            {
                var pr = db.PersonConnections.FirstOrDefault(o => o.Id == connection.Id);
                SaveLog(pr, connection, connection.id_Person, userId, LogType.Connection);
                db.Entry(pr).CurrentValues.SetValues(connection);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return connection;
        }

        /// <see cref="IPersonRepository.DeleteConnections" />
        public bool DeleteConnections(IList<PersonConnection> connections)
        {
            foreach (var connect in connections.Select(el => db.PersonConnections.FirstOrDefault(o => o.Id == el.Id)))
            {
                if (connect == null) return false;
                db.PersonConnections.Remove(connect);
            }
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetDescriptionTypes" />
        public IList<PersonDescriptionType> GetDescriptionTypes()
        {
            return db.PersonDescriptionType.ToList();
        }

        /// <see cref="IPersonRepository.UpdateDescriptionType" />
        public PersonDescriptionType UpdateDescriptionType(PersonDescriptionType type)
        {
            if (type.Id == 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Added;
            }
            else if (type.Id > 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return type;
        }

        /// <see cref="IPersonRepository.DeleteDescriptionType" />
        public bool DeleteDescriptionType(int id)
        {
            if (id <= 0) return false;
            var item = db.PersonDescriptionType.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonDescriptionType.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetDescriptions" />
        public IList<PersonDescription> GetDescriptions(int id)
        {
            var listLink = db.PersonDescriptionTizerLinks.Include(o => o.Tizer).Where(o => o.Tizer.id_Person == id).ToList();

            var list = new List<PersonDescription>();

            foreach (var el in listLink)
            {
                var item = db.PersonDescriptions.Where(o => o.Id == el.IdTizer)
                    .Include(o => o.PersonDescriptionType)
                    .Include(o => o.PageBlock)
                    .Include(o => o.PageBlock.Page)
                    .Include(o => o.UserPageCategory)
                    .FirstOrDefault();
                if (item == null) continue;
                item.StaticDescription = db.PersonDescriptions.Where(o => o.Id == el.IdStaticDescription)
                    .Include(o => o.PersonDescriptionType)
                    .Include(o => o.PageBlock)
                    .Include(o => o.PageBlock.Page).FirstOrDefault();
                list.Add(item);
            }
            var list1 = listLink.Select(s => s.IdTizer).Distinct();
            var list2 = listLink.Select(s => s.IdStaticDescription).Distinct();
            list.AddRange(
                db.PersonDescriptions.Where(o => o.id_Person == id && (!list1.Contains(o.Id) && !list2.Contains(o.Id)))
                    .Include(o => o.PersonDescriptionType)
                    .Include(o => o.PageBlock)
                    .Include(o => o.PageBlock.Page)
                    .Include(o => o.UserPageCategory)
                );
            return list;
        }

        /// <see cref="IPersonRepository.UpdateDescription" />
        public PersonDescription UpdateDescription(PersonDescription description, int userId)
        {
            if (description.Id == 0)
            {
                db.Entry(description).State = System.Data.Entity.EntityState.Added;
            }
            else if (description.Id > 0)
            {
                var pr = db.PersonDescriptions.FirstOrDefault(o => o.Id == description.Id);
                SaveLog(pr, description, description.id_Person, userId, LogType.Description);
                db.Entry(pr).CurrentValues.SetValues(description);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return description;
        }

        /// <see cref="IPersonRepository.DeleteDescription" />
        public bool DeleteDescription(int id)
        {
            if (id <= 0) return false;
            var item = db.PersonDescriptions.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonDescriptions.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.LinkDescriptions" />
        public bool LinkDescriptions(PersonDescriptionTizerLink model)
        {
            if (model.IdStaticDescription == 0 || model.IdTizer == 0) return false;
            var link =
                db.PersonDescriptionTizerLinks.FirstOrDefault(
                    o => o.IdTizer == model.IdTizer && o.IdStaticDescription == model.IdStaticDescription);

            if (link == null)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
            }
            else
                return true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <see cref="IPersonRepository.LinkMedia(MediaLinkPerson)" />
        public bool LinkMedia(MediaLinkPerson model)
        {
            if (model.IdPerson == 0 || model.IdMedia == 0) return false;
            var link =
                db.MediaPersonLinks.FirstOrDefault(
                    o => o.IdMedia == model.IdMedia && o.IdPerson == model.IdPerson);

            if (link == null)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
            }
            else
                return true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <see cref="IPersonRepository.LinkMedia(MediaLinkEvent)" />
        public bool LinkMedia(MediaLinkEvent model)
        {
            if (model.IdEvent == 0 || model.IdMedia == 0) return false;
            var link =
                db.MediaEventLinks.FirstOrDefault(
                    o => o.IdMedia == model.IdMedia && o.IdEvent == model.IdEvent);

            if (link == null)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
            }
            else
                return true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <see cref="IPersonRepository.LinkAntro(AntroLinkPerson)" />
        public bool LinkAntro(AntroLinkPerson model)
        {
            if (model.IdPerson == 0 || model.IdAntro == 0) return false;
            var link =
                db.AntroPersonLinks.FirstOrDefault(
                    o => o.IdAntro == model.IdAntro && o.IdPerson == model.IdPerson);

            if (link == null)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
            }
            else
                return true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <see cref="IPersonRepository.LinkAntro(AntroLinkEvent)" />
        public bool LinkAntro(AntroLinkEvent model)
        {
            if (model.IdEvent == 0 || model.IdAntro == 0) return false;
            var link =
                db.AntroEventLinks.FirstOrDefault(
                    o => o.IdAntro == model.IdAntro && o.IdEvent == model.IdEvent);

            if (link == null)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
            }
            else
                return true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <see cref="IPersonRepository.GetMedia" />
        public IList<PersonMedia> GetMedia(int id)
        {
            return db.PersonMedia.Where(o => o.id_Person == id).Include(o => o.MediaType).ToList();
        }

        /// <see cref="IPersonRepository.UpdateMedia" />
        public PersonMedia UpdateMedia(PersonMedia media, int userId)
        {
            if (media.Id == 0)
            {
                db.Entry(media).State = System.Data.Entity.EntityState.Added;
            }
            else if (media.Id > 0)
            {
                var pr = db.PersonMedia.FirstOrDefault(o => o.Id == media.Id);
                SaveLog(pr, media, media.id_Person, userId, LogType.Media);
                db.Entry(pr).CurrentValues.SetValues(media);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return media;
        }

        /// <see cref="IPersonRepository.DeleteMedia" />
        public bool DeleteMedia(int id)
        {
            if (id <= 0) return false;
            var item = db.PersonMedia.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonMedia.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetMediaTypes" />
        public IList<MediaType> GetMediaTypes()
        {
            return db.MediaTypes.ToList();
        }

        /// <see cref="IPersonRepository.UpdateMediaType" />
        public MediaType UpdateMediaType(MediaType type)
        {
            if (type.Id == 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Added;
            }
            else if (type.Id > 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return type;
        }

        /// <see cref="IPersonRepository.DeleteMediaType" />
        public bool DeleteMediaType(int id)
        {
            if (id <= 0) return false;
            var item = db.MediaTypes.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.MediaTypes.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetPersonFactTypes" />
        public IList<PersonFactType> GetPersonFactTypes()
        {
            return db.PersonFactTypes.ToList();
        }

        /// <see cref="IPersonRepository.UpdateFactType" />
        public PersonFactType UpdateFactType(PersonFactType type)
        {
            if (type.Id == 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Added;
            }
            else if (type.Id > 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return type;
        }

        /// <see cref="IPersonRepository.DeleteFactType" />
        public bool DeleteFactType(int id)
        {
            if (id <= 0) return false;
            var item = db.PersonFactTypes.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonFactTypes.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetPersonFacts" />
        public IList<PersonFact> GetPersonFacts(int id)
        {
            return db.PersonFacts.Where(o => o.id_Person == id)
                .Include(o => o.FactType).ToList();
        }

        /// <see cref="IPersonRepository.UpdatePersonFacts" />
        public bool UpdatePersonFacts(IList<PersonFact> facts, int userId)
        {
            return facts.All(fact => UpdatePersonFact(fact, userId) != null);
        }

        /// <see cref="IPersonRepository.UpdatePersonFact" />
        public PersonFact UpdatePersonFact(PersonFact fact, int userId)
        {
            if (fact.Id == 0)
            {
                db.Entry(fact).State = System.Data.Entity.EntityState.Added;
            }
            else if (fact.Id > 0)
            {
                var pr = db.PersonFacts.FirstOrDefault(o => o.Id == fact.Id);
                SaveLog(pr, fact, fact.id_Person, userId, LogType.Fact);
                db.Entry(pr).CurrentValues.SetValues(fact);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return fact;
        }

        /// <see cref="IPersonRepository.DeletePersonFact" />
        public bool DeletePersonFact(int id)
        {
            if (id <= 0) return false;
            var item = db.PersonFacts.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonFacts.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetLinkTypes" />
        public IList<PersonSocialLinkType> GetLinkTypes()
        {
            return db.PersonSocialLinkTypes.ToList();
        }

        /// <see cref="IPersonRepository.UpdateLinkType" />
        public PersonSocialLinkType UpdateLinkType(PersonSocialLinkType type)
        {
            if (type.Id == 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Added;
            }
            else if (type.Id > 0)
            {
                db.Entry(type).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return type;
        }

        /// <see cref="IPersonRepository.DeleteLinkType" />
        public bool DeleteLinkType(int id)
        {
            if (id <= 0) return false;
            var item = db.PersonSocialLinkTypes.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonSocialLinkTypes.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetSocialLinks" />
        public IList<PersonSocialLink> GetSocialLinks(int id)
        {
            return db.PersonSocialLinks.Where(o => o.id_Person == id)
                .Include(o => o.PersonSocialLinkType).ToList();
        }

        /// <see cref="IPersonRepository.UpdateSocialLinks" />
        public bool UpdateSocialLinks(IList<PersonSocialLink> links, int userId)
        {
            return links.All(link => UpdateSocialLink(link, userId) != null);
        }

        /// <see cref="IPersonRepository.UpdateSocialLink" />
        public PersonSocialLink UpdateSocialLink(PersonSocialLink link, int userId)
        {
            if (link.Id == 0)
            {
                db.Entry(link).State = System.Data.Entity.EntityState.Added;
            }
            else if (link.Id > 0)
            {
                var pr = db.PersonSocialLinks.FirstOrDefault(o => o.Id == link.Id);
                SaveLog(pr, link, link.id_Person, userId, LogType.Link);
                db.Entry(pr).CurrentValues.SetValues(link);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return link;
        }

        /// <see cref="IPersonRepository.DeleteSocialLink" />
        public bool DeleteSocialLink(int id)
        {
            if (id <= 0) return false;
            var item = db.PersonSocialLinks.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonSocialLinks.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetCountries" />
        public IList<Country> GetCountries(string foundName)
        {
            return string.IsNullOrEmpty(foundName) ? db.Country.ToList() :
                db.Country.Where(o => o.Name.ToLower().Contains(foundName.ToLower())).ToList();
        }

        /// <see cref="IPersonRepository.SaveCountry" />
        public Country SaveCountry(Country country)
        {
            if (country.Id == 0)
            {
                db.Entry(country).State = System.Data.Entity.EntityState.Added;
            }
            else if (country.Id > 0)
            {
                db.Entry(country).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return country;
        }

        /// <see cref="IPersonRepository.DeleteCountry" />
        public bool DeleteCountry(int id)
        {
            if (id <= 0) return false;
            var item = db.Country.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.Country.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetCountryPlaces(int)" />
        public IList<CountryPlace> GetCountryPlaces(int id)
        {
            return db.CountryPlaces.Where(o => o.Region.Country_Id == id)
                .Include(o => o.Region).Include(o => o.Region.Country).ToList();
        }

        /// <see cref="IPersonRepository.GetCountryPlaces(string)" />
        public IList<CountryPlace> GetCountryPlaces(string foundName)
        {
            var result = string.IsNullOrEmpty(foundName) ? new List<CountryPlace>() :
                db.CountryPlaces.Where(o => o.Name.ToLower().StartsWith(foundName.ToLower()))
                .Include(o => o.Region)
                .Include(o => o.Region.Country).ToList();
            return result;
        }

        /// <see cref="IPersonRepository.SaveCountryPlace" />
        public CountryPlace SaveCountryPlace(CountryPlace place)
        {
            if (place.Id == 0)
            {
                db.Entry(place).State = System.Data.Entity.EntityState.Added;
            }
            else if (place.Id > 0)
            {
                db.Entry(place).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return place;
        }

        /// <see cref="IPersonRepository.DeleteCountryPlace" />
        public bool DeleteCountryPlace(int id)
        {
            if (id <= 0) return false;
            var item = db.CountryPlaces.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.CountryPlaces.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.UpdatePlace" />
        public int UpdatePlace(string country, string place)
        {
            var cnt = db.Country.FirstOrDefault(o => o.Name.ToLower().Equals(country));
            if (cnt == null)
            {
                cnt = db.Country.Add(new Country { Name = country });
                db.SaveChanges();
            }
            var pls = db.CountryPlaces.FirstOrDefault(o => o.Name.ToLower().Equals(place));
            if (pls != null) return pls.Id;
            pls = db.CountryPlaces.Add(new CountryPlace { Name = place, id_Region = cnt.Id });
            db.SaveChanges();
            return pls.Id;
        }

        /// <see cref="IPersonRepository.GetCountDescriptions" />
        public int GetCountDescriptions(int id)
        {
            return db.PersonDescriptions.Count(o => o.id_Person == id);
        }

        /// <see cref="IPersonRepository.GetCountFacts" />
        public int GetCountFacts(int id)
        {
            return db.PersonFacts.Count(o => o.id_Person == id);
        }

        /// <see cref="IPersonRepository.GetCountConnects" />
        public int GetCountConnects(int id)
        {
            return db.PersonConnections.Count(o => o.id_Person == id);
        }

        /// <see cref="IPersonRepository.GetCountMedias" />
        public int GetCountMedias(int id)
        {
            return db.PersonMedia.Count(o => o.id_Person == id);
        }

        /// <see cref="IPersonRepository.GetCountLinks" />
        public int GetCountLinks(int id)
        {
            return db.PersonSocialLinks.Count(o => o.id_Person == id);
        }

        /// <see cref="IPersonRepository.GetCountAntros" />
        public int GetCountAntros(int id)
        {
            return db.PersonAntro.Count(o => o.id_Person == id);
        }

        /// <see cref="IPersonRepository.SaveDescriptionSchema" />
        public bool SaveDescriptionSchema(int id, PageBlock pageBlock, UserPageCategory cat, int personId)
        {
            cat = SaveUserPageCategory(cat);
            var page = SavePage(pageBlock.Page);
            if (page == null) return false;
            pageBlock.IdPage = page.Id;
            var pageblock = SavePageBlock(pageBlock);
            if (pageblock == null) return false;
            var desc = db.PersonDescriptions.FirstOrDefault(o => o.Id == id);
            if (desc == null)
            {
                desc = new PersonDescription {id_DescriptionType = 1, id_Person = personId};
                db.Entry(desc).State = EntityState.Added;
            }
            desc.IdBlock = pageblock.Id;
            desc.IdUserPageCategory = cat?.Id;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private UserPageCategory SaveUserPageCategory(UserPageCategory cat)
        {
            if (cat.Id == 0)
            {
                db.Entry(cat).State = EntityState.Added;
            }
            else if (cat.Id > 0)
            {
                var pr = db.UserPageCategories.FirstOrDefault(o => o.Id == cat.Id);
                db.Entry(pr).CurrentValues.SetValues(cat);
            }
            else
            {
                return null;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return cat;
        }

        /// <see cref="IPersonRepository.GetUserPageCategory" />
        public IList<UserPageCategory> GetUserPageCategory()
        {
            return db.UserPageCategories.ToList();
        }

        /// <see cref="IPersonRepository.GetMediaPersonLinks" />
        public IList<Person> GetMediaPersonLinks(int id)
        {
            return db.MediaPersonLinks.Where(o => o.IdMedia == id).Include(o => o.Person).Select(o => o.Person).ToList();
        }

        /// <see cref="IPersonRepository.GetMediaPersonLinks" />
        public IList<Event> GetMediaEventLinks(int id)
        {
            return db.MediaEventLinks.Where(o => o.IdMedia == id).Include(o => o.Event).Select(o => o.Event).ToList();
        }

        /// <see cref="IPersonRepository.GetAntroPersonLinks" />
        public IList<Person> GetAntroPersonLinks(int id)
        {
            return db.AntroPersonLinks.Where(o => o.IdAntro == id).Include(o => o.Person).Select(o => o.Person).ToList();
        }

        /// <see cref="IPersonRepository.GetAntroEventLinks" />
        public IList<Event> GetAntroEventLinks(int id)
        {
            return db.AntroEventLinks.Where(o => o.IdAntro == id).Include(o => o.Event).Select(o => o.Event).ToList();
        }

        private PageBlock SavePageBlock(PageBlock pageBlock)
        {
            if (pageBlock.Id == 0)
            {
                db.Entry(pageBlock).State = EntityState.Added;
            }
            else if (pageBlock.Id > 0)
            {
                var pr = db.PageBlocks.FirstOrDefault(o => o.Id == pageBlock.Id);
                db.Entry(pr).CurrentValues.SetValues(pageBlock);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return pageBlock;
        }

        private PageSchema SavePage(PageSchema page)
        {
            if (page.Id == 0)
            {
                db.Entry(page).State = EntityState.Added;
            }
            else if (page.Id > 0)
            {
                var pr = db.PageSchemas.FirstOrDefault(o => o.Id == page.Id);
                db.Entry(pr).CurrentValues.SetValues(page);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return page;
        }

        private void SaveLog<T>(T from, T to, int personId, int userId, LogType type) where T : BaseEntity
        {
            var log = new PersonLog
            {
                Date = DateTime.Now,
                UserId = userId,
                IdPerson = personId,
                IdProperty = to.Id,
                Type = type,
                ChengeFrom = JsonConvert.SerializeObject(from),
                ChangeTo = JsonConvert.SerializeObject(to)
            };
            db.Entry(log).State = System.Data.Entity.EntityState.Added;
            //db.PersonLogs.Add(log);
            //db.SaveChanges();
        }
    }

}
