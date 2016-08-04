using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Infrastructure;

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

        /// <see cref="ITagService.GeTags(int)"/>
        public IList<TagModel> GeTags(int personId)
        {
            var result = _tagRepository.GeTags(personId);
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.AddTagLinks(TagsAntroModel)"/>
        public bool AddTagLinks(TagsAntroModel model)
        {
            if (model.Tags.Length < 1) return true;
            var list = model.Tags.Select(o => TagModelHelper.GetTagLink(model, o));
            var response = list.Select(link => _tagRepository.AddTagLink(link))
                    .All(taglink => taglink != null);
            return response;
        }

        /// <see cref="ITagService.AddTagLinks(TagsDescriptionModel)"/>
        public bool AddTagLinks(TagsDescriptionModel model)
        {
            if (model.Tags.Length < 1) return true;
            var list = model.Tags.Select(o => TagModelHelper.GetTagLink(model.Tizer.Id, o));
            var response = list.Select(link => _tagRepository.AddTagLink(link))
                    .All(taglink => taglink != null);
            return response;
        }

        /// <see cref="ITagService.AddTagLinks(int,IEnumerable{TagModel})"/>
        public bool AddTagLinks(int personId, IEnumerable<TagModel> models)
        {
            if (!models.Any()) return true;
            var list = TagModelHelper.GetTagLink(personId, models);
            var response = list.Select(link => _tagRepository.AddTagLink(link))
                    .All(taglink => taglink != null);
            return response;
        }
    }

}