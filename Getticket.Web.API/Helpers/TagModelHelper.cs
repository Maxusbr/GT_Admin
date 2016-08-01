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
        public static IList<TagLinkTypeModel> GeTagLinkTypeModels(IList<TagLinkType> list)
        {
            return list.Select(o => new TagLinkTypeModel { Id = o.Id, Name = o.Name }).ToList();
        }

        public static IList<TagModel> GeTagModels(IList<Tag> list)
        {
            return list.Select(o => new TagModel { Id = o.Id, Name = o.Name, UsesType = o.UsesType }).ToList();
        }

        public static TagLink GetTagLink(TagLinkModel model)
        {
            return new TagLink
            {
                Id = model.Id,
                Tag = GetTag(model.Tag),
                IdTag = model.IdTag,
                IdLinkType = model.IdLinkType,
                FeatureName = model.FeatureName,
                FeatureType = model.FeatureType,
                ConditionFeatureValue = model.ConditionFeatureValue,
                FeatureValue = model.FeatureValue
            };
        }

        private static Tag GetTag(TagModel model)
        {
            return new Tag {Id = model.Id, Name = model.Name};
        }
    }
}