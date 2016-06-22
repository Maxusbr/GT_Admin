using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using Getticket.Web.DAL.Repository;
using System.Collections.Generic;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис для управления пользователями
    /// (обновление, регистрация, удаление и т.п.)
    /// </summary>
    public class UserRegistrationService
    {
        private IUserRepository UserRep;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserRegistrationService()
        {
            this.UserRep = new UserRepository();
        }

        /// <summary>
        /// Возвращаем пользователя по его Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User GetById(int Id)
        {
            return UserRep.FindOneById(Id);
        }

        /// <summary>
        /// Воозвращает всех(неудаленных пользователей)
        /// </summary>
        /// <returns></returns>
        public IList<User> GetAll()
        {
            return UserRep.FindAllNotDeleted();
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
            if (UserRep.FindAllByEmail(model.Email) == null)
            {
                string GeneratedPassword = null;
                if (model.GeneratePassword)
                {
                    GeneratedPassword = PasswordService.GeneratePasswordString();
                    model.Password = PasswordService.GeneratePasswordHash(GeneratedPassword);
                }
                else
                {
                    model.Password = PasswordService.GeneratePasswordHash(model.Password);
                }
                User user = RegisterUserModelHelper.CreateUser(model);
                UserRep.Save(user);
                ServiceResponce response = ServiceResponce
                    .FromSuccess()
                    .Add("UserId", user.Id);

                if (model.GeneratePassword)
                {
                    response.Add("GeneratedPassword", GeneratedPassword);
                }

                return response;
            }
            else
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with email " + model.Email + " already exist");
            }
        }

        /// <summary>
        /// Обновляет уже существующего пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ServiceResponce UpdateUser(UpdateUserModel model)
        {
            if (model.Id == 0)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Id must be specified and must be gte 1");
            }
            User user = UserRep.FindOneById(model.Id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with specified Id was not found");
            }

            if (model.PasswordChanged == true)
            {
                user.PasswordHash = PasswordService.GeneratePasswordHash(model.NewPassword);

            }

            user = UpdateUserModelHelper.UpdateUser(user, model);
            UserRep.Save(user);

            return ServiceResponce.FromSuccess();
        }



        /// <summary>
        /// Помечает пользователя с <paramref name="Id"/> как удаленного;
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ServiceResponce MarkDeleted(int Id)
        {
            User user = UserRep.FindOneById(Id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Can't delete user because he do not exist");
            }
            user.UserStatus = UserStatusHelper.Deleted(user.UserStatus.Id);
            UserRep.Save(user);
            return ServiceResponce.FromSuccess();
        }
    }
}