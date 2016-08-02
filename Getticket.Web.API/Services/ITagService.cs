﻿using Getticket.Web.DAL.IRepositories;
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
        /// Добавляет связь <see cref="TagModel"/> c <see cref="TagAntro"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddTagLinks(TagsAntroModel model);

        /// <summary>
        /// Добавляет связь <see cref="TagModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddTagLinks(TagsDescriptionModel model);
    }

}