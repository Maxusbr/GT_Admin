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
        public static Event GetConcertBase(EventModel model)
        {
            return model != null ? new Event
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                IdCategory = (int)(model.EventCategoryId ?? model.EventParentCategoryId),
                AgeLimit = model.AgeLimit,
                IsReallyEvent = true,
                DateStartSold = model.DateStartSold,
                DateStopSold = model.DateStopSold,
                ParentId = model.ParentId,
                IsPublished = model.IsPublished,
                HallId = model.HallId,
                ConcertPlaceId = model.ConcertPlaceId,
                IsOneProgramm = model.IsOneProgramm
            } : null;
        }

        public static Hall GetHall(HallModel model)
        {
            return model != null ? new Hall
            {
                Id = model.Id,
                Name = model.Name,
                PlaceId = model.PlaceId,
                ConcertPlace = GetConcertPlace(model.ConcertPlace)
            } : null;
        }

        public static ConcertPlace GetConcertPlace(ConcertPlaceModel model)
        {
            return model != null ? new ConcertPlace
            {
                Id = model.Id,
                Name = model.Name,
                PlaceId = model.PlaceId
            } : null;
        }

        public static ConcertTicket GetConcertTicket(ConcertTicketModel model)
        {
            return model != null ? new ConcertTicket
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
            } : null;
        }

        public static ConcertSchedule GetSchedule(ConcertScheduleModel model)
        {
            return model != null ? new ConcertSchedule
            {
                Id = model.Id,
                Duration = model.Duration,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                IdRange = model.IdRange,
                Period = model.Period,
                WeekDay = model.WeekDay
            } : null;
        }

        public static ConcertDateRange GetDateRange(ConcertDateRangeModel model)
        {
            return model != null ? new ConcertDateRange
            {
                Id = model.Id,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                IsRepeated = model.IsRepeated
            } : null;
        }

        public static IEnumerable<ConcertSchedule> GetSchedules(IEnumerable<ConcertScheduleModel> model)
        {
            return model.Select(GetSchedule);
        }

        public static ConcertProgramm GetProgramm(ConcertProgrammModel model)
        {
            return model != null ? new ConcertProgramm
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
            } : null;
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
            return model != null ? new ActorGroup
            {
                Id = model.Id,
                Name = model.Name
            } : null;
        }

        public static SeriesConcert GetSeries(int eventId, int seriesId)
        {
            return new SeriesConcert { EventId = eventId, SeriesId = seriesId };
        }

        public static SeriesName GetSeriesName(SeriesConcertModel model)
        {
            return new SeriesName { Id = model.Id, Name = model.Name };
        }

        public static EventModel GetConcertModel(Event model)
        {
            if (model == null) return null;
            return new EventModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                EventCategoryId = model.IdCategory,
                AgeLimit = model.AgeLimit,
                DateStartSold = model.DateStartSold,
                DateStopSold = model.DateStopSold,
                IsPublished = model.IsPublished,
                ParentId = model.ParentId,
                Parent = model.ParentId != null ? GetConcertModel(model.Parent) : null,
                HallId = model.HallId,
                ConcertPlaceId = model.ConcertPlaceId,
                Hall = GetHallModel(model.Hall),
                ConcertPlace = GetConcertPlaceModel(model.ConcertPlace),
                Tickets = GetTicketsModel(model.Tickets),
                Series = model.Series != null ? GetSeriesModels(model.Series) : null,
                IsOneProgramm = model.IsOneProgramm
            };
        }

        public static IList<SeriesConcertModel> GetSeriesModels(IList<SeriesConcert> series)
        {
            return series.Select(GetSeriesModel).ToList();
        }

        public static SeriesConcertModel GetSeriesModel(SeriesConcert model)
        {
            return model != null ? new SeriesConcertModel
            {
                Id = model.SeriesId,
                Name = model.Series.Name
            } : null;
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
            } : null;
        }

        public static ConcertPlaceModel GetConcertPlaceModel(ConcertPlace model)
        {
            return model != null ? new ConcertPlaceModel
            {
                Id = model.Id,
                Name = model.Name,
                PlaceId = model.PlaceId,
                CountryPlace = PersonModelHelper.GetCountryPlaceModel(model.CountryPlace),
                Halls = model.Halls?.Select(GetHallModel)
            } : null;
        }

        public static HallModel GetHallModel(Hall model)
        {
            return model != null ? new HallModel
            {
                Id = model.Id,
                Name = model.Name,
                PlaceId = model.PlaceId,
                //ConcertPlace = GetConcertPlaceModel(model.ConcertPlace)
            } : null;
        }

        public static ConcertDateRangeModel GetDateRangeModel(ConcertDateRange model)
        {
            return model != null ? new ConcertDateRangeModel
            {
                Id = model.Id,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                IsRepeated = model.IsRepeated,
                IdEvent = model.IdEvent,
                Schedules = GetScheduleModels(model.Schedules)
            } : null;
        }

        private static IEnumerable<ConcertScheduleModel> GetScheduleModels(IList<ConcertSchedule> models)
        {
            return models.Select(GetScheduleModel);
        }

        private static ConcertScheduleModel GetScheduleModel(ConcertSchedule model)
        {
            return model != null ? new ConcertScheduleModel
            {
                Id = model.Id,
                Duration = model.Duration,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                IdRange = model.IdRange,
                Period = model.Period,
                WeekDay = model.WeekDay
            } : null;
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
                Actors = GetActorModels(model.Actors),
                Group = GetActorGroupModelss(model.Actors)
            };
        }

        private static IEnumerable<ActorGroupModel> GetActorGroupModelss(IList<Actor> actors)
        {
            var grp = actors.GroupBy(o => o.Group).Select(o => GetGroupModel(o.Key));
            foreach (var el in grp)
                el.Actors = actors.Where(o => o.IdGroup == el.Id).Select(GetActorModel);
            return grp;
        }

        private static IEnumerable<ActorModel> GetActorModels(IList<Actor> models)
        {
            return models.Select(GetActorModel);
        }

        private static ActorModel GetActorModel(Actor model)
        {
            return model != null ? new ActorModel
            {
                Id = model.Id,
                IdPerson = model.IdPerson,
                IdGroup = model.IdGroup,
                Group = GetGroupModel(model.Group),
                Role = model.Role
            } : null;
        }

        private static ActorGroupModel GetGroupModel(ActorGroup model)
        {
            return model != null ? new ActorGroupModel
            {
                Id = model.Id,
                Name = model.Name
            } : null;
        }
    }
}