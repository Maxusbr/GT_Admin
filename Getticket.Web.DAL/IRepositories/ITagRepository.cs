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
        /// Возвращает список <see cref="TagLinkType"/>
        /// </summary>
        /// <returns></returns>
        IList<TagLinkType> GeTagLinkTypes();

        /// <summary>
        /// Возвращает список <see cref="Tag"/>
        /// </summary>
        /// <returns></returns>
        IList<Tag> GeTags();

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
        TagLink AddTagLink(TagLink model);
    }
}
