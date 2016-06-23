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
        /// Находим всех(неудаленных) пользователей по email
        /// </summary>
        /// <param name="email"><see cref="User.UserName" /></param>
        /// <returns></returns>
        IList<User> FindAllByEmail(string email);
        
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
    }
}
