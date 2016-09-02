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
                IsRepeated = model.IsRepeated,
                IdEvent = model.IdEvent
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
                MediaLink = model.MediaLink,
                //Actors = model.Actors != null ? GetActors(model.Actors).ToList(): null
            } : null;
        }

        public static IEnumerable<Actor> GetActors(IEnumerable<ActorModel> models)
        {
            return models.Select(GetActor);
        }

        public static Actor GetActor(ActorModel model)
        {
            return new Actor
            {
                Id = model.Id,
                IdPerson = model.IdPerson,
                IdGroup = model.IdGroup,
                //Group = GetActorGroup(o.Group),
                Role = model.Role,
                Programms = model.Programms?.Select(GetProgramm).ToList()
            };
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

        public static ConcertDateRangeModel GetDateRangeModel(IList<ConcertDateRange> models)
        {
            if (!models.Any()) return null;
            var maxDayEnd = models.Max(o => o.DateEnd);
            var maxDayStart = models.Max(o => o.DateStart);
            var res = new ConcertDateRangeModel
            {
                DateStart = models.Min(o => o.DateStart),
                DateEnd = maxDayStart > maxDayEnd ? maxDayStart : maxDayEnd,
                IsRepeated = models.Any(o => o.IsRepeated)
            };
            var weeks = models.Where(o => o.IsRepeated && o.Schedules.Any(x => x.WeekDay != null)).ToList();
            if (weeks.Any())
            {
                res.WeekSchedules = GetWeekScheduleModels(weeks);
                res.PreviewWeek = GetPreviewWeek(weeks);
            }
            var range = models.Where(o => o.IsRepeated && o.Schedules.Any(x => x.WeekDay == null)).ToList();
            if (range.Any())
            {
                res.RangeSchedules = GetRangeScheduleModels(range);
                res.PreviewRange = GetPreviewRange(range);
            }
            var one = models.OrderByDescending(o => o.DateStart).FirstOrDefault(o => !o.IsRepeated);
            if (one != null)
                res.OneSchedule = GetScheduleModel(one.Schedules.FirstOrDefault(), one);
            return res;
        }

        private static IEnumerable<PreviewScheduleModel> GetPreviewWeek(IEnumerable<ConcertDateRange> range)
        {
            var schedules = range.SelectMany(item => item.Schedules, (item, el) => el);

            var list = schedules.OrderBy(o => o.WeekDay)
                    .GroupBy(o => o.TimeStart)
                    .Select(o => new
                    {
                        Time = o.Key,
                        WeekDay = string.Join(",", o.Select(x => GetWeekDay(x.WeekDay ?? 0))),
                        WeekDayArr = o.Select(x => GetWeekDay(x.WeekDay ?? 0))
                    }).ToList();
            var res = list.GroupBy(o => o.WeekDay).Select(o => new PreviewScheduleModel
            {
                Range = o.FirstOrDefault().WeekDayArr,
                Times = o.Select(x => $"{x.Time.Hours:00}:{x.Time.Minutes:00}")
            });
            return res.ToList();
        }
        public static IEnumerable<PreviewScheduleModel> GetPreviewWeek(IEnumerable<WeekScheduleModel> models)
        {
            var schedules = models.SelectMany(item => item.WeekDays, (item, el) => new ConcertSchedule
            {
             TimeStart = item.TimeStart, WeekDay = el
            });
            var list = schedules.OrderBy(o => o.WeekDay)
                    .GroupBy(o => o.TimeStart)
                    .Select(o => new
                    {
                        Time = o.Key,
                        WeekDay = string.Join(",", o.Select(x => GetWeekDay(x.WeekDay ?? 0))),
                        WeekDayArr = o.Select(x => GetWeekDay(x.WeekDay ?? 0))
                    }).ToList();
            var res = list.GroupBy(o => o.WeekDay).Select(o => new PreviewScheduleModel
            {
                Range = o.FirstOrDefault().WeekDayArr,
                Times = o.Select(x => $"{x.Time.Hours:00}:{x.Time.Minutes:00}")
            });
            return res.ToList();
        }
        public static IEnumerable<PreviewScheduleModel> GetPreviewRange(IEnumerable<RangeScheduleModel> models)
        {
            var schedules = models.SelectMany(item => item.Schedules, (item, el) => new ConcertScheduleModel
            {
                DateStart = item.DateStart,
                DateEnd = item.DateEnd,
                TimeStart = el.TimeStart,
                IsRepeated = el.IsRepeated
            });
            var res = schedules.GroupBy(o => new { ds = o.DateStart, de = o.DateEnd }).Select(o => new PreviewScheduleModel
            {
                Dates = o.Key.ds.ToString("dd.MM.yyyy") + (o.Key.de != null ? $"-{o.Key.de?.ToString("dd.MM.yyyy")}" : ""),
                Times = o.Select(x => $"{x.TimeStart.Hours:00}:{x.TimeStart.Minutes:00}")
            });
            return res.ToList();
        }
        public static IEnumerable<PreviewScheduleModel> GetPreviewRange(IEnumerable<ConcertDateRange> range)
        {
            var schedules = range.SelectMany(item => item.Schedules, (item, el) => GetScheduleModel(el, item));

            var res = schedules.GroupBy(o => new { ds = o.DateStart, de = o.DateEnd }).Select(o => new PreviewScheduleModel
            {
                Dates = o.Key.ds.ToString("dd.MM.yyyy") + (o.Key.de != null ? $"-{o.Key.de?.ToString("dd.MM.yyyy")}" : ""),
                Times = o.Select(x => $"{x.TimeStart.Hours:00}:{x.TimeStart.Minutes:00}")
            });

            //var list = schedules.GroupBy(o => new { ts = o.TimeStart, rep = o.IsRepeated }).Select(o => new
            //{
            //    Time = o.Key.ts,
            //    Days = !o.Key.rep ? string.Join(",", o.Select(x => x.DateStart.ToString("dd.MM.yyyy"))) :
            //                    string.Join(",", o.Select(x => $"{x.DateStart:dd.MM.yyyy}-{x.DateEnd:dd.MM.yyyy}")),
            //    DayArr = !o.Key.rep ? o.Select(x => x.DateStart.ToString("dd.MM.yyyy")) :
            //                    o.Select(x => $"{x.DateStart:dd.MM.yyyy}-{x.DateEnd:dd.MM.yyyy}")
            //}).ToList();
            //var res = list.GroupBy(o => o.Days).Select(o => new PreviewScheduleModel
            //{
            //    Range = o.FirstOrDefault().DayArr,
            //    Times = o.Select(x => $"{x.Time.Hours:00}:{x.Time.Minutes:00}")
            //});
            return res.ToList();
        }

        private static string GetWeekDay(int num)
        {
            switch (num)
            {
                case 0:
                    return "Вс";
                case 1:
                    return "Пн";
                case 2:
                    return "Вт";
                case 3:
                    return "Ср";
                case 4:
                    return "Чт";
                case 5:
                    return "Пт";
                case 6:
                    return "Сб";
                default:
                    return "";
            }
        }

        private static IEnumerable<WeekScheduleModel> GetWeekScheduleModels(IEnumerable<ConcertDateRange> range)
        {
            var models = range.SelectMany(item => item.Schedules, (item, el) => GetScheduleModel(el, item));

            return models.OrderBy(o => o.TimeStart).GroupBy(o => o.TimeStart)
                .Select(o => new WeekScheduleModel
                {
                    DateStart = o.Min(x => x.DateStart),
                    DateEnd = o.Max(x => x.DateEnd),
                    TimeStart = o.Key,
                    WeekDays = o.Select(x => x.WeekDay ?? 0)
                }).ToList();
        }

        private static IEnumerable<RangeScheduleModel> GetRangeScheduleModels(IEnumerable<ConcertDateRange> range)
        {
            var schedules = range.SelectMany(item => item.Schedules, (item, el) => GetScheduleModel(el, item));
            var list = schedules.GroupBy(o => new { ds = o.DateStart, de = o.DateEnd })
                .Select(o => new RangeScheduleModel { DateStart = o.Key.ds, DateEnd = o.Key.de, Schedules = o });

            return list.ToList(); //range.SelectMany(item => item.Schedules, (item, el) => GetScheduleModel(el, item)).ToList();

        }

        private static ConcertScheduleModel GetScheduleModel(ConcertSchedule model, ConcertDateRange range)
        {
            return model != null ? new ConcertScheduleModel
            {
                Id = model.Id,
                DateStart = range.DateStart,
                DateEnd = range.DateEnd,
                IsRepeated = range.IsRepeated,
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
            return model != null ? new ConcertProgrammModel
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
                AllDay = model.DateEnd != null
            } : null;
        }

        public static ActorProgrammModel GetActorProgrammModel(ConcertProgramm model)
        {
            var res = new ActorProgrammModel
            {
                Programm = GetProgrammModel(model),
                Actors = GetActorModels(model.Actors),
                Group = GetActorGroupModels(model.Actors)
            };
            return res;
        }

        private static IEnumerable<ActorGroupModel> GetActorGroupModels(IList<Actor> actors)
        {
            var grp = actors.GroupBy(o => o.Group).Select(o => o.Key).ToList();
            var list = new List<ActorGroupModel>();
            foreach (var el in grp)
            {
                var grpel = el == null ? new ActorGroupModel() : GetGroupModel(el);
                grpel.Actors = actors.Where(o => o.IdGroup == el?.Id).Select(GetActorModel);
                list.Add(grpel);
            }
            return list;
        }

        public static IEnumerable<ActorModel> GetActorModels(IList<Actor> models)
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
                Role = model.Role,
                Person = PersonModelHelper.GetPersonModel(model.Person),
                Programms = model.Programms.Select(GetProgrammModel)
            } : null;
        }

        public static ActorGroupModel GetGroupModel(ActorGroup model)
        {
            return model != null ? new ActorGroupModel
            {
                Id = model.Id,
                Name = model.Name
            } : null;
        }


        public static IEnumerable<ConcertScheduleModel> GetSchedules(IEnumerable<WeekScheduleModel> weekSchedules)
        {
            return weekSchedules.SelectMany(item => item.WeekDays, (item, el) => new ConcertScheduleModel
            {
                DateStart = item.DateStart,
                DateEnd = item.DateEnd,
                IsRepeated = true,
                TimeStart = item.TimeStart,
                Duration = item.Duration,
                TimeEnd = item.TimeEnd,
                WeekDay = el
            });
        }

        public static IEnumerable<ConcertScheduleModel> GetSchedules(IEnumerable<RangeScheduleModel> rangeSchedules)
        {
            return rangeSchedules.SelectMany(item => item.Schedules, (item, el) => new ConcertScheduleModel
            {
                DateStart = item.DateStart,
                DateEnd = item.DateEnd,
                IsRepeated = true,
                TimeStart = el.TimeStart,
                Duration = el.Duration,
                TimeEnd = el.TimeEnd
            });
        }
    }
}