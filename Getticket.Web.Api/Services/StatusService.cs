using Getticket.Web.API.Helpers;
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
        public static readonly string SYSTEM_STATUS_NAME = "System";
        public static readonly string INVITE_STATUS_NAME = "Invite";
        public static readonly string ACCEPTINVITE_STATUS_NAME = "AcceptInvite";
        public static readonly string LOCKED_STATUS_NAME = "Locked";
        public static readonly string MARKDELETE_STATUS_NAME = "MarkDelete";

        /// <summary>
        /// Проверяет возможно ли полностью удалить пользователя  <paramref name="user"/> из системы.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool CanBeRemovedFromDB(User user)
        {
            if (!(IsMarkDeleted(user) || IsInvite(user) || IsAcceptInvite(user)))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <paramref name="typeStatus"/>,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="typeStatus"></param>
        /// <param name="user"></param>
        /// <param name="unStatus"></param>
        /// <returns></returns>
        public static bool CanChangeStatus(UserStatusType typeStatus, User user, bool unStatus = false)
        {
            bool result = false;
            if (!unStatus)
            {
                switch (typeStatus)
                {
                    case UserStatusType.Invite:
                        if (IsNone(user) || IsInvite(user))
                        {
                            result = true;
                        }

                        break;

                    case UserStatusType.AcceptInvite:
                        if (IsInvite(user))
                        {
                            result = true;
                        }
                        break;

                    case UserStatusType.Locked:
                        if (IsSystem(user))
                        {
                            result = true;
                        }
                        break;

                    case UserStatusType.MarkDeleted:
                        if (IsSystem(user) || IsLocked(user) || !IsMarkDeleted(user))
                        {
                            result = true;
                        }
                        break;

                    case UserStatusType.System:
                        if (IsSystem(user) || IsAcceptInvite(user))
                        {
                            result = true;
                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (typeStatus)
                {
                    case UserStatusType.Locked:
                        if (IsLocked(user))
                        {
                            result = true;
                        }
                        break;

                    case UserStatusType.MarkDeleted:
                        if (IsMarkDeleted(user))
                        {
                            result = true;
                        }
                        break;

                    default:
                        break;

                }
            }
            return result;
        }

        /// <summary>
        /// Изменяет статус <paramref name="user"/> на <paramref name="typeStatus"/>  />.
        /// </summary>
        /// <param name="typeStatus"></param>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <param name="StatusName"></param>
        public static void ChangeStatus(UserStatusType typeStatus, User user, string Description, string StatusName)
        {
            user.UserStatus = new UserStatus()
            {
                Id = user.Id,
                Name = StatusName,
                Description = Description,
                UpdateTime = DateTime.Now,
                Status = typeStatus
            };

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