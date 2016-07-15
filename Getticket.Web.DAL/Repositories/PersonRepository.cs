using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Getticket.Web.DAL.Entities;
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
            if (id <= 0)
            {
                return null;
            }
            var query = db.Person.Where(u => u.Id == id);
            return GetOne(query);
        }

        /// <see cref="IPersonRepository.SavePerson" />
        public Person SavePerson(Person person)
        {
            return base.Save(person);
        }

        /// <see cref="IPersonRepository.FindAllPerson" />
        public IList<Person> FindAllPerson()
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeletePerson" />
        public bool DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetPersonAntros" />
        public IList<PersonAntro> GetPersonAntros(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetAntroNames" />
        public IList<PersonAntroName> GetAntroNames()
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateAntroName" />
        public PersonAntroName UpdateAntroName(PersonAntroName property)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeleteAntroName" />
        public bool DeleteAntroName(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdatePersonAntro" />
        public PersonAntro UpdatePersonAntro(PersonAntro property)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.AddPersonAntros" />
        public bool AddPersonAntros(IList<PersonAntro> properties)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeletePersonAntros" />
        public bool DeletePersonAntros(IList<PersonAntro> properties)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetChangeParams" />
        public IList<PersonChangeParam> GetChangeParams()
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateChangeParam" />
        public PersonChangeParam UpdateChangeParam(PersonChangeParam param)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeleteChangeParam" />
        public bool DeleteChangeParam(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetChangeLog" />
        public IList<PersonChangeLog> GetChangeLog(int? id = null)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.AddChangeLogs" />
        public bool AddChangeLogs(IList<PersonChangeLog> changes)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.AddChangeLog" />
        public bool AddChangeLog(PersonChangeLog change)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetConnectionTypes" />
        public IList<PersonConnectionType> GetConnectionTypes()
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateConnectionType" />
        public PersonConnectionType UpdateConnectionType(PersonConnectionType type)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeleteConnectionType" />
        public bool DeleteConnectionType(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetConnections" />
        public IList<PersonConnection> GetConnections(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.AddConnections" />
        public bool AddConnections(IList<PersonConnection> connections)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateConnection" />
        public PersonConnection UpdateConnection(PersonConnection connection)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeleteConnections" />
        public bool DeleteConnections(IList<PersonConnection> connections)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetDescriptionTypes" />
        public IList<PersonDescriptionType> GetDescriptionTypes()
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateDescriptionType" />
        public PersonDescriptionType UpdateDescriptionType(PersonDescriptionType type)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeleteDescriptionType" />
        public bool DeleteDescriptionType(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetDescriptions" />
        public IList<PersonDescription> GetDescriptions(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateDescription" />
        public PersonDescription UpdateDescription(PersonDescription description)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeleteDescription" />
        public bool DeleteDescription(PersonDescription description)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetMedia" />
        public IList<PersonMedia> GetMedia(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateMedia" />
        public PersonMedia UpdateMedia(PersonMedia media)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeleteMedia" />
        public bool DeleteMedia(PersonMedia media)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetLinkTypes" />
        public IList<PersonSocialLinkType> GetLinkTypes()
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateLinkType" />
        public PersonSocialLinkType UpdateLinkType(PersonSocialLinkType type)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeleteLinkType" />
        public bool DeleteLinkType(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.GetSocialLinks" />
        public IList<PersonSocialLink> GetSocialLinks(int id)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateSocialLinks" />
        public bool UpdateSocialLinks(IList<PersonSocialLink> links)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.UpdateSocialLink" />
        public PersonSocialLink UpdateSocialLink(PersonSocialLink link)
        {
            throw new NotImplementedException();
        }

        /// <see cref="IPersonRepository.DeleteSocialLinks" />
        public bool DeleteSocialLinks(PersonSocialLink links)
        {
            throw new NotImplementedException();
        }
    }
}
