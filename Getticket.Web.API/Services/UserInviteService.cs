using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Emails;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

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
        private IRazorEngineService TemplateServ;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserInviteService(
            IInviteCodeRepository InviteRep, 
            IUserRepository UserRep, 
            IRazorEngineService TemplateServ)
        {
            this.InviteRep = InviteRep;
            this.UserRep = UserRep;
            this.TemplateServ = TemplateServ;
        }

        /// <summary>
        /// Возвращает всех приглашенных, 
        /// но пока еще не зарегестрированных пользователей
        /// </summary>
        /// <returns></returns>
        public IList<UserModel> GetAllInvited()
        {
            IList<User> users = UserRep.FindAllInvited();
            return UserModelHelper.GetUserModel(users);
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
                    "Invite created at " + DateTime.Now,
                    DateTime.Now.AddDays(Properties.Settings.Default.DaysForInviteToLive)
                );

            if (InviteRep.Add(Invite))
            {
                // Создаем задачу отправки сообщения в фоне и запускаем ее
                new Thread(send => 
                {
                    InviteEmailModel InviteEmailModel = InviteEmailModelHelper.GetInviteEmailModel(Invite);
                    string inviteText = TemplateServ
                        .Run("Emails/Invite", typeof(InviteEmailModel), InviteEmailModel);
                    if (!EmailService.SendMail(InviteEmailModel, inviteText))
                    {
                        Invite.User.UserStatus.Description = "Invite Email was not delivered";
                        Invite.User.UserStatus.UpdateTime = DateTime.Now;
                    }
                    else
                    {
                        Invite.User.UserStatus.Description = "Invite Email was delivered at " + DateTime.Now;
                        Invite.User.UserStatus.UpdateTime = DateTime.Now;
                    }
                    InviteRep.Update(Invite);

                }).Start();

                return ServiceResponce
                    .FromSuccess()
                    .Result("invite for user sended");
            }
            else
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "error saving invited user in DB");
            }
        }

        /// <summary>
        /// Обновляет данные приглашения пользователя
        /// и переводит статус приглашения в статус ожидающий
        /// "Акцепта(ТЗ стр.8)"
        /// </summary>
        /// <param name="code">Код приглашения</param>
        /// <param name="model">Модель с данными для обновления</param>
        /// <returns></returns>
        public ServiceResponce UpdateInvite(string code, UpdateInviteModel model)
        {
            InviteCode invite = InviteRep.FindOneByCode(code);
            if (invite == null)
            {
                return ServiceResponce
                   .FromFailed()
                   .Add("error", "invite not found");
            }
            invite = UpdateAcceptedInviteModelHelper.UpdateInviteCode(invite, model);
            InviteRep.Save(invite);
                return ServiceResponce
                   .FromSuccess()
                   .Result("invite for user updated");
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