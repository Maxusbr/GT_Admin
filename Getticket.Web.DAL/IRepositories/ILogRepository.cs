using Getticket.Web.DAL.Entities;
using System;
using System.Collections.Generic;
using Getticket.Web.DAL.Infrastructure;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// Интерфейс для работы Logs
    /// </summary>
    public interface ILogRepository : IDisposable
    {
        /// <summary>
        /// Возвращает список <see cref="PersonLog"/>
        /// </summary>
        /// <returns></returns>
        IList<PersonLog> GetPersonLogs(int personId);

        /// <summary>
        /// Возвращает последнее изменение <see cref="PersonLog"/>
        /// </summary>
        /// <returns></returns>
        PersonLog GetLastChangePerson(int personId);

        /// <summary>
        /// Возвращает последнее изменение описания <see cref="PersonLog"/>
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonLog GetLastChangePersonDescription(int personId, int id);

        /// <summary>
        /// Возвращает последнее изменение факта <see cref="PersonLog"/>
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonLog GetLastChangePersonFact(int personId, int id);

        /// <summary>
        /// Возвращает последнее изменение связи <see cref="PersonLog"/>
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonLog GetLastChangePersonConnection(int personId, int id);

        /// <summary>
        /// Возвращает последнее изменение медиа <see cref="PersonLog"/>
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonLog GetLastChangePersonMedia(int personId, int id);

        /// <summary>
        /// Возвращает последнее изменение ссылки <see cref="PersonLog"/>
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonLog GetLastChangePersonLink(int personId, int id);

        /// <summary>
        /// Возвращает последнее изменение антропометрии <see cref="PersonLog"/>
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonLog GetLastChangePersonAntro(int personId, int id);

        /// <summary>
        /// Возвращает последнее изменение связи <see cref="EventLog"/>
        /// </summary>
        /// <param name="idEvent"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        EventLog GetLastChangeEventConnection(int idEvent, int id);

        /// <summary>
        /// Возвращает последнее изменение медиа <see cref="EventLog"/>
        /// </summary>
        /// <param name="idEvent"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        EventLog GetLastChangeEventMedia(int idEvent, int id);

        /// <summary>
        /// Возвращает последнее изменение описания <see cref="EventLog"/>
        /// </summary>
        /// <param name="idEvent"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        EventLog GetLastChangeEventDescription(int idEvent, int id);

        EventLog GetLastChangeEventFact(int idEvent, int id);
    }
}
