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
            return new UserStatus() { Name = Name, Description = Description, UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.System };
        }

        public static UserStatus Deleted(int Id = 0)
        {
            return new UserStatus() {Id = Id, Name = "Deleted", Description = "", UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.Deleted };
        }

        public static UserStatus Locked()
        {
            return new UserStatus() { Name = "Locked", Description = "", UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.Locked };
        }

        public static UserStatus SystemSeed()
        {
            return new UserStatus() { Name = "Seed", Description = "", UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.System };
        }
    }
}