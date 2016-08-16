using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Tag Helper
    /// </summary>
    public static class TagModelHelper
    {

        public static IList<TagModel> GeTagModels(IList<Tag> list)
        {
            return list.Select(o => new TagModel { Id = o.Id, Name = o.Name, UsesType = o.UsesType }).ToList();
        }

        private static Tag GetTag(TagModel model)
        {
            return new Tag {Id = model.Id, Name = model.Name};
        }

        public static TagAntroLink GetTagLink(TagsAntroModel model, TagModel tag)
        {
            return new TagAntroLink { Tag = GetTag(tag), IdTag = tag.Id, Antro = GetAntro(model)};
        }

        private static TagAntro GetAntro(TagsAntroModel model)
        {
            return new TagAntro {IdAntroName = model.IdAntroName, IdPerson = model.IdPerson, Value = model.Value,
                IsMoreThan = model.IsMoreThan};
        }

        public static TagPersonDescriptionLink GetTagLink(int idDescription, TagModel tag)
        {
            return new TagPersonDescriptionLink {IdTag = tag.Id, Tag = GetTag(tag),IdDescription = idDescription };
        }

        public static IList<TagPersonLink> GetTagLink(int personId, IEnumerable<TagModel> tags)
        {
            return tags.Select(o => new TagPersonLink {IdPerson = personId, IdTag = o.Id, Tag = GetTag(o) }).ToList();
        }

        public static IList<TagPersonMediaLink> GetTagLink(TagsPersonMediaModel model)
        {
            return
                model.Tags.Select(o => new TagPersonMediaLink {IdMedia = model.IdMedia, IdTag = o.Id, Tag = GetTag(o)})
                    .ToList();
        }
    }
}