using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Concerts;
using Getticket.Web.API.Models.Events;
using Getticket.Web.API.Models.Persons;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Concert Helper
    /// </summary>
    public static class ConcertModelHelper
    {
        public static Event GetConcertBase(EventModel concert)
        {
            return new Event
            {
                Id = concert.Id,
                Name = concert.Name,
                Description = concert.Description,
                IdCategory = concert.EventCategoryId ?? concert.EventParentCategoryId,
                AgeLimit = concert.AgeLimit,
                IsReallyEvent = true,
                DateStartSold = concert.DateStartSold,
                DateStopSold = concert.DateStopSold,
                ParentId = concert.ParentId,
                IsPublished = concert.IsPublished
            };
        }

        public static Hall GetHall(HallModel model)
        {
            return new Hall
            {
                Id = model.Id,
                Name = model.Name,
                PlaceId = model.Id,
                ConcertPlace = GetConcertPlace(model.ConcertPlace)
            };
        }

        public static ConcertPlace GetConcertPlace(ConcertPlaceModel model)
        {
            return new ConcertPlace
            {
                Id = model.Id,
                Name = model.Name,
                PlaceId = model.PlaceId
            };
        }

        public static ConcertTicket GetConcertTicket(ConcertTicketModel model, Event _event)
        {
            return new ConcertTicket
            {
                Id = model.Id,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Duration = model.Duration,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                OrganizerLink = model.OrganizerLink,
                ShowFormWhileEmpty = model.ShowFormWhileEmpty,
                ShowFormWhileEndTime = model.ShowFormWhileEndTime,
                Event = _event
            };
        }

        public static ConcertSchedule GetSchedule(ConcertScheduleModel model)
        {
            return new ConcertSchedule
            {
                Id = model.Id,
                Duration = model.Duration,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                IdRange = model.IdRange,
                Period = model.Period,
                WeekDay = model.WeekDay
            };
        }

        public static ConcertDateRange GetDateRange(ConcertDateRangeModel model)
        {
            return new ConcertDateRange
            {
                Id = model.Id,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                IsRepeated = model.IsRepeated
            };
        }

        public static IEnumerable<ConcertSchedule> GetSchedules(IEnumerable<ConcertScheduleModel> model)
        {
            return model.Select(GetSchedule);
        }

        public static ConcertProgramm GetProgramm(ConcertProgrammModel model)
        {
            return new ConcertProgramm
            {
                Id = model.Id,
                Name = model.Name,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Duration = model.Duration,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                Description = model.Description,
                IdEvent = model.IdEvent,
                MediaLink = model.MediaLink
            };
        }

        public static IEnumerable<Actor> GetActors(IEnumerable<ActorModel> models)
        {
            return models.Select(o => new Actor
            {
                Id = o.Id,
                IdPerson = o.IdPerson,
                IdGroup = o.IdGroup,
                //Group = GetActorGroup(o.Group),
                Role = o.Role
            });
        }

        public static ActorGroup GetActorGroup(ActorGroupModel model)
        {
            return new ActorGroup
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static SeriesConcert GetSeries(int eventId, int seriesId)
        {
            return new SeriesConcert {EventId = eventId, SeriesId = seriesId};
        }

        public static SeriesName GetSeriesName(SeriesNameModel model)
        {
            return new SeriesName {Id = model.Id, Name = model.Name};
        }

        public static EventModel GetConcertModel(Event concert)
        {
            if (concert == null) return null;
            return new EventModel
            {
                Id = concert.Id,
                Name = concert.Name,
                Description = concert.Description,
                EventCategoryId = concert.IdCategory,
                AgeLimit = concert.AgeLimit,
                DateStartSold = concert.DateStartSold,
                DateStopSold = concert.DateStopSold,
                IsPublished = concert.IsPublished,
                ParentId = concert.ParentId,
                Parent = concert.ParentId != null ? GetConcertModel(concert.Parent): null,
                Hall = GetHallModel(concert.Hall),
                ConcertPlace = GetConcertPlaceModel(concert.ConcertPlace),
                //Tickets = GetTicketsModel(concert.Tickets),
                Series = concert.Series != null ? GetSeriesModels(concert.Series): null
            };
        }

        public static IList<SeriesConcertModel> GetSeriesModels(IList<SeriesConcert> series)
        {
            return series.Select(GetSeriesModel).ToList();
        }

        public static SeriesConcertModel GetSeriesModel(SeriesConcert model)
        {
            return new SeriesConcertModel { EventId = model.EventId, SeriesId = model.SeriesId,
                Series = GetSeriesNameModel(model.Series) };
        }

        public static SeriesNameModel GetSeriesNameModel(SeriesName model)
        {
            return new SeriesNameModel { Id = model.Id, Name = model.Name };
        }

        private static ConcertTicketModel GetTicketsModel(ConcertTicket model)
        {
            return model != null ? new ConcertTicketModel
            {
                Id = model.Id,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Duration = model.Duration,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                OrganizerLink = model.OrganizerLink,
                ShowFormWhileEmpty = model.ShowFormWhileEmpty,
                ShowFormWhileEndTime = model.ShowFormWhileEndTime
            }: null;
        }

        public static ConcertPlaceModel GetConcertPlaceModel(ConcertPlace model)
        {
            return model != null ? new ConcertPlaceModel
            {
                Id = model.Id,
                Name = model.Name,
                PlaceId = model.PlaceId,
                CountryPlace = PersonModelHelper.GetCountryPlaceModel(model.CountryPlace)
            }: null;
        }

        public static HallModel GetHallModel(Hall model)
        {
            return model != null ? new HallModel
            {
                Id = model.Id,
                Name = model.Name,
                PlaceId = model.Id,
                ConcertPlace = GetConcertPlaceModel(model.ConcertPlace)
            }: null;
        }

        public static ConcertDateRangeModel GetDateRangeModel(ConcertDateRange model)
        {
            return new ConcertDateRangeModel
            {
                Id = model.Id, DateStart = model.DateStart, DateEnd = model.DateEnd, IsRepeated = model.IsRepeated,
                IdEvent = model.IdEvent, Schedules = GetScheduleModels(model.Schedules)
            };
        }

        private static IEnumerable<ConcertScheduleModel> GetScheduleModels(IList<ConcertSchedule> models)
        {
            return models.Select(GetScheduleModel);
        }

        private static ConcertScheduleModel GetScheduleModel(ConcertSchedule model)
        {
            return new ConcertScheduleModel
            {
                Id = model.Id,
                Duration = model.Duration,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                IdRange = model.IdRange,
                Period = model.Period,
                WeekDay = model.WeekDay
            };
        }

        public static ConcertProgrammModel GetProgrammModel(ConcertProgramm model)
        {
            return new ConcertProgrammModel
            {
                Id = model.Id,
                Name = model.Name,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Duration = model.Duration,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                Description = model.Description,
                IdEvent = model.IdEvent,
                MediaLink = model.MediaLink,
                Actors = GetActorModels(model.Actors)
            };
        }

        private static IEnumerable<ActorModel> GetActorModels(IList<Actor> models)
        {
            return models.Select(GetActorModel);
        }

        private static ActorModel GetActorModel(Actor model)
        {
            return new ActorModel
            {
                Id = model.Id,
                IdPerson = model.IdPerson,
                IdGroup = model.IdGroup,
                Group = GetGroupModel(model.Group),
                Role = model.Role
            };
        }

        private static ActorGroupModel GetGroupModel(ActorGroup model)
        {
            return new ActorGroupModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}