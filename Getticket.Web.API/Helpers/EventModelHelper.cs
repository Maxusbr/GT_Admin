using System;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Getticket.Web.API.Models.Persons;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class EventModelHelper
    {
        /// <summary>
        /// Get event models
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<EventModel> GetEventModels(IList<Event> list)
        {
            return list.Select(GetEventModel);
        }

        /// <summary>
        /// Оборачивает <paramref name="entity"/> в модель
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EventModel GetEventModel(Event entity)
        {
            var result = entity != null ? new EventModel
            {
                Id = entity.Id,
                Name = entity.Name,
                DateStartSold = entity.DateStartSold,
                DateStopSold = entity.DateStopSold,
                Description = entity.Description,
                EventDate = entity.EventDate,
                TicketReturn = entity.TicketReturn,
                EventType = entity.Category.IdParent != null ? entity.Category.ParentCategory.Name: entity.Category.Name
            } : new EventModel();

            return result;
        }
        
    }
}