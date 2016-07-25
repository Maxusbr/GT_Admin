using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using System;

namespace Getticket.Web.API.Services {
    /// <summary>
    /// Сервис для изменения и проверки статуса пользователя.
    /// </summary>
    public static class StatusService {

        /// <summary>
        /// Проверяет возможно ли полностью удалить пользователя  <paramref name="user"/> из системы.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool CanBeRemovedFromDB(User user) {
            UserStatusType current = user.UserStatuses.Status;

            return (UserStatusType.Invite.Equals(current) 
                || UserStatusType.AcceptInvite.Equals(current) 
                || UserStatusType.MarkDeleted.Equals(current));
        }


        /// <summary>
        /// Проверяет возможно ли изменение статуса <paramref name="user"/> на <paramref name="changeTo"/>,
        /// если да, то меняет его.
        /// </summary>
        /// <param name="changeTo">Статус на который необходимо сменить</param>
        /// <param name="user">пользователь, статус которого проверяем</param>
        /// <param name="undo">Означает что необходимо снять статус <paramref name="changeTo"/></param>
        /// <returns></returns>
        public static bool CanChangeStatus(User user, UserStatusType changeTo, bool undo = false) {
            UserStatusType currentStatus = user.UserStatuses == null ? UserStatusType.None : user.UserStatuses.Status;
            if (undo) {
                return CanRemoveStatus(currentStatus, changeTo);
            } else {
                return CanUpdateStatus(currentStatus, changeTo);
            }
        }

        /// <summary>
        /// Изменяет <see cref="UserStatus"/> пользователя <paramref name="User"/> на <see cref="UserStatus"/> <paramref name="Status"/>.
        /// Если не указан <paramref name="Name"/>, то задает его как <c>Status.ToString()</c>
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="User"></param>
        /// <param name="Description"></param>
        /// <param name="Name"></param>
        public static void ChangeStatus(User User, UserStatusType Status, string Name = null,  string Description = "") {

            UserStatuses toChange = User.UserStatuses != null ? User.UserStatuses : new UserStatuses();
            if (Name == null) {
                Name = Status.ToString();
            }

            toChange.Name = Name;
            toChange.Description = Description;
            toChange.Status = Status;
            toChange.UpdateTime = DateTime.Now;

            User.UserStatuses = toChange;
        }

        private static bool CanUpdateStatus(UserStatusType currentStatus, UserStatusType toSet) {
            switch (toSet) {
                case UserStatusType.Invite:
                    return (UserStatusType.None.Equals(currentStatus) 
                        || UserStatusType.Invite.Equals(currentStatus));

                case UserStatusType.AcceptInvite:
                    return (UserStatusType.Invite.Equals(currentStatus));

                case UserStatusType.Locked:
                    return (UserStatusType.System.Equals(currentStatus));

                case UserStatusType.MarkDeleted:
                    return (UserStatusType.System.Equals(currentStatus) 
                        || UserStatusType.Locked.Equals(currentStatus));

                case UserStatusType.System:
                    return (UserStatusType.System.Equals(currentStatus) 
                        || UserStatusType.None.Equals(currentStatus) 
                        || UserStatusType.AcceptInvite.Equals(currentStatus));

                default:
                    return false;
            }
        }

        private static bool CanRemoveStatus(UserStatusType currentStatus, UserStatusType toRemove) {
            if (IsRemoveable(currentStatus)) {
                return currentStatus.Equals(toRemove);
            }
            return false;
        }

        private static bool IsRemoveable(UserStatusType status) {
            return (status.Equals(UserStatusType.Locked)
                || status.Equals(UserStatusType.MarkDeleted));
        }

    }
}