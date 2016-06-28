using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Helpers
{
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
        /// <param name="InviteCode">Код для доступа к приглашению</param>
        /// <param name="StatusName">Имя статуса</param>
        /// <param name="StatusDescription">Описание статуса</param>
        /// <param name="ActiveTo">Время до которого будет активен инвайт</param>
        /// <returns></returns>
        public static InviteCode CreateInviteCode(SendInviteModel model, string InviteCode, string StatusName, string StatusDescription, DateTime ActiveTo)
        {
            User user = new User()
            {
                UserName = model.Email,
                UserInfo = new UserInfo(),
                UserStatus = UserStatusHelper.Invited(StatusName, StatusDescription),
                AccessRoleId = model.RoleId
            };

            InviteCode invite = new InviteCode()
            {
                User = user,
                Code = InviteCode,
                ActiveTo = ActiveTo
            };

            return invite;
        }
    }
}