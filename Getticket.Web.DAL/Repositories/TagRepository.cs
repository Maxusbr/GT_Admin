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

        /// <see cref="ITagRepository.GetTags" />
        public IList<Tag> GetTags()
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
                if (db.TagPersonMediaLinks.Any(o => o.IdTag == tag.Id))
                    tag.UsesType.Add("Медиа");
            }
            return result;
        }

        /// <see cref="ITagRepository.GetPersonTags" />
        public IList<Tag> GetPersonTags(int personId)
        {
            return db.TagPersonLinks.Where(o => o.IdPerson == personId).Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.GetDescriptionTags" />
        public IList<Tag> GetDescriptionTags(int descriptionId)
        {
            return db.TagDescriptionLinks.Where(o => o.IdDescription == descriptionId).Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.GetAntroTags" />
        public IList<Tag> GetAntroTags(int tagAntroId)
        {
            return db.TagAntroLinks.Where(o => o.IdTagAntro == tagAntroId).Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.GetPersonMediaTags" />
        public IList<Tag> GetPersonMediaTags(int mediaId)
        {
            return db.TagPersonMediaLinks.Where(o => o.IdMedia == mediaId).Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.AddTag(Tag)" />
        public Tag AddTag(Tag model)
        {
            var tag = db.Tags.FirstOrDefault(o => o.Name.ToLower().Equals(model.Name.ToLower()));
            if (tag != null) return tag;
            tag = model;
            db.Tags.Add(tag);
            db.SaveChanges();
            return tag;
        }

        /// <see cref="ITagRepository.AddTagLink(TagPersonDescriptionLink)" />
        public TagPersonDescriptionLink AddTagLink(TagPersonDescriptionLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            var tag = db.TagDescriptionLinks.FirstOrDefault(o => o.IdDescription == model.IdDescription && o.IdTag == model.IdTag);
            if (tag == null)
            {
                tag = new TagPersonDescriptionLink { IdTag = model.IdTag, IdDescription = model.IdDescription};
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

        /// <see cref="ITagRepository.AddTagLink(TagPersonMediaLink)" />
        public TagPersonMediaLink AddTagLink(TagPersonMediaLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            var tag = db.TagPersonMediaLinks.FirstOrDefault(o => o.IdMedia == model.IdMedia && o.IdTag == model.IdTag);
            if (tag == null)
            {
                tag = new TagPersonMediaLink { IdTag = model.IdTag, IdMedia = model.IdMedia };
                db.TagPersonMediaLinks.Add(tag);
                db.SaveChanges();
            }
            return tag;
        }

        /// <see cref="ITagRepository.DeletePersonMediaTags" />
        public void DeletePersonMediaTags(int idMedia)
        {
            db.TagPersonMediaLinks.RemoveRange(db.TagPersonMediaLinks.Where(o => o.IdMedia == idMedia));
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

        /// <see cref="ITagRepository.GetEventGenres()" />
        public IList<EventGenre> GetEventGenres()
        {
            return db.EventGenres.ToList();
        }

        /// <see cref="ITagRepository.GetEventGenres(int)" />
        public IList<EventGenre> GetEventGenres(int eventId)
        {
            return db.EventGenreLinks.Where(o => o.IdEvent == eventId)
                .Include(o => o.Genre).Select(o => o.Genre).ToList();
        }

        /// <see cref="ITagRepository.GetEventMediaTags" />
        public IList<Tag> GetEventMediaTags(int mediaId)
        {
            return db.TagEventMediaLinks.Where(o => o.IdMedia == mediaId)
                .Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.GetEventListTags" />
        public IList<TagEvent> GetEventListTags()
        {
            return db.EventCategoryTags.ToList();
        }

        /// <see cref="ITagRepository.GetEventTags" />
        public IList<TagEvent> GetEventTags(int eventId)
        {
            return db.TagEventLinks.Where(o => o.IdEvent == eventId)
                .Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.GetEventDescriptionTags" />
        public IList<Tag> GetEventDescriptionTags(int descriptionId)
        {
            return db.TagEventDescriptionLinks.Where(o => o.IdDescription == descriptionId)
                .Include(o => o.Tag).Select(o => o.Tag).ToList();
        }

        /// <see cref="ITagRepository.AddTag(TagEvent)" />
        public TagEvent AddTag(TagEvent model)
        {
            var tag = db.EventCategoryTags.FirstOrDefault(o => o.Name.ToLower().Equals(model.Name.ToLower()));
            if (tag != null) return tag;
            tag = model;
            db.EventCategoryTags.Add(tag);
            db.SaveChanges();
            return tag;
        }

        /// <see cref="ITagRepository.AddTagLink(TagEventDescriptionLink)" />
        public TagEventDescriptionLink AddTagLink(TagEventDescriptionLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            var tag = db.TagEventDescriptionLinks.FirstOrDefault(o => o.IdDescription == model.IdDescription && o.IdTag == model.IdTag);
            if (tag == null)
            {
                tag = new TagEventDescriptionLink { IdTag = model.IdTag, IdDescription = model.IdDescription };
                db.TagEventDescriptionLinks.Add(tag);
                db.SaveChanges();
            }
            return tag;
        }

        /// <see cref="ITagRepository.AddTagLink(TagEventMediaLink)" />
        public TagEventMediaLink AddTagLink(TagEventMediaLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            var tag = db.TagEventMediaLinks.FirstOrDefault(o => o.IdMedia == model.IdMedia && o.IdTag == model.IdTag);
            if (tag == null)
            {
                tag = new TagEventMediaLink { IdTag = model.IdTag, IdMedia = model.IdMedia };
                db.TagEventMediaLinks.Add(tag);
                db.SaveChanges();
            }
            return tag;
        }

        /// <see cref="ITagRepository.AddTagLink(TagEventLink)" />
        public TagEventLink AddTagLink(TagEventLink model)
        {
            if (model.IdTag == 0)
            {
                if (model.Tag == null) return null;
                model.IdTag = AddTag(model.Tag).Id;
            }
            var tag = db.TagEventLinks.FirstOrDefault(o => o.IdEvent == model.IdEvent && o.IdTag == model.IdTag);
            if (tag == null)
            {
                tag = new TagEventLink { IdTag = model.IdTag, IdEvent = model.IdEvent };
                db.TagEventLinks.Add(tag);
                db.SaveChanges();
            }
            return tag;
        }

        /// <see cref="ITagRepository.DeleteEventTags" />
        public void DeleteEventTags(int idEvent)
        {
            db.TagEventLinks.RemoveRange(db.TagEventLinks.Where(o => o.IdEvent == idEvent));
            db.SaveChanges();
        }

        /// <see cref="ITagRepository.DeleteEventDescriptionTags" />
        public void DeleteEventDescriptionTags(int idDescription)
        {
            db.TagEventDescriptionLinks.RemoveRange(db.TagEventDescriptionLinks.Where(o => o.IdDescription == idDescription));
            db.SaveChanges();
        }

        /// <see cref="ITagRepository.DeleteEventMediaTags" />
        public void DeleteEventMediaTags(int idMedia)
        {
            db.TagEventMediaLinks.RemoveRange(db.TagEventMediaLinks.Where(o => o.IdMedia == idMedia));
            db.SaveChanges();
        }

        /// <see cref="ITagRepository.DeleteEventGenres" />
        public void DeleteEventGenres(int idEvent)
        {
            db.EventGenreLinks.RemoveRange(db.EventGenreLinks.Where(o => o.IdEvent == idEvent));
            db.SaveChanges();
        }

        /// <see cref="ITagRepository.AddGenreLink" />
        public EventGenreLink AddGenreLink(EventGenreLink model)
        {
            if (model.IdGenre == 0)
            {
                if (model.Genre == null) return null;
                model.IdGenre = AddGenre(model.Genre).Id;
            }
            var gnr = db.EventGenreLinks.FirstOrDefault(o => o.IdEvent == model.IdEvent && o.IdGenre == model.IdGenre);
            if (gnr == null)
            {
                gnr = new EventGenreLink { IdGenre = model.IdGenre, IdEvent = model.IdEvent, IsMain = model.IsMain};
                db.EventGenreLinks.Add(gnr);
                db.SaveChanges();
            }
            return gnr;
        }

        private EventGenre AddGenre(EventGenre model)
        {
            var gnr = db.EventGenres.FirstOrDefault(o => o.Name.ToLower().Equals(model.Name.ToLower()));
            if (gnr != null) return gnr;
            gnr = model;
            db.EventGenres.Add(gnr);
            db.SaveChanges();
            return gnr;
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
