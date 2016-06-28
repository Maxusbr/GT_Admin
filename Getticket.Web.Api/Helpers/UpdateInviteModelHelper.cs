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
    public class UpdateInviteModelHelper
    {
        public static User UpdateInviteUser(User user, UpdateInviteModel model)
        {

            user.UserName = model.Email;
            user.UserInfo.Name = model.Name;
            user.UserInfo.LastName = model.LastName;
            user.UserInfo.Company = model.Company;
            user.UserInfo.Position = model.Position;
            user.UserInfo.Phone = PhoneService.PhoneConvert(model.Phone);

            return user;
        }

    }
}