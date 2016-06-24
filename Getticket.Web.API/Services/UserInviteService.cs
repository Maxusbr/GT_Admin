﻿using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Манаджер для создания приглашений для пользователей,
    /// отправки им писем, подтверждения приглашений
    /// и регистрации по приглашению
    /// </summary>
    public class UserInviteService
    {
        private IInviteCodeRepository InviteRep;
        private IUserRepository UserRep;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserInviteService(IInviteCodeRepository InviteRep, IUserRepository UserRep)
        {
            this.InviteRep = InviteRep;
            this.UserRep = UserRep;
        }

        /// <summary>
        /// Возвращает всех приглашенных, 
        /// но пока еще не зарегестрированных пользователей
        /// </summary>
        /// <returns></returns>
        public IList<User> GetAllInvited()
        {
            return UserRep.FindAllInvited();
        }


        /// <summary>
        /// Посылает приглашение на регистрацию указанному пользователю
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ServiceResponce SendInvite(SendInviteModel model)
        {
            // TODO mail invite
            if (UserRep.FindAllByEmail(model.Email) != null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with Email " + model.Email + " already exist in system");
            }
            InviteCode Invite = SendInviteModelHelper
                .CreateInviteCode
                (
                    model, 
                    PasswordService.GeneratePasswordString(30), 
                    "Invited", 
                    "Invite created" + DateTime.Now,
                    DateTime.Now.AddDays(Properties.Settings.Default.DaysForInviteToLive)
                );

            if (InviteRep.Add(Invite))
            {
                return ServiceResponce
                    .FromSuccess()
                    .Result("invite for user created");
            }
            else
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "error saving invited user in DB");
            }
        }

        /// <summary>
        /// Проверяет есть ли активный, непринятый инвайт по коду,
        /// Если есть: возвращает Email приглашенного пользователя для использования при обновлении информации;
        /// Если он есть но просрочен: удаляет приглашенного пользователя и инвайт для него;
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ServiceResponce CheckInviteExist(string code)
        {
            InviteCode invite = InviteRep.FindOneByCode(code);
            if (invite == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Invite for this code do not exist");
            }
            if (invite.ActiveTo < DateTime.Now)
            {
                this.DeleteInviteAndUser(invite);

                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Invite is out of date and will be removed");
            }
            return ServiceResponce
                .FromSuccess()
                .Result("Founded")
                .Add("Email", invite.User.UserName);
        }

        /// <summary>
        /// Удаляет инвайт и пользователя для которого он создан
        /// </summary>
        /// <param name="invite"></param>
        private void DeleteInviteAndUser(InviteCode invite)
        {
            if (!UserRep.DeleteUserByEmail(invite.User.UserName))
            {
                throw new NotImplementedException();
            }
        }
    }
}