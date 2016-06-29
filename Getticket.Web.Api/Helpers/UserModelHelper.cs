using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using System.Collections.Generic;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class UserModelHelper
    {
        /// <summary>
        /// Оборачивает <paramref name="user"/> в модель
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserModel GetUserModel(User user)
        {
            if (user == null)
            {
                return null;
            }
            UserModel model = new UserModel();
            model.Id = user.Id;
            model.Name = user.UserInfo.Name;
            model.LastName = user.UserInfo.LastName;
            model.Company = user.UserInfo.Company;
            model.Position = user.UserInfo.Position;
            model.Phone = user.Phone;
            model.Email = user.UserName;
            model.Status = user.UserStatus.Status;
            model.StatusName = user.UserStatus.Name;
            model.StatusDescription = user.UserStatus.Description;

            return model;
        }

        /// <summary>
        ///  Оборачивает <paramref name="users"/> в модель
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static IList<UserModel> GetUserModel(IList<User> users)
        {
            if (users == null)
            {
                return null;
            }
            List<UserModel> listModel = new List<UserModel>();
            foreach (User u in users)
            {
                listModel.Add(GetUserModel(u));
            }
            return listModel;
        }
    }
}