using Getticket.Web.DAL.Entities;
using System.Collections.Generic;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// Интерфейс для доступа к <see cref="AccessRole"/>
    /// </summary>
    public interface IAccessRoleRepository
    {
        /// <summary>
        /// Получает все доступные системные роли из бд
        /// </summary>
        /// <returns></returns>
        IList<AccessRoles> GetAll();

        /// <summary>
        /// Получает список всех пользователей, у которых присутствует данная роль
        /// </summary>
        /// <returns></returns>
        IList<User> GetAllByRole(int Id);

        /// <summary>
        /// Получает <see cref="AccessRole"/> по <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AccessRoles GetOneById(int id);

        /// <summary>
        /// Добавляет новую или обновляет существующую <see cref="AccessRoles"/>
        /// </summary>
        /// <param name="toSave"></param>
        /// <returns></returns>
        AccessRoles Save(AccessRoles toSave);
    }
}
