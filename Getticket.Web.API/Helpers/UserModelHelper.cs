﻿using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

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
            UserModel model = new UserModel
            {
                Id = user.Id,
                LastEnter = user.LastEnter,
                Name = user.UserInfo?.Name,
                LastName = user.UserInfo?.LastName,
                Company = user.UserInfo?.Company,
                Position = user.UserInfo?.Position,
                Phone = user.UserPhone,
                Email = user.UserName,
                Status = user.UserStatuses.Status,
                StatusName = user.UserStatuses.Name,
                StatusDescription = user.UserStatuses.Description,
                Roles = user.AccessRoles?.Name,
                RoleId = user.AccessRoleId
            };

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

        public static IList<UserMessageModel> GetMessageModels(IList<UserMessage> msgs)
        {
            return msgs.Select(o => new UserMessageModel
            {
                Id = o.Id,
                Date = o.Date,
                Text = o.Text,
                Status = o.Status,
                SenderId = o.SenderId,
                RecipientId = o.RecipientId,
                Sender = GetUserModel(o.Sender),
                Recipient = GetUserModel(o.Recipient)
            }).ToList();
        }
    }
}