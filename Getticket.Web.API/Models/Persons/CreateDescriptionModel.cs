using System.Collections.Generic;

namespace Getticket.Web.API.Models.Persons
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

    public class TagsPersonMediaModel
    {
        public int IdMedia { get; set; }
        public IEnumerable<TagModel> Tags { get; set; }
    }

    public class TagsTizerModel
    {
        public int IdTizer { get; set; }
        public IList<TagModel> Tags { get; set; }
    }
}