using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Events;
using Getticket.Web.API.Models.Persons;

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

        /// <see cref="ITagService.GeTags()"/>
        public IList<TagModel> GeTags()
        {
            var result = _tagRepository.GeTags();
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GePersonTags"/>
        public IList<TagModel> GePersonTags(int personId)
        {
            var result = _tagRepository.GePersonTags(personId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GeDescriptionTags"/>
        public IList<TagModel> GeDescriptionTags(int descriptionId)
        {
            var result = _tagRepository.GeDescriptionTags(descriptionId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GeAntroTags"/>
        public IList<TagModel> GeAntroTags(int tagAntroId)
        {
            var result = _tagRepository.GeAntroTags(tagAntroId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.GePersonMediaTags"/>
        public IList<TagModel> GePersonMediaTags(int mediaId)
        {
            var result = _tagRepository.GePersonMediaTags(mediaId);
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

        /// <see cref="ITagService.AddTagLinks(TagsEventMediaModel)"/>
        public bool AddTagLinks(TagsEventMediaModel model)
        {
            throw new NotImplementedException();
        }

        /// <see cref="ITagService.AddTagLinks(EventTagModel)"/>
        public bool AddTagLinks(EventTagModel model)
        {
            throw new NotImplementedException();
        }

        /// <see cref="ITagService.GeEventTags"/>
        public IList<TagModel> GeEventTags(int id)
        {
            throw new NotImplementedException();
        }
    }

}