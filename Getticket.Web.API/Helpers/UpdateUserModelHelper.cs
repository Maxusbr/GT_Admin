using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using System;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public class UpdateUserModelHelper
    {
        // TODO implement neded
        /// <summary>
        /// Обновляет сущность <paramref name="user" /> из <paramref name="model" />,
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static User UpdateUser(User user, UpdateUserModel model)
        {
            throw new NotImplementedException();
        }

        /*
            user.UserName = model.Email;
            user.UserInfo.Name = model.Name;
            user.UserInfo.LastName = model.LastName;
            user.UserInfo.Company = model.Company;
            user.UserInfo.Position = model.Position;
            user.UserInfo.Phone = model.Phone;

            if (model.Locked)
            {
                user.UserStatus = UserStatusHelper.SystemSeed();
            }
         
         
         */
    }
}