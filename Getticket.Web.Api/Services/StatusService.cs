using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using System;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис для изменения и проверки статуса пользователя.
    /// </summary>
    public static class StatusService
    {
        /// <summary>
        /// Проверяет возможно ли полностью удалить пользователя  <paramref name="user"/> из системы.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool CanBeRemovedFromDB(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <see cref="UserStatusType.Invite" />,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool ChangeToInvite(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <see cref="UserStatusType.AcceptInvite" />,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool ChangeToAcceptInvite(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <see cref="UserStatusType.Locked" />,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool ChangeToLocked(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <see cref="UserStatusType.MarkDeleted" />,
        /// если да, то меняет его. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool ChangeToDeleted(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <see cref="UserStatusType.System" />,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool ChangeToSystem(User user)
        {
            throw new NotImplementedException();
        }

        
        /// <summary>
        /// Проверяет имеет ли  <paramref name="user"/> статус <see cref="UserStatusType.None" />.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsNone(User user)
        {
            return user.UserStatus.Status.Equals(UserStatusType.None);
        }

        /// <summary>
        /// Проверяет имеет ли  <paramref name="user"/> статус <see cref="UserStatusType.Invite" />.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsInvite(User user)
        {
            return user.UserStatus.Status.Equals(UserStatusType.Invite);
        }
    
        /// <summary>
        /// Проверяет имеет ли  <paramref name="user"/> статус <see cref="UserStatusType.AcceptInvite" />.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsAcceptInvite(User user)
        {
            return user.UserStatus.Status.Equals(UserStatusType.AcceptInvite);
        }

        /// <summary>
        /// Проверяет имеет ли  <paramref name="user"/> статус <see cref="UserStatusType.Locked" />.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsLocked(User user)
        {
            return user.UserStatus.Status.Equals(UserStatusType.Locked);
        }

        /// <summary>
        /// Проверяет имеет ли  <paramref name="user"/> статус <see cref="UserStatusType.MarkDeleted" />.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsMarkDeleted(User user)
        {
            return user.UserStatus.Status.Equals(UserStatusType.MarkDeleted);
        }

        /// <summary>
        /// Проверяет имеет ли  <paramref name="user"/> статус <see cref="UserStatusType.System" />.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsSystem(User user)
        {
            return user.UserStatus.Status.Equals(UserStatusType.System);
        }
 
    }
}