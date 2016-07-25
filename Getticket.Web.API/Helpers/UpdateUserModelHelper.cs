using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class UpdateUserModelHelper
    {
        /// <summary>
        /// Обновляет сущность <paramref name="user" /> из <paramref name="model" />,
        /// </summary>
        /// <param name="user"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static User UpdateUser(User user, UpdateUserModel model)
        {
            if (model.Email != null)
            {
                user.UserName = model.Email;
            }

            if (model.Phone != null)
            {
                user.UserPhone = PhoneService.PhoneConvert(model.Phone);
            }

            if (model.Name != null)
            {
                user.UserInfo.Name = model.Name;
            }

            if (model.LastName != null)
            {
                user.UserInfo.LastName = model.LastName;
            }

            if (model.Company != null)
            {
                user.UserInfo.Company = model.Company;
            }

            if (model.Position != null)
            {
                user.UserInfo.Position = model.Position;
            }

            return user;
        }
    }
}