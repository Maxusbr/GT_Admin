﻿using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class RegisterUserModelHelper
    {
        /// <summary>
        /// Получает Сущность из <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static User CreateUser(RegisterUserModel model)
        {
            User user = new User()
            {
                UserName = model.Email,
                Phone = model.Phone,
                PasswordHash = model.Password,
                AccessRoleId = model.RoleId,
                UserInfo = new UserInfo()
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Company = model.Company,
                    Position = model.Position,
                },
                UserStatus = StatusServiceHelper.System(string.Empty, string.Empty)
            };

            return user;
        }
    }
}