using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class UpdateInviteModelHelper
    {
        /// <summary>
        /// Обновляет информацию <paramref name="user" /> из <paramref name="model" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static User UpdateInviteUser(User user, UpdateInviteModel model)
        {
            user.UserName = model.Email;
            user.Phone = PhoneService.PhoneConvert(model.Phone);

            user.UserInfo.Name = model.Name;
            user.UserInfo.LastName = model.LastName;
            user.UserInfo.Company = model.Company;
            user.UserInfo.Position = model.Position;

            StatusService.ChangeStatus(user, UserStatusType.AcceptInvite);
            return user;
        }

    }
}