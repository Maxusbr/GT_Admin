using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Models
{
    public class CreateDescriptionModel
    {
        public int IdPerson { get; set; }
        public IList<TagsAntroModel> TagAntroList { get; set; }
        public TagsDescriptionModel TagDescription { get; set; }
    }

    public class TagsDescriptionModel
    {
        public PersonDescriptionModel Tizer { get; set; }
        public bool ExistDescription { get; set; }
        public string StaticDescription { get; set; }
        public TagModel[] Tags { get; set; }
    }

    public class TagsAntroModel
    {
        public int IdAntroName { get; set; }
        public int IdPerson { get; set; }
        public bool IsMoreThan { get; set; }
        public int Value { get; set; }
        public TagModel[] Tags { get; set; }
    }
}