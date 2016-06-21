using Getticket.Web.API.Helpers;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Services
{
    public class UserRegistrationService
    {
        private UserRepository UserRep = new UserRepository();


        public User GetById(int Id)
        {
            return UserRep.FindById(Id);
        }

        public IList<User> GetAll()
        {
            return UserRep.FindAllNotDeleted();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerUserModel"></param>
        /// <returns></returns>
        public User CreateActiveUser(RegisterUserModel registerUserModel)
        {
            registerUserModel.Phone = PhoneService.PhoneConvert(registerUserModel.Phone);
            if (UserRep.FindAllByEmail(registerUserModel.Email) == null)
            {
                if (registerUserModel.GeneratePassword == true)
                {
                    registerUserModel.Password = PasswordService.GeneratePasswordHash(PasswordService.GeneratePasswordString());
                }
                else
                {
                    registerUserModel.Password = PasswordService.GeneratePasswordHash(registerUserModel.Password);
                }
                User user = new User();
                user.UserName = registerUserModel.Email;
                user.PasswordHash = registerUserModel.Password;
                user.UserInfo = new UserInfo();
                user.UserInfo.Name = registerUserModel.Name;
                user.UserInfo.LastName = registerUserModel.LastName;
                user.UserInfo.Company = registerUserModel.Company;
                user.UserInfo.Position = registerUserModel.Position;
                user.UserInfo.Phone = registerUserModel.Phone;

                user.UserStatus = UserStatusHelper.SystemSeed();
                user.AccessRoleId = registerUserModel.RoleId;
                return UserRep.Save(user);
            }
            return null;
        }

        public User UpdateUser(UpdateUserModel updateUserModel)
        {
            if (updateUserModel.Id == 0)
            {
                return null;
            }
            User user = this.GetById(updateUserModel.Id);
            if (updateUserModel.PasswordChanged == true)
            {
                user.PasswordHash = PasswordService.GeneratePasswordHash(updateUserModel.NewPassword);

            }
          
            user.UserName = updateUserModel.Email;
            user.UserInfo.Name = updateUserModel.Name;
            user.UserInfo.LastName = updateUserModel.LastName;
            user.UserInfo.Company = updateUserModel.Company;
            user.UserInfo.Position = updateUserModel.Position;
            user.UserInfo.Phone = updateUserModel.Phone;
                                    
            if(updateUserModel.Locked)
            {
                user.UserStatus = UserStatusHelper.SystemSeed();
            }
            return UserRep.Save(user);
        }

        public bool MarkDelete(int Id)
        {
            return UserRep.MarkDelete(Id);
        }
    }
}