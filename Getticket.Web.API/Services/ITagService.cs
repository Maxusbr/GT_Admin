using System.Collections.Generic;
using Getticket.Web.API.Controllers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Events;
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
        IList<TagModel> GePersonTags(int personId);

        /// <summary>
        /// Возвращает список <see cref="TagModel"/> для <see cref="PersonDescriptionModel"/> с Id = <paramref name="descriptionId"/>
        /// </summary>
        /// <returns></returns>
        IList<TagModel> GeDescriptionTags(int descriptionId);

        /// <summary>
        /// Возвращает список <see cref="TagModel"/> для <see cref="PersonAntroModel"/> с Id = <paramref name="tagAntroId"/>
        /// </summary>
        /// <returns></returns>
        IList<TagModel> GeAntroTags(int tagAntroId);

        /// <summary>
        /// Возвращает список <see cref="TagModel"/> для <see cref="PersonMediaModel"/> с Id = <paramref name="mediaId"/>
        /// </summary>
        /// <returns></returns>
        IList<TagModel> GePersonMediaTags(int mediaId);

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
        bool AddTagLinks(TagsTizerModel model);

        /// <summary>
        /// Добавляет связь <see cref="TagModel"/> с <see cref="PersonModel"/>
        /// </summary>
        /// <returns></returns>
        bool AddTagLinks(PersonTagModel model);

        /// <summary>
        /// Добавляет связь <see cref="TagModel"/> с <see cref="PersonMediaModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddTagLinks(TagsPersonMediaModel model);

        /// <summary>
        /// Добавляет связь <see cref="TagModel"/> с <see cref="EventMediaModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddTagLinks(TagsEventMediaModel model);

        /// <summary>
        /// Добавляет связь <see cref="TagModel"/> с <see cref="EventModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddTagLinks(EventTagModel model);

        /// <summary>
        /// Возвращает список <see cref="TagModel"/> для <see cref="EventModel"/> с Id = <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        IList<TagModel> GeEventTags(int id);
    }

    
}