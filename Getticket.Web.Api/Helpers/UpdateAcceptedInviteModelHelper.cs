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
    public class UpdateAcceptedInviteModelHelper
    {
        /// <summary>
        /// Обновляет сущность <paramref name="invite" /> из <paramref name="model" />,
        /// </summary>
        /// <param name="invite"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InviteCode UpdateInviteCode(InviteCode invite, UpdateInviteModel model)
        {
            invite.User.UserInfo.Name = model.Name;
            invite.User.UserInfo.LastName = model.LastName;
            invite.User.UserInfo.Company = model.Company;
            invite.User.UserInfo.Position = model.Position;
            invite.User.UserName = model.Email;
            invite.User.UserInfo.Phone = model.Phone;

            if (model.GeneratePassword)
            {
                invite.User.PasswordHash = PasswordService.GeneratePasswordHash(PasswordService.GeneratePasswordString());
            }
            else
            {
                invite.User.PasswordHash = PasswordService.GeneratePasswordHash(model.Password);
            }
            return invite;
        }
    }
}