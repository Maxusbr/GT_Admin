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
    /// Интерфейс сервиса для управления Event
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Возвращает список событий
        /// </summary>
        /// <returns></returns>
        IEnumerable<EventModel> GetEvents();


    }

}