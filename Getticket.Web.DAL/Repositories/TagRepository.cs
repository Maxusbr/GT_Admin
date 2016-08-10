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

        /// <see cref="ITagRepository.GeTags()" />
        public IList<Tag> GeTags()
        {
            var result = db.Tags.ToList();
            foreach (var tag in result)
            {
                if (db.TagPersonLinks.Any(o => o.IdTag == tag.Id))
                    tag.UsesType.Add("Персоны");
                if (db.TagDescriptionLinks.Any(o => o.IdTag == tag.Id))
                    tag.UsesType.Add("Подборки");
                if (db.TagAntroLinks.Any(o => o.IdTag == tag.Id))
                    tag.UsesType.Add("Факты");
                if (db.TagMediaLinks.Any(o => o.IdTag == tag.Id))
                    tag.UsesType.Add("Медиа");
            }
            return result;
        }

        /// <see cref="ITagRepository.GePersonTags(int)" />
        public IList<Tag> GePersonTags(int personId)
        {
            return db.TagPersonLinks.Where(o => o.IdPerson == personId).Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.GeDescriptionTags(int)" />
        public IList<Tag> GeDescriptionTags(int descriptionId)
        {
            return db.TagDescriptionLinks.Where(o => o.IdDescription == descriptionId).Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.GeAntroTags(int)" />
        public IList<Tag> GeAntroTags(int tagAntroId)
        {
            return db.TagAntroLinks.Where(o => o.IdTagAntro == tagAntroId).Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.GePersonMediaTags(int)" />
        public IList<Tag> GePersonMediaTags(int mediaId)
        {
            return db.TagMediaLinks.Where(o => o.IdMedia == mediaId).Include(o => o.Tag).Select(o => o.Tag).ToList();
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

        /// <see cref="ITagRepository.AddTagLink(TagPersonLink)" />
        public TagPersonLink AddTagLink(TagPersonLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            var tag = db.TagPersonLinks.FirstOrDefault(o => o.IdPerson == model.IdPerson && o.IdTag == model.IdTag);
            if(tag == null)
            {
                tag = new TagPersonLink {IdTag = model.IdTag, IdPerson = model.IdPerson};
                db.TagPersonLinks.Add(tag);
                db.SaveChanges();
            }
            return tag;
        }

        /// <see cref="ITagRepository.AddTagLink(TagMediaLink)" />
        public TagMediaLink AddTagLink(TagMediaLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            var tag = db.TagMediaLinks.FirstOrDefault(o => o.IdMedia == model.IdMedia && o.IdTag == model.IdTag);
            if (tag == null)
            {
                tag = new TagMediaLink { IdTag = model.IdTag, IdMedia = model.IdMedia };
                db.TagMediaLinks.Add(tag);
                db.SaveChanges();
            }
            return tag;
        }

        /// <see cref="ITagRepository.DeletePersonMediaTags" />
        public void DeletePersonMediaTags(int idMedia)
        {
            db.TagMediaLinks.RemoveRange(db.TagMediaLinks.Where(o => o.IdMedia == idMedia));
            db.SaveChanges();
        }

        /// <see cref="ITagRepository.DeletePersonTags" />
        public void DeletePersonTags(int idPerson)
        {
            db.TagPersonLinks.RemoveRange(db.TagPersonLinks.Where(o => o.IdPerson == idPerson));
            db.SaveChanges();
        }

        /// <see cref="ITagRepository.DeletePersonDescriptionTags" />
        public void DeletePersonDescriptionTags(int idDescription)
        {
            db.TagDescriptionLinks.RemoveRange(db.TagDescriptionLinks.Where(o => o.IdDescription == idDescription));
            db.SaveChanges();
        }

        /// <see cref="ITagRepository.DeletePersonAntroTags" />
        public void DeletePersonAntroTags(int idPerson, int idAntroName, bool isMoreThan, int value)
        {
            var antro = db.TagAntros.FirstOrDefault(o => o.IdPerson == idPerson && o.IdAntroName == idAntroName && o.Value == value && o.IsMoreThan == isMoreThan);
            if (antro == null) return;
            db.TagAntroLinks.RemoveRange(db.TagAntroLinks.Where(o => o.IdTagAntro == antro.Id));
            db.SaveChanges();
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
