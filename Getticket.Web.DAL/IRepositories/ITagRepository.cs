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
        IList<Tag> GetTags();

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="Person"/> с Id = <paramref name="personId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GetPersonTags(int personId);

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="PersonDescription"/> с Id = <paramref name="descriptionId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GetDescriptionTags(int descriptionId);

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="TagAntro"/> с Id = <paramref name="tagAntroId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GetAntroTags(int tagAntroId);

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="PersonMedia"/> с Id = <paramref name="mediaId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GetPersonMediaTags(int mediaId);

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
        IList<EventGenre> GetEventGenres();

        /// <summary>
        /// Возвращает список <see cref="EventGenre"/> для <see cref="Event"/> с Id = <paramref name="eventId"/>
        /// </summary>
        /// <returns></returns>
        IList<EventGenre> GetEventGenres(int eventId);

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="EventMedia"/> с Id = <paramref name="mediaId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GetEventMediaTags(int mediaId);

        /// <summary>
        /// Возвращает список <see cref="TagEvent"/>
        /// </summary>
        /// <returns></returns>
        IList<TagEvent> GetEventListTags();

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="Event"/> с Id = <paramref name="eventId"/>
        /// </summary>
        /// <returns></returns>
        IList<TagEvent> GetEventTags(int eventId);

        /// <summary>
        /// Возвращает список <see cref="Tag"/> для <see cref="EventDescription"/> с Id = <paramref name="descriptionId"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GetEventDescriptionTags(int descriptionId);

        /// <summary>
        /// Добавляет  <see cref="TagEvent"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TagEvent AddTag(TagEvent model);

        /// <summary>
        /// Добавляет связь <see cref="Tag"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TagEventDescriptionLink AddTagLink(TagEventDescriptionLink model);

        /// <summary>
        /// Добавляет связь <see cref="Tag"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TagEventMediaLink AddTagLink(TagEventMediaLink model);

        /// <summary>
        /// Добавляет связь <see cref="TagEvent"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TagEventLink AddTagLink(TagEventLink model);

        /// <summary>
        /// Удалить все ссылки на <see cref="Event"/>
        /// </summary>
        /// <param name="idEvent"></param>
        void DeleteEventTags(int idEvent);

        /// <summary>
        /// Удалить все ссылки на <see cref="EventDescription"/>
        /// </summary>
        /// <param name="idDescription"></param>
        void DeleteEventDescriptionTags(int idDescription);

        /// <summary>
        /// Удалить все ссылки на <see cref="EventMedia"/>
        /// </summary>
        /// <param name="idMedia"></param>
        void DeleteEventMediaTags(int idMedia);

        /// <summary>
        /// Удалить все жанры для <see cref="Event"/>
        /// </summary>
        /// <param name="idEvent"></param>
        void DeleteEventGenres(int idEvent);

        /// <summary>
        /// Добавляет жанр <see cref="EventGenre"/> к <see cref="Event"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        EventGenreLink AddGenreLink(EventGenreLink model);
    }
}
