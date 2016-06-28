using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Emails;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using RazorEngine.Templating;
using System.Collections.Generic;
using System.Threading;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис для управления пользователями
    /// (обновление, регистрация, удаление и т.п.)
    /// </summary>
    public class UserService
    {
        private IUserRepository UserRep;
        private IRazorEngineService TemplateServ;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserService(IUserRepository UserRep, IRazorEngineService TemplateServ)
        {
            this.UserRep = UserRep;
            this.TemplateServ = TemplateServ;
        }

        /// <summary>
        /// Воозвращает всех(неудаленных пользователей)
        /// </summary>
        /// <returns></returns>
        public IList<UserModel> GetAll()
        {
            IList<User> users = UserRep.FindAllNotDeleted();
            return UserModelHelper.GetUserModel(users);
        }

        /// <summary>
        /// Возвращаем пользователя по его Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserModel GetById(int Id)
        {
            User user = UserRep.FindOneById(Id);
            return UserModelHelper.GetUserModel(user);
        }

        /// <summary>
        /// Создает зарегестрированного пользователя
        /// </summary>
        /// <param name="model">Модель для регистрации пользователя</param>
        /// <returns>ServiceResponce</returns>
        public ServiceResponce CreateSystemUser(RegisterUserModel model)
        {
            if (!model.GeneratePassword && !PasswordService.IsPasswordAcceptable(model.Password))
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Password not acceptable");
            }

            model.Phone = PhoneCheckService.PhoneConvert(model.Phone);
            if (UserRep.CountByCredentails(model.Email, model.Phone) == 0)
            {
                // Генерируем и хэшируем пароль
                string UnHashedPassword = model.Password;
                if (model.GeneratePassword)
                {
                    UnHashedPassword = PasswordService.GeneratePasswordString();  
                }
                model.Password = PasswordService.GeneratePasswordHash(UnHashedPassword);

                User user = RegisterUserModelHelper.CreateUser(model);
                UserRep.Save(user);
                ServiceResponce response = ServiceResponce
                    .FromSuccess()
                    .Result("User registered")
                    .Add("UserId", user.Id);

                if (model.GeneratePassword)
                {
                    response.Add("GeneratedPassword", UnHashedPassword);
                }

                if (model.NotSendWelcome == false)
                {
                    // Создаем задачу отправки сообщения в фоне и запускаем ее
                    new Thread(send =>
                    {
                        RegisteredEmailModel RegisteredEmailModel
                            = RegisteredEmailModelHelper.GetRegisteredEmailModel(model, UnHashedPassword);
                        string RegisteredText = TemplateServ
                            .Run("Emails/Registered", typeof(RegisteredEmailModel), RegisteredEmailModel);
                        EmailService.SendMail(RegisteredEmailModel, RegisteredText);

                    }).Start();
                }
                
                return response;
            }
            else
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with this Email or Phone already exist");
            }
        }

        /// <summary>
        /// Изменение пароля пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mailIn"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ServiceResponce ChangePassword(int id, string mailIn, ChangePasswordModel model)
        {
            User user = UserRep.FindOneById(id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with specified Id was not found");
            }
            if ((user.UserName.Equals(mailIn))
                && (!user.PasswordHash.Equals(PasswordService.GeneratePasswordHash(model.OldPassword))))
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Incorrect OldPassword");
            }
            user.PasswordHash = PasswordService.GeneratePasswordHash(model.NewPassword);
            UserRep.Save(user);

            return ServiceResponce.FromSuccess();
         }

     

        /// <summary>
        /// Устанавливает статус пользователя  равным Locked,
        /// если он был заблокирован ранее или удален - выдается сообщение.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponce Lock(int id)
        {
            User user = UserRep.FindOneById(id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with specified Id was not found");
            }

            if (user.UserStatus.Status == DAL.Enums.UserStatusType.Locked)
            {
                return ServiceResponce
                .FromFailed()
                .Add("error", "User is already locked");
            }

            if (user.UserStatus.Status == DAL.Enums.UserStatusType.Deleted)
            {
                return ServiceResponce
                .FromFailed()
                .Add("error", "User was deleted, can not be blocked");
            }

            user.UserStatus = UserStatusHelper.Locked(user.UserStatus.Id);
            UserRep.Save(user);

            return ServiceResponce.FromSuccess();
        }

        /// <summary>
        /// Меняет статус Locked пользователя с <paramref name="id"> </paramref>на System;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponce Unlock(int id)
        {
            User user = UserRep.FindOneById(id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with specified Id was not found");
            }

            if (user.UserStatus.Status != DAL.Enums.UserStatusType.Locked)
            {
                return ServiceResponce
                .FromFailed()
                .Add("error", "User is not locked");
            }

            if (user.UserStatus.Status == DAL.Enums.UserStatusType.Deleted)
            {
                return ServiceResponce
                .FromFailed()
                .Add("error", "User was deleted, can not be unlocked");
            }

            user.UserStatus = UserStatusHelper.System("", "", user.UserStatus.Id);
            UserRep.Save(user);

            return ServiceResponce.FromSuccess();
        }


        /// <summary>
        /// Обновляет уже существующего пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ServiceResponce UpdateUser(int id, UpdateUserModel model)
        {
            User user = UserRep.FindOneById(id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with specified Id was not found");
            }

            user = UpdateUserModelHelper.UpdateUser(user, model);
            UserRep.Save(user);

            return ServiceResponce.FromSuccess();
        }



        /// <summary>
        /// Помечает пользователя с <paramref name="id"/> как удаленного;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponce MarkDeleted(int id)
        {
            User user = UserRep.FindOneById(id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Can't delete user because he doesn't exist");
            }

            if (user.UserStatus.Status == DAL.Enums.UserStatusType.Deleted)
            {
                return ServiceResponce
                .FromFailed()
                .Add("error", "User already deleted");
            }

            user.UserStatus = UserStatusHelper.Deleted(user.UserStatus.Id);
            UserRep.Save(user);
            return ServiceResponce.FromSuccess();
        }

        /// <summary>
        /// Снимает метку "delete" пользователя с <paramref name="id"/> устанавливает статус System;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponce MarkNotDeleted(int id)
        {
            User user = UserRep.FindOneById(id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "user doesn't exist");
            }

            if (user.UserStatus.Status != DAL.Enums.UserStatusType.Deleted)
            {
                return ServiceResponce
                .FromFailed()
                .Add("error", "User is not deleted");
            }

            if  (UserRep.CountByCredentails(user.UserName, user.UserInfo.Phone) != 0)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "user with such email or phone already exists");
            }

            user.UserStatus = UserStatusHelper.System("","",user.UserStatus.Id);
            UserRep.Save(user);
            return ServiceResponce.FromSuccess();
        }

    }
}
        

