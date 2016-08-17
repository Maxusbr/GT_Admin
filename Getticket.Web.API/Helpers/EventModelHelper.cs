using System;
using System.Collections;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Getticket.Web.API.Models.Events;
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
            return list?.Select(GetEventModel);
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
                EventCategoryId = entity.Category.IdParent != null ? entity.Category.Id: (int?) null,
                EventParentCategoryId = entity.Category.IdParent ?? entity.Category.Id,
                EventCategory = entity.Category.IdParent != null ? entity.Category.Name: "",
                EventParentCategory = entity.Category.IdParent != null ? entity.Category.ParentCategory.Name: entity.Category.Name,
                AgeLimit = entity.AgeLimit,
                Organizer = entity.Organizer?.Name
            } : new EventModel();

            return result;
        }

        public static IEnumerable<EventConnectionModel> GetConnectionModels(IList<EventConnection> getConnections)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<EventMediaModel> GetMediaModels(IList<EventMedia> getMedia)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<EventDescriptionModel> GetDescriptionModels(IList<EventDescription> getDescriptions)
        {
            throw new NotImplementedException();
        }

        public static Event GetEvent(EventModel model)
        {
            throw new NotImplementedException();
        }

        public static IList<EventConnectionTypeModel> GetConnectionTypeModels(IList<ConnectionType> result)
        {
            throw new NotImplementedException();
        }

        public static IList<MediaTypeModel> GetMediaTypeModels(IList<MediaType> result)
        {
            throw new NotImplementedException();
        }

        public static IList<EventDescriptionTypeModel> GetDescriptionTypeModels(IList<EventDescriptionType> result)
        {
            throw new NotImplementedException();
        }

        public static IList<EventCategoryModel> GetCategoryModels(IList<EventCategory> categories)
        {
            return categories.Select(o => new EventCategoryModel
            {
                Id = o.Id, Name = o.Name, Description = o.Description, IdParent = o.IdParent
            }).ToList();
        }
    }
}