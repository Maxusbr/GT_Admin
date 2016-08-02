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
        IList<Tag> GeTags(int personId);

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
        TagDescriptionLink AddTagLink(TagDescriptionLink model);

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
        TagLink AddTagLink(TagLink model);
    }
}
