using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using Getticket.Web.DAL.IRepositories;
using System;
using System.Collections.Generic;

namespace Getticket.Web.API.Services {
    /// <summary>
    /// Сервис аутентификации пользователей
    /// </summary>
    public class CredentailsService {
        private IAuthRepository AuthRep;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AuthRep"></param>
        public CredentailsService(IAuthRepository AuthRep) {
            this.AuthRep = AuthRep;
        }

        /// <summary>
        /// Проверяет аутентификацию пользователя по
        /// <paramref name="UserName" />, <paramref name="Phone" />, <paramref name="Password" />,
        /// в случае успеха возвращает сущность пользователя;
        /// При проверке <paramref name="Phone" /> преобразуется в формат <see cref="PhoneService.PhoneConvert(string)" />,
        /// <paramref name="UserName" /> приводится в нижний регистр
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Phone"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public User Authenticate(string UserName, string Phone, string Password) {
            Password = PasswordService.GeneratePasswordHash(Password);
            Phone = PhoneService.IsPhoneValid(Phone) ? PhoneService.PhoneConvert(Phone) : null;
            UserName = !string.IsNullOrEmpty(UserName) ? UserName.ToLower() : null;
            UserStatusType AvailableStatus = UserStatusType.System;

            if (UserName == null && Phone == null) {
                return null;
            }

            IList<User> users = null;
            if (UserName != null && Phone != null) {
                users = AuthRep.FindAllByNamePhone(UserName, Phone, Password, AvailableStatus);
            } else if (UserName != null) {
                users = AuthRep.FindAllByName(UserName, Password, AvailableStatus);
            } else {
                users = AuthRep.FindAllByPhone(Phone, Password, AvailableStatus);
            }

            if (users == null || users.Count == 0) {
                return null;
            } else if (users.Count == 1) {
                //TODO это зачем?
                User toReturn = null;
                foreach (User u in users) {
                    toReturn = u;
                }
                return toReturn;
            } else {
                throw new Exception("CredentailsService: found more than 1 user with specified credentails");
            }
        }
    }
}