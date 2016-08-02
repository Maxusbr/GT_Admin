using System;
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
    /// <see cref="ITagRepository"/>
    /// </summary>
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        /// <see cref="ITagRepository.GeTagLinkTypes" />
        public IList<TagLinkType> GeTagLinkTypes()
        {
            return db.TagLinkTypes.ToList();
        }

        /// <see cref="ITagRepository.GeTags" />
        public IList<Tag> GeTags()
        {
            var result = db.Tags.ToList();
            foreach (var tag in result)
            {
                tag.UsesType =
                    db.TagLinks.Where(o => o.IdTag == tag.Id)
                        .Include(o => o.Type)
                        .Select(o => o.Type.Name)
                        .Distinct()
                        .ToList();
            }
            return result;
        }

        /// <see cref="ITagRepository.AddTag" />
        public Tag AddTag(Tag model)
        {
            var tag = db.Tags.FirstOrDefault(o => o.Name.ToLower().Equals(model.Name.ToLower()));
            if (tag != null) return tag;
            tag = model;
            db.Tags.Add(tag);
            db.SaveChanges();
            return tag;
        }

        /// <see cref="ITagRepository.AddTagLink" />
        public TagLink AddTagLink(TagLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            db.TagLinks.Add(model);
            db.SaveChanges();
            return model;
        }
    }
}
