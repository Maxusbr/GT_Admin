using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using System;

namespace Getticket.Web.API.Helpers {
    /// <summary>
    /// Helper
    /// </summary>
    public static class SendInviteModelHelper
    {
        /// <summary>
        /// Создает код приглашения указывающий
        /// на нового пользователя из <paramref name="model" />
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InviteCode CreateInviteCode(SendInviteModel model)
        {
            User user = new User()
            {
                UserName = model.Email,
                UserInfo = new UserInfo(),
                AccessRoleId = model.RoleId
            };
            StatusService.ChangeStatus(user, UserStatusType.Invite, null, "Invite created");

            InviteCode invite = new InviteCode()
            {
                User = user,
                Code = PasswordService.GeneratePasswordString(30),
                ActiveTo = DateTime.Now.AddDays(Properties.Settings.Default.DaysForInviteToLive)
            };

            return invite;
        }
    }
}