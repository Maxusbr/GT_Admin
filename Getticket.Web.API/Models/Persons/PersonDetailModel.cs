using System;
using System.Collections.Generic;


namespace Getticket.Web.API.Models.Persons
{
    /// <summary>
    /// Person
    /// </summary>
    public class PersonDetailModel: PersonModel
    {
        public IList<PersonConnectionModel> Connection { get; set; }
        public IList<PersonAntroModel> Antros { get; set; }
        public IList<PersonDescriptionModel> Descriptions { get; set; }
        public IList<PersonMediaModel> MidiaList { get; set; }
        public IList<PersonSocialLinkModel> SocialLinks { get; set; }
        public IList<PersonChangeLogModel> LogChanges { get; set; }
    }
}
