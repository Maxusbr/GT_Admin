﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Infrastructure;
using Getticket.Web.DAL.IRepositories;

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
                .Include(o => o.Sex)
                .Include(o => o.Place)
                .FirstOrDefault();
            return person;
        }

        /// <see cref="IPersonRepository.SavePerson" />
        public Person SavePerson(Person person)
        {
            return base.Save(person);
        }

        /// <see cref="IPersonRepository.FindAllPerson" />
        public IList<Person> FindAllPerson()
        {
            var query = db.Person.Where(o => true);
            return GetAll(query);
        }

        /// <see cref="IPersonRepository.FindPerson" />
        public IList<Person> FindPerson(PageInfo page, string alphabetically, int? sexId = null)
        {
            var orderby = !string.IsNullOrEmpty(alphabetically) && alphabetically.Equals("A-Z");
            Expression<Func<Person, bool>> where = x => true;
            if (sexId != null)
            {
                where = where.And(x => x.id_Sex == sexId);
            }
            return GetMany(where, x => orderby ? x.LastNameLatin: x.LastName, x => x.Sex, x => x.Place);
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
        public PersonAntro UpdatePersonAntro(PersonAntro property)
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

        /// <see cref="IPersonRepository.AddPersonAntros" />
        public bool AddPersonAntros(IList<PersonAntro> properties)
        {
            return properties.Select(UpdatePersonAntro).All(rec => rec != null);
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
        public IList<PersonConnectionType> GetConnectionTypes()
        {
            return db.PersonConnectionType.ToList();
        }

        /// <see cref="IPersonRepository.UpdateConnectionType" />
        public PersonConnectionType UpdateConnectionType(PersonConnectionType type)
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
            var item = db.PersonConnectionType.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonConnectionType.Remove(item);
            db.SaveChanges();
            return true;
        }

        /// <see cref="IPersonRepository.GetConnections" />
        public IList<PersonConnection> GetConnections(int id)
        {
            return db.PersonConnections.Where(o => o.id_Person == id)
                .Include(o => o.Event)
                .Include(o => o.PersonConnectionType)
                .Include(o => o.id_PersonConnectTo != null ? o.PersonConnectTo : null).ToList();
        }

        /// <see cref="IPersonRepository.AddConnections" />
        public bool AddConnections(IList<PersonConnection> connections)
        {
            return connections.All(el => SaveConnection(el) != null);
        }

        /// <see cref="IPersonRepository.SaveConnection" />
        public PersonConnection SaveConnection(PersonConnection connection)
        {
            if (connection.Id == 0)
            {
                db.Entry(connection).State = System.Data.Entity.EntityState.Added;
            }
            else if (connection.Id > 0)
            {
                db.Entry(connection).State = System.Data.Entity.EntityState.Modified;
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
            return db.PersonDescriptions.Where(o => o.id_Person == id)
                .Include(o => o.PersonDescriptionType).ToList();
        }

        /// <see cref="IPersonRepository.UpdateDescription" />
        public PersonDescription UpdateDescription(PersonDescription description)
        {
            if (description.Id == 0)
            {
                db.Entry(description).State = System.Data.Entity.EntityState.Added;
            }
            else if (description.Id > 0)
            {
                db.Entry(description).State = System.Data.Entity.EntityState.Modified;
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

        /// <see cref="IPersonRepository.GetMedia" />
        public IList<PersonMedia> GetMedia(int id)
        {
            return db.PersonMedia.Where(o => o.id_Person == id).Include(o => o.MediaType).ToList();
        }

        /// <see cref="IPersonRepository.UpdateMedia" />
        public PersonMedia UpdateMedia(PersonMedia media)
        {
            if (media.Id == 0)
            {
                db.Entry(media).State = System.Data.Entity.EntityState.Added;
            }
            else if (media.Id > 0)
            {
                db.Entry(media).State = System.Data.Entity.EntityState.Modified;
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

        /// <see cref="IPersonRepository.GetMediaTipes" />
        public IList<PersonMediaType> GetMediaTipes()
        {
            return db.PersonMediaType.ToList();
        }

        /// <see cref="IPersonRepository.UpdateMediaType" />
        public PersonMediaType UpdateMediaType(PersonMediaType type)
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
            var item = db.PersonMediaType.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.PersonMediaType.Remove(item);
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
        public bool UpdateSocialLinks(IList<PersonSocialLink> links)
        {
            return links.All(link => UpdateSocialLink(link) != null);
        }

        /// <see cref="IPersonRepository.UpdateSocialLink" />
        public PersonSocialLink UpdateSocialLink(PersonSocialLink link)
        {
            if (link.Id == 0)
            {
                db.Entry(link).State = System.Data.Entity.EntityState.Added;
            }
            else if (link.Id > 0)
            {
                db.Entry(link).State = System.Data.Entity.EntityState.Modified;
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
        public IList<Country> GetCountries()
        {
            return db.Country.ToList();
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

        /// <see cref="IPersonRepository.GetCountryPlaces" />
        public IList<CountryPlace> GetCountryPlaces(int id)
        {
            return db.CountryPlaces.Where(o => o.id_Country == id)
                .Include(o => o.Country).ToList();
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

        /// <see cref="IPersonRepository.GetSexes" />
        public IList<Sex> GetSexes()
        {
            return db.Sex.ToList();
        }

        /// <see cref="IPersonRepository.SaveSex" />
        public Sex SaveSex(Sex sex)
        {
            if (sex.Id == 0)
            {
                db.Entry(sex).State = System.Data.Entity.EntityState.Added;
            }
            else if (sex.Id > 0)
            {
                db.Entry(sex).State = System.Data.Entity.EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return sex;
        }

        /// <see cref="IPersonRepository.DeleteSex" />
        public bool DeleteSex(int id)
        {
            if (id <= 0) return false;
            var item = db.Sex.FirstOrDefault(u => u.Id == id);
            if (item == null) return false;
            db.Sex.Remove(item);
            db.SaveChanges();
            return true;
        }
    }
}