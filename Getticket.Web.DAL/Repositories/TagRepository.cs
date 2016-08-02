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

        /// <see cref="ITagRepository.GeTags" />
        public IList<Tag> GeTags()
        {
            var result = db.Tags.ToList();
            foreach (var tag in result)
            {
                if (db.TagDescriptionLinks.Any(o => o.IdTag == tag.Id))
                    tag.UsesType.Add("Персоны");
                if (db.TagAntroLinks.Any(o => o.IdTag == tag.Id))
                    tag.UsesType.Add("Факты");
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

        /// <see cref="ITagRepository.AddTagLink(TagDescriptionLink)" />
        public TagDescriptionLink AddTagLink(TagDescriptionLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            db.TagDescriptionLinks.Add(new TagDescriptionLink {IdTag = model.IdTag, IdDescription = model.IdDescription});
            db.SaveChanges();
            return model;
        }

        /// <see cref="ITagRepository.AddTagLink(TagAntroLink)" />
        public TagAntroLink AddTagLink(TagAntroLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            if (model.IdTagAntro == 0)
            {
                if (model.Antro == null) return null;
                model.IdTagAntro = AddTagAntro(model.Antro).Id;
            }
            db.TagAntroLinks.Add(new TagAntroLink {IdTag = model.IdTag, IdTagAntro = model.IdTagAntro});
            db.SaveChanges();
            return model;
        }

        private TagAntro AddTagAntro(TagAntro model)
        {
            var antro = db.TagAntros.FirstOrDefault(o => o.IdPerson == model.IdPerson && o.IdAntroName == model.IdAntroName && o.Value == model.Value && o.IsMoreThan == model.IsMoreThan);
            if (antro != null) return antro;
            antro = model;
            db.TagAntros.Add(antro);
            db.SaveChanges();
            return antro;
        }
    }
}
