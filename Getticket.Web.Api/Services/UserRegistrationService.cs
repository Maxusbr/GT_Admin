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
            return UserRep.Find(Id);
        }

        public IList<User> GetAll()
        {
            return UserRep.FindAll();
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
  
               // user.UserStatus = UserStatusHelper.None(DateTime.Now);
               // user.RoleId = registerUserModel.RoleId;
                return UserRep.Add(user);
            }
            return null;
        }

        public User UpdateUser(User user)
        {
            if (user.Id == 0)
            {
                return null;
            }
            return UserRep.Update(user);
        }

        public bool MarkDelete(int Id)
        {
            return UserRep.MarkDelete(Id);
        }
    }
}