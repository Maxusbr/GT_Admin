using Getticket.Web.API.Models;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public class RegisterUserModelHelper
    {
        /// <summary>
        /// Получает Сущность из <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static User CreateUser(RegisterUserModel model)
        {
            User user = new User()
            {
                UserName = model.Email,
                PasswordHash = model.Password,
                AccessRoleId = model.RoleId,
                UserInfo = new UserInfo()
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Company = model.Company,
                    Position = model.Position,
                    Phone = model.Phone
                },
                UserStatus = UserStatusHelper.System(string.Empty, string.Empty)
            };

            return user;
        }
    }
}