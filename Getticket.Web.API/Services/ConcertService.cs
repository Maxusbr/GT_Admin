using System;
using System.Collections.Generic;
using System.Linq;
using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models.Concerts;
using Getticket.Web.API.Models.Events;
using Getticket.Web.DAL.IRepositories;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Cервис для управления Concert
    /// </summary>
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository _concertRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="concertRepository"></param>
        public ConcertService(IConcertRepository concertRepository)
        {
            _concertRepository = concertRepository;
        }

        /// <see cref="IConcertService.GetConcerts()"/>
        public IEnumerable<EventModel> GetConcerts()
        {
            return _concertRepository.GetConcerts().Select(ConcertModelHelper.GetConcertModel);
        }

        /// <see cref="IConcertService.GetConcerts(int)"/>
        public IEnumerable<EventModel> GetConcerts(int eventId)
        {
            return _concertRepository.GetConcerts(eventId).Select(ConcertModelHelper.GetConcertModel);
        }

        /// <see cref="IConcertService.GetConcert"/>
        public EventModel GetConcert(int id)
        {
            var res = ConcertModelHelper.GetConcertModel(_concertRepository.GetConcert(id));
            //res.Tickets = new ConcertTicketModel { TimeStart = new TimeSpan(8, 15, 0), DateStart = new DateTime(2016, 9, 10)};
            return res;
        }

        /// <see cref="IConcertService.GetConcertSeriesName"/>
        public IEnumerable<SeriesNameModel> GetConcertSeriesName()
        {
            return _concertRepository.GetConcertSeriesName().Select(ConcertModelHelper.GetSeriesNameModel);
        }

        /// <see cref="IConcertService.GetConcertSchedules"/>
        public IEnumerable<ConcertDateRangeModel> GetConcertSchedules(int id)
        {
            return _concertRepository.GetConcertSchedules(id).Select(ConcertModelHelper.GetDateRangeModel);
        }

        /// <see cref="IConcertService.GetConcertProgramms"/>
        public IEnumerable<ActorProgrammModel> GetConcertProgramms(int id)
        {
            return _concertRepository.GetConcertProgramms(id).Select(ConcertModelHelper.GetActorProgrammModel);
        }

        /// <see cref="IConcertService.GetActorProgramms"/>
        public IEnumerable<ActorModel> GetActorProgramms(int id)
        {
            return ConcertModelHelper.GetActorModels(_concertRepository.GetActorProgramms(id));
        }

        /// <see cref="IConcertService.GetHalls"/>
        public IEnumerable<HallModel> GetHalls(int placeId)
        {
            return _concertRepository.GetHalls(placeId).Select(ConcertModelHelper.GetHallModel);
        }

        /// <see cref="IConcertService.GetConcertPlaces"/>
        public IEnumerable<ConcertPlaceModel> GetConcertPlaces(int placeId)
        {
            return _concertRepository.GetConcertPlace(placeId).Select(ConcertModelHelper.GetConcertPlaceModel);
        }

        /// <see cref="IConcertService.GetActorGroups"/>
        public IEnumerable<ActorGroupModel> GetActorGroups()
        {
            return _concertRepository.GetActorGroups().Select(ConcertModelHelper.GetGroupModel);
        }

        /// <see cref="IConcertService.SaveConcert"/>
        public EventModel SaveConcert(EventModel concert, int userId)
        {
            var entity = ConcertModelHelper.GetConcertBase(concert);
            if (concert.Id == 0)
                entity = _concertRepository.AddConcert(entity, userId);
            //if (concert.Hall != null)
            //    entity.Hall = _concertRepository.SaveHall(ConcertModelHelper.GetHall(concert.Hall));
            //if (concert.ConcertPlace != null)
            //    entity.ConcertPlace = _concertRepository.SaveConcertPlace(ConcertModelHelper.GetConcertPlace(concert.ConcertPlace));
            //if (concert.Tickets != null)
            //    entity.Tickets = _concertRepository.SaveConcertTicket(ConcertModelHelper.GetConcertTicket(concert.Tickets));
            var series =
                concert.Series.Select(o => _concertRepository.SaveSeriesName(ConcertModelHelper.GetSeriesName(o)));
            entity.Series = series.Select(o => ConcertModelHelper.GetSeries(entity.Id, o.Id)).ToList();

            entity = _concertRepository.UpdateConcert(entity, userId);
            return EventModelHelper.GetEventModel(entity);
        }

        /// <see cref="IConcertService.SaveSeriesName"/>
        public ServiceResponce SaveSeriesName(SeriesConcertModel model)
        {
            var res = _concertRepository.SaveSeriesName(ConcertModelHelper.GetSeriesName(model));
            var response = res != null ? ServiceResponce
                .FromSuccess()
                .Result("Event delete") :
                ServiceResponce
                .FromFailed()
                .Result("Error delete event");
            return response;
        }

        /// <see cref="IConcertService.SaveConcertSchedules"/>
        public bool SaveConcertSchedules(int eventId, IEnumerable<ConcertDateRangeModel> models)
        {
            var res =
                models.Select(o => _concertRepository.SaveConcertSchedule(eventId,
                    ConcertModelHelper.GetDateRange(o),
                    ConcertModelHelper.GetSchedules(o.Schedules)))
                    .Any(o => o != null);
            return res;
        }

        /// <see cref="IConcertService.SaveConcertProgramm(int, IEnumerable{ConcertProgrammModel})"/>
        public bool SaveConcertProgramm(int eventId, IEnumerable<ConcertProgrammModel> models)
        {
            var res =
                models.Select(o => _concertRepository.UpdateConcertProgramm(
                    ConcertModelHelper.GetProgramm(o)))
                    .Any(o => o != null);

            return res;
        }

        /// <see cref="IConcertService.SaveConcertProgramm(ConcertProgrammModel)"/>
        public ServiceResponce SaveConcertProgramm(ConcertProgrammModel model)
        {
            var succes = ServiceResponce.FromSuccess().Result("Concert programm save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save concert programm");
            var res = _concertRepository.AddConcertProgramm(
                ConcertModelHelper.GetProgramm(model));
            if (res != null)
                succes.Add("ProgrammId", res.Id);
            return res != null ? succes : error;
        }

        /// <see cref="IConcertService.UpdateConcertProgramm"/>
        public bool UpdateConcertProgramm(ConcertProgrammModel model)
        {
            return _concertRepository.UpdateConcertProgramm(ConcertModelHelper.GetProgramm(model)) != null;
        }

        /// <see cref="IConcertService.SaveActor"/>
        public ServiceResponce SaveActor(ActorModel model)
        {
            var succes = ServiceResponce.FromSuccess().Result("Concert tickets save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save concert tickets");
            var res = _concertRepository.AddActor(ConcertModelHelper.GetActor(model));
            if (res != null)
                succes.Add("ActorId", res.Id);
            return res != null ? succes : error;
        }

        /// <see cref="IConcertService.UpdateActor"/>
        public bool UpdateActor(ActorModel model)
        {
            return _concertRepository.UpdateActor(ConcertModelHelper.GetActor(model)) != null;
        }

        /// <see cref="IConcertService.SaveGroup"/>
        public ServiceResponce SaveGroup(ActorGroupModel model)
        {
            var res = _concertRepository.SaveGroup(ConcertModelHelper.GetActorGroup(model));
            var response = res != null ? ServiceResponce
                .FromSuccess()
                .Result("Event delete") :
                ServiceResponce
                .FromFailed()
                .Result("Error delete event");
            if (res != null)
                response.Add("GroupId", res.Id);
            return response;
        }

        /// <see cref="IConcertService.SaveConcertPlace"/>
        public ConcertPlaceModel SaveConcertPlace(ConcertPlaceModel model)
        {
            return ConcertModelHelper.GetConcertPlaceModel(_concertRepository.SaveConcertPlace(ConcertModelHelper.GetConcertPlace(model)));
        }

        /// <param name="id"></param>
        /// <see cref="IConcertService.GetConcertExist"/>
        public ConcertExistModel GetConcertExist(int id)
        {
            return new ConcertExistModel
            {
                ExistProgramm = _concertRepository.ExistProgramm(id),
                ExistCalendar = _concertRepository.ExistCalendar(id)
            };
        }


        /// <see cref="IConcertService.SaveHall"/>
        public HallModel SaveHall(HallModel model)
        {
            return ConcertModelHelper.GetHallModel(_concertRepository.SaveHall(ConcertModelHelper.GetHall(model)));
        }

        /// <see cref="IConcertService.SaveConcertTicket"/>
        public ServiceResponce SaveConcertTicket(ConcertTicketModel model)
        {
            var succes = ServiceResponce.FromSuccess().Result("Concert tickets save complete");
            var error = ServiceResponce.FromFailed().Result($"Error save concert tickets");
            var res = _concertRepository.SaveConcertTicket(ConcertModelHelper.GetConcertTicket(model));
            if (res != null)
                succes.Add("TicketsId", res.Id);
            return res != null ? succes : error;
        }

    }


}