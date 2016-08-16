using Getticket.Web.DAL.Entities;
using System;
using System.Collections.Generic;
using Getticket.Web.DAL.Infrastructure;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// Интерфейс для работы с сущностью <see cref="Tag" />
    /// </summary>
    public interface ITagRepository : IDisposable
    {
        /// <summary>
        /// Возвращает список <see cref="Tag"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GeTags();

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="Person"/> с Id = <paramref name="personId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GePersonTags(int personId);

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="PersonDescription"/> с Id = <paramref name="descriptionId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GeDescriptionTags(int descriptionId);

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="TagAntro"/> с Id = <paramref name="tagAntroId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GeAntroTags(int tagAntroId);

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="PersonMedia"/> с Id = <paramref name="mediaId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GePersonMediaTags(int mediaId);

        /// <summary>
        /// Добавляет  <see cref="Tag"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Tag AddTag(Tag model);

        /// <summary>
        /// Добавляет связь <see cref="Tag"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TagPersonDescriptionLink AddTagLink(TagPersonDescriptionLink model);

        /// <summary>
        /// Добавляет связь <see cref="Tag"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TagAntroLink AddTagLink(TagAntroLink model);
        

        /// <summary>
        /// Добавляет связь <see cref="Tag"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TagPersonLink AddTagLink(TagPersonLink model);

        /// <summary>
        /// Добавляет связь <see cref="Tag"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TagPersonMediaLink AddTagLink(TagPersonMediaLink model);

        /// <summary>
        /// Удалить все ссылки на <see cref="PersonMedia"/>
        /// </summary>
        /// <param name="idMedia"></param>
        void DeletePersonMediaTags(int idMedia);

        /// <summary>
        /// Удалить все ссылки на <see cref="Person"/>
        /// </summary>
        /// <param name="idPerson"></param>
        void DeletePersonTags(int idPerson);

        /// <summary>
        /// Удалить все ссылки на <see cref="PersonDescription"/>
        /// </summary>
        /// <param name="idDescription"></param>
        void DeletePersonDescriptionTags(int idDescription);

        /// <summary>
        /// Удалить все ссылки на <see cref="TagAntro"/>
        /// </summary>
        /// <param name="idPerson"></param>
        /// <param name="idAntroName"></param>
        /// <param name="isMoreThan"></param>
        /// <param name="value"></param>
        void DeletePersonAntroTags(int idPerson, int idAntroName, bool isMoreThan, int value);

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="EventMedia"/> с Id = <paramref name="mediaId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GeEventMediaTags(int mediaId);
    }
}
