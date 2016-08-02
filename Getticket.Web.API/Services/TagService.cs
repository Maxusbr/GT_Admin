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

        /// <see cref="ITagService.GeTagLinkTypes"/>
        public IList<TagLinkTypeModel> GeTagLinkTypes()
        {
            var result = _tagRepository.GeTagLinkTypes();
            return TagModelHelper.GeTagLinkTypeModels(result);
        }

        /// <see cref="ITagService.GeTags"/>
        public IList<TagModel> GeTags()
        {
            var result = _tagRepository.GeTags();
            return TagModelHelper.GeTagModels(result);
        }

        /// <see cref="ITagService.AddTagLinks"/>
        public ServiceResponce AddTagLinks(IList<TagLinkModel> list)
        {
            var response = list.Select(link =>
                _tagRepository.AddTagLink(TagModelHelper.GetTagLink(link)))
                    .All(taglink => taglink != null) ? ServiceResponce
                        .FromSuccess()
                        .Result("Tags add complete") :
                        ServiceResponce
                        .FromFailed()
                        .Result("Error add tags");
            return response;
        }
    }

}