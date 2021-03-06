﻿using System.Collections.Generic;
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
        /// Список наименований концертных серий
        /// </summary>
        /// <returns></returns>
        IEnumerable<SeriesNameModel> GetConcertSeriesName();

        /// <summary>
        /// Список расписаний концерта <see cref="EventModel"/> с Id = <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        ConcertDateRangeModel GetConcertSchedules(int id);
        /// <summary>
        /// Список превью недельных расписаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        IEnumerable<PreviewScheduleModel> GetPreview(IEnumerable<WeekScheduleModel> models);
        /// <summary>
        /// Список превью недельных расписаний
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        IEnumerable<PreviewScheduleModel> GetPreview(IEnumerable<RangeScheduleModel> models);

        /// <summary>
        /// Список программ концерта <see cref="EventModel"/> с Id = <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<ActorProgrammModel> GetConcertProgramms(int id);

        /// <summary>
        /// Список участников с программами
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ActorModel> GetActorProgramms(int id);

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
        /// Список составов участников
        /// </summary>
        /// <returns></returns>
        IEnumerable<ActorGroupModel> GetActorGroups();

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
        HallModel SaveHall(HallModel model);

        /// <summary>
        /// Сохранить/добавить серию <see cref="SeriesNameModel"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveSeriesName(SeriesConcertModel model);

        /// <summary>
        /// Сохранить/добавить расписания <see cref="ConcertScheduleModel"/> для концерта <see cref="EventModel"/> с Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveConcertSchedules(ConcertDateRangeModel model);

        /// <summary>
        /// Сохранить/добавить программы <see cref="ConcertProgrammModel"/> для концерта <see cref="EventModel"/> с Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        bool SaveConcertProgramm(int eventId, IEnumerable<ConcertProgrammModel> models);

        /// <summary>
        /// Добавить программу <see cref="ConcertProgrammModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveConcertProgramm(ConcertProgrammModel model);

        /// <summary>
        /// Обновить программу <see cref="ConcertProgrammModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateConcertProgramm(ConcertProgrammModel model);

        /// <summary>
        /// Сохранить/добавить билеты <see cref="ConcertTicketModel"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveConcertTicket(ConcertTicketModel model);

        /// <summary>
        /// Добавить актера <see cref="ActorModel"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveActor(ActorModel model);

        /// <summary>
        /// Обновить актера <see cref="ActorModel"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateActor(ActorModel model);

        /// <summary>
        /// Сохранить/добавить состав <see cref="ActorGroupModel"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ServiceResponce SaveGroup(ActorGroupModel model);

        /// <summary>
        /// Сохранить название концертной площадки
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ConcertPlaceModel SaveConcertPlace(ConcertPlaceModel model);

        /// <summary>
        /// Проверка наличия программы и календаря концерта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ConcertExistModel GetConcertExist(int id);


        
    }

    
}