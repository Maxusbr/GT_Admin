using Getticket.Web.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// Интерфейс для работы с сущностью <see cref="User" />
    /// </summary>
    public interface IUserRepository : IDisposable
    {
        /// <summary>
        /// Находим пользователя с Id = id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User FindOneById(int id);

        /// <summary>
        /// Находим пользователя с <see cref="User.UserName"/> == <paramref name="Email"/>
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        User FindOneByEmail(string Email);

        /// <summary>
        /// Подсчитываем количество всех(неудаленных) пользователей 
        /// по <paramref name="email" /> и <paramref name="phone" />;
        /// Если <paramref name="phone" /> == <c>null</c> подсчет 
        /// будет вестись только по <paramref name="email" />;
        /// </summary>
        /// <param name="email"><see cref="User.UserName" /></param>
        /// <param name="phone">телефонный номер в формате +7[0-9]{10}</param>
        /// <returns></returns>
        int CountByCredentails(string email, string phone);

        /// <summary>
        /// Возвращает список всех(неудаленных) пользователей 
        /// по <paramref name="email" /> и <paramref name="phone" />;
        /// Если <paramref name="phone" /> == <c>null</c> искать будет
        /// только по <paramref name="email" />;
        /// </summary>
        /// <param name="email"><see cref="User.UserName" /></param>
        /// <param name="phone">телефонный номер в формате +7[0-9]{10}</param>
        /// <returns></returns>
        IList<User> FindAllByCredentails(string email, string phone);

        /// <summary>
        /// Находим всех(неудаленных) пользователей.
        /// </summary>
        /// <returns></returns>
        IList<User> FindAllNotDeleted();

        /// <summary>
        /// Если пользователь новый - добавляем новую запись в БД.
        /// Если пользователь уже существует - сохраняем изменения записи.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User Save(User user);

        /// <summary>
        /// Возвращает всех приглашенных, 
        /// но пока еще не зарегестрированных пользователей
        /// </summary>
        /// <returns></returns>
        IList<User> FindAllInvited();
        
        /// <summary>
        /// Удаляет пользователя из БД по Email,
        /// также удаляет все зависимые сущности
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool DeleteUserByEmail(string userName);

        /// <summary>
        /// Удаляет пользователя из БД по его <paramref name="Id" />
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(int Id);

        /// <summary>
        /// Удаляет пользователя из БД по идентификатору в <paramref name="Entity" />
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        bool Delete(User Entity);

        /// <summary>
        /// Обновить вермя последнего входа
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        bool UpdateLastEnter(int id, DateTime dt);

        /// <summary>
        /// Список сообщений пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<UserMessage> GetUserMessages(int id);

        /// <summary>
        /// Сохранить сообщение
        /// </summary>
        /// <returns></returns>
        UserMessage SaveMessages(UserMessage msg);

    }
}
