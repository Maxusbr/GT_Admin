using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// Интерфейс для работы с концертами
    /// </summary>
    public interface IConcertRepository : IDisposable
    {
        /// <summary>
        /// Возвращает список концертов <see cref="Event"/>
        /// </summary>
        /// <returns></returns>
        IList<Event> GetConcerts();

        /// <summary>
        /// Возвращает список концертов <see cref="Event"/> для мероприятия с Id = <paramref name="eventId"/>
        /// </summary>
        /// <returns></returns>
        IList<Event> GetConcerts(int eventId);

        /// <summary>
        /// Находим концерт <see cref="Event"/> с Id = <paramref name="id" /> 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Event GetConcert(int id);

        /// <summary>
        /// Список концертных серий для концерта <see cref="Event"/> с Id = <paramref name="id" /> 
        /// </summary>
        /// <returns></returns>
        IList<SeriesName> GetConcertSeries(int id);

        /// <summary>
        /// Список расписаний концерта <see cref="Event"/> с Id = <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        IList<ConcertDateRange> GetConcertSchedules(int id);

        /// <summary>
        /// Список программ концерта <see cref="Event"/> с Id = <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        IList<ConcertProgramm> GetConcertProgramms(int id);

        /// <summary>
        /// Список площадок <see cref="Hall"/>
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        IList<Hall> GetHalls(int placeId);

        /// <summary>
        /// Список площадок <see cref="ConcertPlace"/>
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        IList<ConcertPlace> GetConcertPlace(int placeId);

        /// <summary>
        /// Создать концерт
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Event AddConcert(Event model, int userId);

        /// <summary>
        /// Обновить концерт
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Event UpdateConcert(Event model, int userId);

        /// <summary>
        /// Сохранить/добавить площадку <see cref="Hall"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Hall SaveHall(Hall model);

        /// <summary>
        /// Сохранить/добавить площадку <see cref="ConcertPlace"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ConcertPlace SaveConcertPlace(ConcertPlace model);

        /// <summary>
        /// Сохранить/добавить серию <see cref="SeriesName"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        SeriesName SaveSeriesName(SeriesName model);

        /// <summary>
        /// Сохранить/добавить серию <see cref="SeriesName"/> для концерта <see cref="Event"/>
        /// </summary>
        /// <param name="concertId"></param>
        /// <param name="seriesId"></param>
        /// <returns></returns>
        SeriesConcert SaveConcertSeries(int concertId, int seriesId);

        /// <summary>
        /// Сохранить/добавить расписания <see cref="ConcertSchedule"/> для концерта <see cref="ConcertDateRange"/> 
        /// с Id = <paramref name="dateRange"/>
        /// </summary>
        /// <param name="dateRange"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ConcertSchedule SaveConcertSchedule(int dateRange, ConcertSchedule model);

        /// <summary>
        /// Сохранить/добавить расписания <see cref="ConcertDateRange"/> для концерта <see cref="Event"/> с Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="model"></param>
        /// <param name="schedules"></param>
        /// <returns></returns>
        ConcertDateRange SaveConcertSchedule(int eventId, ConcertDateRange model, IEnumerable<ConcertSchedule> schedules);

        /// <summary>
        /// Сохранить/добавить программы <see cref="ConcertProgramm"/> для концерта <see cref="Event"/> с Id = <paramref name="eventId"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="model"></param>
        /// <param name="actors"></param>
        /// <returns></returns>
        ConcertProgramm SaveConcertProgramm(int eventId, ConcertProgramm model, IEnumerable<Actor> actors);

        /// <summary>
        /// Сохранить/добавить билеты <see cref="ConcertTicket"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ConcertTicket SaveConcertTicket(ConcertTicket model);

        /// <summary>
        /// Сохранить/добавить актера <see cref="Actor"/> 
        /// </summary>
        /// <param name="programmId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Actor SaveActor(int programmId, Actor model);

        /// <summary>
        /// Сохранить/добавить состав <see cref="ActorGroup"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ActorGroup SaveGroup(ActorGroup model);

    }
}
