using System.Collections.Generic;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// Интерфейс для аутентификации, авторизации, и получения роли пользователя
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Находит всех пользователей, имеющих заданные <paramref name="UserName" />
        /// <paramref name="PasswordHash" /> <paramref name="Status" />;
        /// <c>Include("AccessRole")</c>
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PasswordHash"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        IList<User> FindAllByName(string UserName, string PasswordHash, UserStatusType Status);

        /// <summary>
        /// Находит всех пользователей, имеющих заданные <paramref name="Phone" />
        /// <paramref name="PasswordHash" /> <paramref name="Status" />;
        /// <c>Include("AccessRole")</c>
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="PasswordHash"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        IList<User> FindAllByPhone(string Phone, string PasswordHash, UserStatusType Status);

        /// <summary>
        /// Находит всех пользователей, имеющих заданные <paramref name="UserName" /> <paramref name="Phone" />
        /// <paramref name="PasswordHash" /> <paramref name="Status" />;
        /// <c>Include("AccessRole")</c>
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Phone"></param>
        /// <param name="PasswordHash"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        IList<User> FindAllByNamePhone(string UserName, string Phone, string PasswordHash, UserStatusType Status);
    }
}
