using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using Getticket.Web.DAL.Repository;
using System;
using System.Collections.Generic;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис для управления пользователями
    /// (обновление, регистрация, удаление и т.п.)
    /// </summary>
    public class UserService : IDisposable
    {
        private IUserRepository UserRep;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserService()
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
                    .Result("User registered")
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
        /// Изменение пароля пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mailIn"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ServiceResponce ChangePassword(int id, string mailIn, ChangePasswordModel model)
        {
            if (id <= 0)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Id must be specified and must be gte 1");
            }
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

            return ServiceResponce.FromSuccess()
               .Result("Password was changed");
        }

        /// <summary>
        /// Устанавливает статус пользователя  равным Locked,
        /// если он был заблокирован ранее или удален - выдается сообщение.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponce Lock(int id)
        {
            if (id <= 0)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Id must be specified and must be gte 1");
            }
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

            return ServiceResponce.FromSuccess()
                .Result("User was locked");
           
        }


        /// <summary>
        /// Обновляет уже существующего пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ServiceResponce UpdateUser(int id, UpdateUserModel model)
        {
            if (id <= 0)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "Id must be specified and must be gte 1");
            }
            User user = UserRep.FindOneById(id);
            if (user == null)
            {
                return ServiceResponce
                    .FromFailed()
                    .Add("error", "User with specified Id was not found");
            }

            user = UpdateUserModelHelper.UpdateUser(user, model);
            UserRep.Save(user);

            return ServiceResponce.FromSuccess()
                .Result("User updated");
               
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

        /// <summary>
        /// Деструктор
        /// </summary>
        public void Dispose()
        {
            this.UserRep.Dispose();
        }
    }
}