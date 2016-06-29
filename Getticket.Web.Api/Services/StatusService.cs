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
        private static readonly string SYSTEM_STATUS_NAME = "System";
        
        /// <summary>
        /// Проверяет возможно ли полностью удалить пользователя  <paramref name="user"/> из системы.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool CanBeRemovedFromDB(User user)
        {
            if ( !(IsMarkDeleted(user) || IsInvite(user) || IsAcceptInvite(user)) )
            {
                return false;
            }
            return true;
        }

    
        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <see cref="UserStatusType.Invite" />,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static bool ToInvite(User user, string Description)
        {
            string StatusName = "Invite";

            if( !(IsNone(user) || IsInvite(user)) )
            {
                return false;
            }

            user.UserStatus = new UserStatus()
            {
                Id = user.Id,
                Name = StatusName,
                Description = Description,
                UpdateTime = DateTime.Now,
                Status = UserStatusType.Invite
            };

            return true;
        }


        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <see cref="UserStatusType.AcceptInvite" />,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static bool ToAcceptInvite(User user, string Description)
        {
            string StatusName = "Accept Invite";

            if (!IsInvite(user))
            {
                return false;
            }

            user.UserStatus = new UserStatus()
            {
                Id = user.Id, 
                Name = StatusName, 
                Description = Description, 
                UpdateTime = DateTime.Now, 
                Status = UserStatusType.AcceptInvite
            };

            return true;
        }


        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <see cref="UserStatusType.Locked" />,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static bool ToLocked(User user, string Description)
        {
            string StatusName = "Locked";

            if (!IsSystem(user))
            {
                return false;
            }

            user.UserStatus = new UserStatus()
            {
                Id = user.Id,
                Name = StatusName,
                Description = Description,
                UpdateTime = DateTime.Now,
                Status = UserStatusType.Locked
            };

            return true;
        }

        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <see cref="UserStatusType.MarkDeleted" />,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static bool ToDeleted(User user, string Description)
        {
            string StatusName = "Mark Deleted";

            if ( !(IsSystem(user)||IsLocked(user)) )
            {
                return false;
            }

            user.UserStatus = new UserStatus()
            {
                Id = user.Id,
                Name = StatusName,
                Description = Description,
                UpdateTime = DateTime.Now,
                Status = UserStatusType.MarkDeleted
            };

            return true;
        }

        /// <summary>
        /// Проверяет имеет ли <paramref name="user"/> статус <see cref="UserStatusType.Locked" />,
        /// если да, то меняет его на <see cref="UserStatusType.System" />.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static bool FromLockToSystem(User user, string Description)
        {
            if (!IsLocked(user))
            {
                return false;
            }
            ChangeToSystem(user, Description, SYSTEM_STATUS_NAME);
            return true;
        }

        /// <summary>
        /// Проверяет имеет ли <paramref name="user"/> статус <see cref="UserStatusType.MarkDeleted" />,
        /// если да, то меняет его на <see cref="UserStatusType.System" />.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static bool FromMarkDeletedToSystem(User user, string Description)
        {
            if (!IsMarkDeleted(user))
            {
                return false;
            }
            ChangeToSystem(user, Description, SYSTEM_STATUS_NAME);
            return true;
        }

        /// <summary>
        /// Проверяет имеет ли <paramref name="user"/> статус <see cref="UserStatusType.None" />,
        /// если да, то меняет его на <see cref="UserStatusType.System" />.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static bool FromNoneToSystem(User user, string Description)
        {
            if (!IsNone(user))
            {
                return false;
            }
            ChangeToSystem(user, Description, SYSTEM_STATUS_NAME);
            return true;
        }

        /// <summary>
        /// Проверяет имеет ли <paramref name="user"/> статус <see cref="UserStatusType.AcceptInvite" />,
        /// если да, то меняет его на <see cref="UserStatusType.System" />.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static bool FromAcceptInviteToSystem(User user, string Description)
        {
            if (!IsAcceptInvite(user))
            {
                return false;
            }
            ChangeToSystem(user, Description, SYSTEM_STATUS_NAME);
            return true;
        }

        /// <summary>
        /// Проверяет имеет ли <paramref name="user"/> статус <see cref="UserStatusType.System" />,
        /// если да, то меняет его на <see cref="UserStatusType.System" /> с указанными параметрами
        /// <paramref name="Name"/> и <paramref name="Description"/>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static bool FromSystemToSystem(User user, string Name, string Description)
        {
            if (!IsSystem(user))
            {
                return false;
            }
            ChangeToSystem(user, Description, Name);
            return true;
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

        /// <summary>
        /// Изменяет статус <paramref name="user"/> на <see cref="UserStatusType.System" />.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Description"></param>
        /// <param name="StatusName"></param>
        private static void ChangeToSystem(User user, string Description, string StatusName = null)
        {
            if (StatusName == null)
            {
                StatusName = "System";
            }

            user.UserStatus = new UserStatus()
            {
                Id = user.Id,
                Name = StatusName,
                Description = Description,
                UpdateTime = DateTime.Now,
                Status = UserStatusType.System
            };
        }
    }
}