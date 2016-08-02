using System.Collections.Generic;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Интерфейс сервиса для управления Tag
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// Возвращает список <see cref="TagModel"/>
        /// </summary>
        /// <returns></returns>
        IList<TagModel> GeTags();

        /// <summary>
        /// Возвращает список <see cref="TagModel"/> для <see cref="PersonModel"/> с Id = <paramref name="personId"/>
        /// </summary>
        /// <returns></returns>
        IList<TagModel> GeTags(int personId);

        /// <summary>
        /// Добавляет связь <see cref="TagModel"/> c <see cref="TagAntroModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddTagLinks(TagsAntroModel model);

        /// <summary>
        /// Добавляет связь <see cref="TagModel"/>c <see cref="PersonDescriptionModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddTagLinks(TagsDescriptionModel model);

        /// <summary>
        /// Добавляет связь <see cref="TagModel"/> с <see cref="PersonModel"/>
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        bool AddTagLinks(int personId, IEnumerable<TagModel> models);
    }

}