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
        IList<AccessRole> GetAll();

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
        AccessRole GetOneById(int id);

        /// <summary>
        /// Добавляет новую или обновляет существующую <see cref="AccessRole"/>
        /// </summary>
        /// <param name="toSave"></param>
        /// <returns></returns>
        AccessRole Save(AccessRole toSave);
    }
}
