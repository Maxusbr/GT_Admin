using Getticket.Web.DAL.Entities;
using System.Collections.Generic;

namespace Getticket.Web.DAL.IRepositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Находим пользователя с Id = id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User FindById(int id);

        /// <summary>
        /// Проверяем есть ли среди неудаленных пользователей, пользователь с таким email,
        /// если нашли - возвращаем пользователя.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IList<User> FindAllByEmail(string email);
        
        /// <summary>
        /// Находим всех пользователей, непомеченных как удаленные.
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
    }
}
