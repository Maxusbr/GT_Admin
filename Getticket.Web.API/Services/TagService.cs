using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Events;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис для управления Tag
    /// (обновление, регистрация, удаление и т.п.)
    /// </summary>
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="tagRepository"></param>
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        /// <see cref="ITagService.GetTags"/>
        public IList<TagModel> GetTags()
        {
            var result = _tagRepository.GetTags();
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GetPersonTags"/>
        public IList<TagModel> GetPersonTags(int personId)
        {
            var result = _tagRepository.GetPersonTags(personId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GetDescriptionTags"/>
        public IList<TagModel> GetDescriptionTags(int descriptionId)
        {
            var result = _tagRepository.GetDescriptionTags(descriptionId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GetAntroTags"/>
        public IList<TagModel> GetAntroTags(int tagAntroId)
        {
            var result = _tagRepository.GetAntroTags(tagAntroId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GetPersonMediaTags"/>
        public IList<TagModel> GetPersonMediaTags(int mediaId)
        {
            var result = _tagRepository.GetPersonMediaTags(mediaId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.AddTagLinks(TagsAntroModel)"/>
        public bool AddTagLinks(TagsAntroModel model)
        {
            if (model.IdAntroName == 0) return true;
            _tagRepository.DeletePersonAntroTags(model.IdPerson, model.IdAntroName, model.IsMoreThan, model.Value);
            if (model.Tags.Length < 1) return true;
            var list = model.Tags.Select(o => TagModelHelper.GetTagLink(model, o));
            var response = list.Select(link => _tagRepository.AddTagLink(link))
                    .All(taglink => taglink != null);
            return response;
        }

        /// <see cref="ITagService.AddTagLinks(TagsTizerModel)"/>
        public bool AddTagLinks(TagsTizerModel model)
        {
            _tagRepository.DeletePersonDescriptionTags(model.IdTizer);
            if (model.Tags.Count < 1) return true;
            var list = model.Tags.Select(o => TagModelHelper.GetTagLink(model.IdTizer, o));
            var response = list.Select(link => _tagRepository.AddTagLink(link))
                    .All(taglink => taglink != null);
            return response;
        }

        /// <see cref="ITagService.AddTagLinks(PersonTagModel)"/>
        public bool AddTagLinks(PersonTagModel model)
        {
            _tagRepository.DeletePersonTags(model.personId);
            if (model.models == null || !model.models.Any()) return true;
            var list = TagModelHelper.GetTagLink(model.personId, model.models);
            var response = list.Select(link => _tagRepository.AddTagLink(link))
                    .All(taglink => taglink != null);
            return response;
        }

        /// <see cref="ITagService.AddTagLinks(TagsPersonMediaModel)"/>
        public bool AddTagLinks(TagsPersonMediaModel model)
        {
            _tagRepository.DeletePersonMediaTags(model.IdMedia);
            if (!model.Tags.Any()) return true;
            var list = TagModelHelper.GetTagLink(model);
            var response = list.Select(link => _tagRepository.AddTagLink(link))
                    .All(taglink => taglink != null);
            return response;
        }

        ///// <see cref="ITagService.AddTagLinks(TagsEventMediaModel)"/>
        //public bool AddTagLinks(TagsEventMediaModel model)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <see cref="ITagService.AddTagLinks(EventTagModel)"/>
        //public bool AddTagLinks(EventTagModel model)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <see cref="ITagService.GeEventTags"/>
        //public IList<TagModel> GeEventTags(int id)
        //{
        //    throw new NotImplementedException();
        //}

        /// <see cref="ITagService.GetEventGenres()"/>
        public IList<EventGenreModel> GetEventGenres()
        {
            return TagModelHelper.GeGenreModels(_tagRepository.GetEventGenres());
        }

        /// <see cref="ITagService.GetEventGenres(int)"/>
        public IList<EventGenreModel> GetEventGenres(int eventId)
        {
            return TagModelHelper.GeGenreModels(_tagRepository.GetEventGenres(eventId));
        }

        /// <see cref="ITagService.GetEventMediaTags"/>
        public IList<TagModel> GetEventMediaTags(int mediaId)
        {
            var result = _tagRepository.GetEventMediaTags(mediaId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GetEventListTags"/>
        public IList<TagEventModel> GetEventListTags()
        {
            var result = _tagRepository.GetEventListTags();
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GetEventTags"/>
        public IList<TagEventModel> GetEventTags(int eventId)
        {
            var result = _tagRepository.GetEventTags(eventId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GetEventDescriptionTags"/>
        public IList<TagModel> GetEventDescriptionTags(int descriptionId)
        {
            var result = _tagRepository.GetEventDescriptionTags(descriptionId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.AddTagLinks(TagEventDescriptionLinkModel)"/>
        public bool AddTagLinks(TagEventDescriptionLinkModel model)
        {
            _tagRepository.DeleteEventDescriptionTags(model.IdDescription);
            if (!model.Tags.Any()) return true;
            var response = model.Tags.Select(o => _tagRepository.AddTagLink(new TagEventDescriptionLink
            {
                IdDescription = model.IdDescription,
                IdTag = o.Id,
                Tag = new Tag { Id = o.Id, Name = o.Name }
            })).All(taglink => taglink != null);
            return response;
        }

        /// <see cref="ITagService.AddTagLinks(TagEventMediaLinkModel)"/>
        public bool AddTagLinks(TagEventMediaLinkModel model)
        {
            _tagRepository.DeleteEventMediaTags(model.IdMedia);
            if (!model.Tags.Any()) return true;
            var response = model.Tags.Select(o => _tagRepository.AddTagLink(new TagEventMediaLink
            {
                IdMedia = model.IdMedia,
                IdTag = o.Id,
                Tag = new Tag { Id = o.Id, Name = o.Name }
            })).All(taglink => taglink != null);
            return response;
        }

        /// <see cref="ITagService.AddTagLinks(TagEventLinkModel)"/>
        public bool AddTagLinks(TagEventLinkModel model)
        {
            _tagRepository.DeleteEventTags(model.IdEvent);
            if (!model.Tags.Any()) return true;
            var response = model.Tags.Select(o => _tagRepository.AddTagLink(new TagEventLink
            {
                IdEvent = model.IdEvent,
                IdTag = o.Id,
                Tag = new TagEvent { Id = o.Id, Name = o.Name }
            })).All(taglink => taglink != null);
            return response;
        }

        /// <see cref="ITagService.AddGenreLinks"/>
        public bool AddGenreLinks(EventGenreLinkModel model)
        {
            _tagRepository.DeleteEventGenres(model.IdEvent);
            if (!model.Genres.Any()) return true;
            var response = model.Genres.Select(o => _tagRepository.AddGenreLink(new EventGenreLink
            {
                IdEvent = model.IdEvent,
                IdGenre = o.Id,
                Genre = new EventGenre { Id = o.Id, Name = o.Name },
                IsMain = o.IsMain
            })).All(taglink => taglink != null);
            return response;
        }
    }

}