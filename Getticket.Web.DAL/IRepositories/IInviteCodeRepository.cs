using System;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.DAL.IRepositories
{
    /// <summary>
    /// Интерфейс для работы с сущностью <see cref="InviteCode" />
    /// </summary>
    public interface IInviteCodeRepository : IDisposable
    {

        /// <summary>
        /// Записывает приглашение и пользователя 
        /// указанных в <paramref name="invite" /> в БД
        /// </summary>
        /// <param name="invite"></param>
        bool Add(InviteCode invite);

        /// <summary>
        /// Находит InviteCode и достает
        /// по ссылке ТОЛЬКО пользователя
        /// без статуса и информации
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        InviteCode FindOneByCode(string code);

        /// <summary>
        /// Cохраняем изменения записи <paramref name="invite"/>
        /// </summary>
        /// <param name="invite"></param>
        /// <returns></returns>
        InviteCode Save(InviteCode invite);
    }
}
