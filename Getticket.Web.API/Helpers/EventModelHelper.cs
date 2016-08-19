﻿using System;
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
            var list = getConnections.Select(GetConnectionModel);
            return list.ToList();
        }

        /// <summary>
        /// Оборачивает <paramref name="connection"/> в модель
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static EventConnectionModel GetConnectionModel(EventConnection connection)
        {
            return connection != null ? new EventConnectionModel
            {
                Id = connection.Id,
                id_ConnectionType = connection.id_ConnectionType,
                id_Event = connection.id_Event,
                id_Person = connection.id_Person,
                id_EventConnectTo = connection.id_EventConnectTo,
                Person = PersonModelHelper.GetPersonModel(connection.Person),
                Event = GetEventModel(connection.Event),
                Description = connection.Description,
                EventConnectionType = connection.ConnectionType?.Name
            } : new EventConnectionModel();
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
            return result.Select(o => new EventConnectionTypeModel { Id = o.Id, Name = o.Name }).ToList();
        }

        public static IList<MediaTypeModel> GetMediaTypeModels(IList<MediaType> result)
        {
            return result.Select(o => new MediaTypeModel { Id = o.Id, Name = o.Name }).ToList();
        }

        public static IList<EventDescriptionTypeModel> GetDescriptionTypeModels(IList<EventDescriptionType> result)
        {
            return result.Select(o => new EventDescriptionTypeModel { Id = o.Id, Name = o.Name }).ToList();
        }

        public static IList<EventFactModel> GetFactModels(IList<EventFact> facts)
        {
            var list = facts.Select(GetFactModel);
            return list.ToList();
        }


        private static EventFactModel GetFactModel(EventFact fact)
        {
            return fact != null ? new EventFactModel
            {
                Id = fact.Id,
                id_Event = fact.id_Event,
                id_FactType = fact.id_FactType,
                FactType = new EventFactTypeModel { Id = fact.FactType.Id, Name = fact.FactType.Name, Descript = fact.FactType.Descript ?? "" },
                FactText = fact.FactText,
                Status = fact.Status,
                Source = fact.Source
            } : new EventFactModel();
        }

        /// <summary>
        /// Get fact type models
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IList<EventFactTypeModel> GetFactTypeModels(IList<EventFactType> result)
        {
            return result.Select(o => new EventFactTypeModel { Id = o.Id, Name = o.Name, Descript = o.Descript ?? "" }).ToList();
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