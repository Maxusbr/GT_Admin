using Getticket.Web.DAL.Entities;
using System;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public class UserStatusHelper
    {
        /// <summary>
        /// Создает статус System с указанными <paramref name="Name" /> и <paramref name="Description" />;
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static UserStatus System(string Name, string Description, int Id = 0)
        {
            return new UserStatus() { Id = Id, Name = Name, Description = Description, UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.System };
        }

        /// <summary>
        /// Создает статус Invite с указанными <paramref name="Name" /> и <paramref name="Description" />;
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static UserStatus Invited(string Name, string Description, int Id = 0)
        {
            return new UserStatus() { Name = Name, Description = Description, UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.Invite };
        }

        /// <summary>
        /// Устанавливает статус Deleted для пользователя с Id = <paramref name="Id"/>;
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static UserStatus Deleted(int Id = 0)
        {
            return new UserStatus() {Id = Id, Name = "Deleted", Description = "", UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.MarkDeleted };
        }

        /// <summary>
        /// Устанавливает статус Locked для пользователя с Id = <paramref name="Id"/>;
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static UserStatus Locked(int Id = 0)
        {
            return new UserStatus() { Id = Id, Name = "Locked", Description = "", UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.Locked };
        }

        /// <summary>
        /// Устанавливает статус AcceptInvite для пользователя с Id = <paramref name="Id"/>;
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static UserStatus AcceptInvite(int Id = 0)
        {
            return new UserStatus() { Id = Id, Name = "AcceptInvite", Description = "", UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.AcceptInvite };
        }

        /// <summary>
        /// For debug only
        /// </summary>
        /// <returns></returns>
        // PROD delete it
        public static UserStatus SystemSeed()
        {
            return new UserStatus() { Name = "Seed", Description = "", UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.System };
        }
    }
}