using Getticket.Web.DAL.Entities;
using System;

namespace Getticket.Web.API.Helpers
{
    public class UserStatusHelper
    {
        public static UserStatus Deleted()
        {
            return new UserStatus() { Name = "Deleted", Description = "", UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.Deleted };
        }

        public static UserStatus SystemSeed()
        {
            return new UserStatus() { Name = "Seed", Description = "", UpdateTime = DateTime.Now, Status = DAL.Enums.UserStatusType.System };
        }
    }
}