using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using Getticket.Web.DAL.Repository;
using System;

namespace Getticket.Web.API.Services
{
    public class CredentailsService : IDisposable
    {
        private UserRepository UserRep;

        public CredentailsService()
        {
            this.UserRep = new UserRepository();
        }

        // TODO refactor this
        public AuthModel Authenticate(LogonModel model)
        {
            string PasswordHash = PasswordService.GeneratePasswordHash(model.Password);
            string ClearPhone = PhoneService.PhoneConvert(model.Phone);

            User user = null;
            if (String.IsNullOrEmpty(model.Email))
            {
                if (String.IsNullOrEmpty(model.Phone))
                {
                    // Phone and Email are empty return null
                    return null;
                }
                else
                {
                    // find by phone and pass 
                    user = UserRep.FindOneByPhoneAndPassword(ClearPhone, PasswordHash);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(model.Phone))
                {
                    // find by email and pass 
                    user = UserRep.FindOneByEmailAndPassword(model.Email, PasswordHash);
                }
                else
                {
                    // find by all
                    user = UserRep.FindOneByEmailOrPhoneAndPassword(model.Email, ClearPhone, PasswordHash);
                }
            }

            // если пользователь не найден или его тип не System возвращаем null
            if (user == null || !user.UserStatus.Status.Equals(UserStatusType.System))
            {
                return null;
            }

            //return password through model since user.Password is hashed password
            return new AuthModel(user.UserName, model.Password);
        }

        // TODO refactor this
        public bool IsAuthorized(AuthModel model, AccessRoleType role)
        {
            string PasswordHash = PasswordService.GeneratePasswordHash(model.Password);
            User user = UserRep.FindOneByEmailAndPassword(model.Email, PasswordHash);
            if (user != null)
            {
                // асинхронно обновляем LastEnter время пользователя
                UpdateUserVisitAsync(user);

                if (user.UserStatus.Status != UserStatusType.System)
                {
                    return false;
                }

                AccessRoleType UserRole = user.AccessRole.Role;
                bool HasRoll = (role == (role & UserRole));
                return HasRoll;
            }
            return false;
        }

        private async void UpdateUserVisitAsync(User user)
        {
            user.LastEnter = DateTime.Now;
            await UserRep.UpdateTask(user);
        }

        public void Dispose()
        {
            UserRep.Dispose();
        }
    }
}