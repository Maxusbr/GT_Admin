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
    /// Сервис для управления Event
    /// (обновление, регистрация, удаление и т.п.)
    /// </summary>
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="eventRepository"></param>
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        /// <see cref="IEventService.GetEvents" />
        public IEnumerable<EventModel> GetEvents()
        {
            return EventModelHelper.GetEventModels(_eventRepository.GetEvents());
        }
        
    }

}