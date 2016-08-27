using System.Collections.Generic;
using Getticket.Web.API.Models.Concerts;
using Getticket.Web.API.Models.Events;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Интерфейс сервиса для управления Concert
    /// </summary>
    public interface IConcertService
    {
        /// <summary>
        /// Возвращает список концертов <see cref="EventModel"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<EventModel> GetConcerts();

        /// <summary>
        /// Возвращает список концертов <see cref="EventModel"/> для мероприятия с Id = <paramref name="eventId"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<EventModel> GetConcerts(int eventId);

        /// <summary>
        /// Находим концерт <see cref="EventModel"/> с Id = <paramref name="id" /> 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EventModel GetConcert(int id);

        /// <summary>
        /// Список концертных серий для концерта <see cref="EventModel"/> с Id = <paramref name="id" /> 
        /// </summary>
        /// <returns></returns>
        IEnumerable<SeriesNameModel> GetConcertSeries(int id);

        /// <summary>
        /// Список расписаний концерта <see cref="EventModel"/> с Id = <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<ConcertDateRangeModel> GetConcertSchedules(int id);

        /// <summary>
        /// Список программ концерта <see cref="EventModel"/> с Id = <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<ConcertProgrammModel> GetConcertProgramms(int id);

        /// <summary>
        /// Список площадок <see cref="HallModel"/>
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        IEnumerable<HallModel> GetHalls(int placeId);

        /// <summary>
        /// Список площадок <see cref="ConcertPlaceModel"/>
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        IEnumerable<ConcertPlaceModel> GetConcertPlaces(int placeId);

        /// <summary>
        /// Сохранить концерт
        /// </summary>
        /// <param name="concert"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        EventModel SaveConcert(EventModel concert, int userId);

        /// <summary>
        /// Сохранить/добавить площадку <see cref="HallModel"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveHall(HallModel model);

        /// <summary>
        /// Сохранить/добавить серию <see cref="SeriesNameModel"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveSeriesName(SeriesNameModel model);

        /// <summary>
        /// Сохранить/добавить расписания <see cref="ConcertScheduleModel"/> для концерта <see cref="EventModel"/> с Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        bool SaveConcertSchedules(int eventId, IEnumerable<ConcertDateRangeModel> models);

        /// <summary>
        /// Сохранить/добавить программы <see cref="ConcertProgrammModel"/> для концерта <see cref="EventModel"/> с Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        bool SaveConcertProgramm(int eventId, IEnumerable<ConcertProgrammModel> models);

        /// <summary>
        /// Сохранить/добавить билеты <see cref="ConcertTicketModel"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveConcertTicket(ConcertTicketModel model);

        /// <summary>
        /// Сохранить/добавить актера <see cref="ActorModel"/> 
        /// </summary>
        /// <param name="programmId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveActor(int programmId, ActorModel model);

        /// <summary>
        /// Сохранить/добавить состав <see cref="ActorGroupModel"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveGroup(ActorGroupModel model);

    }

    
}