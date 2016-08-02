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
                if (db.TagLinks.Any(o => o.IdTag == tag.Id))
                    tag.UsesType.Add("Персоны");
                if (db.TagDescriptionLinks.Any(o => o.IdTag == tag.Id))
                    tag.UsesType.Add("Подборки");
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
            var tag = db.TagDescriptionLinks.FirstOrDefault(o => o.IdDescription == model.IdDescription && o.IdTag == model.IdTag);
            if (tag == null)
            {
                tag = new TagDescriptionLink { IdTag = model.IdTag, IdDescription = model.IdDescription};
                db.TagDescriptionLinks.Add(tag);
                db.SaveChanges();
            }
            return tag;
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
            var tag = db.TagAntroLinks.FirstOrDefault(o => o.IdTagAntro == model.IdTagAntro&& o.IdTag == model.IdTag);
            if (tag == null)
            {
                tag = new TagAntroLink { IdTag = model.IdTag, IdTagAntro = model.IdTagAntro };
                db.TagAntroLinks.Add(tag);
                db.SaveChanges();
            }
            return tag;
        }

        /// <see cref="ITagRepository.AddTagLink(TagLink)" />
        public TagLink AddTagLink(TagLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            var tag = db.TagLinks.FirstOrDefault(o => o.IdPerson == model.IdPerson && o.IdTag == model.IdTag);
            if(tag == null)
            {
                tag = new TagLink {IdTag = model.IdTag, IdPerson = model.IdPerson};
                db.TagLinks.Add(tag);
                db.SaveChanges();
            }
            return tag;
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
