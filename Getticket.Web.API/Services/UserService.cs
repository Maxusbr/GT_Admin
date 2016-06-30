using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Emails;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
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

            model.Phone = PhoneService.PhoneConvert(model.Phone);
            if (UserRep.CountByCredentails(model.Email, model.Phone) != 0)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with this Email or Phone already exist");
            }

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


        /// <summary>
        /// Изменение пароля пользователя с идентификатором <paramref name="id" /> 
        /// пользователем с Email <paramref name="currentUserEmail" />;
        /// В случае если пользователь меняет пароль самому себе он должен указать старый пароль
        /// </summary>
        /// <param name="id">Идентификатор пользователя для которого меняется пароль</param>
        /// <param name="currentUserEmail">Email польозователя который меняет пароль</param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ServiceResponce ChangePassword(int id, string currentUserEmail, ChangePasswordModel model)
        {
            User user = UserRep.FindOneById(id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with specified Id was not found");
            }

            bool SelfChangePassword = false;
            if (user.UserName.Equals(currentUserEmail))
            {
                SelfChangePassword = true;
                if (!user.PasswordHash.Equals(PasswordService.GeneratePasswordHash(model.OldPassword)))
                {
                    return ServiceResponce
                        .FromFailed()
                        .Add("error", "Incorrect OldPassword");
                }
            }

            user.PasswordHash = PasswordService.GeneratePasswordHash(model.NewPassword);
            UserRep.Save(user);

            if (model.SendCopyPassword)
            {
                // Создаем задачу отправки сообщения в фоне и запускаем ее
                new Thread(send =>
                {
                    ChangePasswordEmailModel ChangePasswordEmailModel
                        = ChangePasswordEmailModelHelper.GetChangePasswordEmailModel(user.UserName, model.NewPassword, SelfChangePassword);
                    string ChangePasswordText = TemplateServ
                        .Run("Emails/ChangePassword", typeof(ChangePasswordEmailModel), ChangePasswordEmailModel);
                    EmailService.SendMail(ChangePasswordEmailModel, ChangePasswordText);
                }).Start();
            }

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

            if (!StatusService.CanChangeStatus(user, UserStatusType.Locked))
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "it isn't possible to change the status to locked");
            }

            StatusService.ChangeStatus(user, UserStatusType.Locked);
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

            if (!StatusService.CanChangeStatus(user, UserStatusType.Locked, true))
            {
                return ServiceResponce
                   .FromFailed()
                   .Add("error", "it is impossible to unlock because the user isn't locked");
            }
            StatusService.ChangeStatus(user, UserStatusType.System);
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

            if (!CanUpdateUserCredentails(user.Id, model.Email, model.Phone, UserRep))
            {
                return ServiceResponce.FromFailed().Add("error", "Can't update to specified email or phone");
            }
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

            if (!StatusService.CanChangeStatus(user, UserStatusType.MarkDeleted))
            {
                return ServiceResponce
                .FromFailed()
                .Add("error", "it isn't possible to change the status to deleted");
            }

            StatusService.ChangeStatus(user, UserStatusType.MarkDeleted);
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

            if (!StatusService.CanChangeStatus(user, UserStatusType.MarkDeleted, true))
            {
                return ServiceResponce
                .FromFailed()
                .Add("error", "the user isn't deleted");
            }

            if (UserRep.CountByCredentails(user.UserName, user.Phone) != 0)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "user with such email or phone already exists");
            }

            StatusService.ChangeStatus(user, UserStatusType.System);
            UserRep.Save(user);
            return ServiceResponce.FromSuccess();
        }

        /// <summary>
        /// Проверяет возможно ли изменить пользователю с идентификатором <paramref name="UserId" />
        /// его учетные данные (емаил и телефон) на <paramref name="UpdatedName" /> и <paramref name="UpdatedPhone" />
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UpdatedName"></param>
        /// <param name="UpdatedPhone"></param>
        /// <param name="repository">Ссылка на IUserRepository</param>
        /// <returns></returns>
        public static bool CanUpdateUserCredentails(int UserId, string UpdatedName, string UpdatedPhone, IUserRepository repository)
        {
            IList<User> users = repository.FindAllByCredentails(UpdatedName, UpdatedPhone);
            if (users == null)
            {
                return true;
            }

            if (users.Count == 1)
            {
                foreach (User u in users)
                {
                    return u.Id.Equals(UserId);
                }
            }

            return false;
        }

    }
}