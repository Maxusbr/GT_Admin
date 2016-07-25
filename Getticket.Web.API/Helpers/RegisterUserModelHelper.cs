using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class RegisterUserModelHelper
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
                UserPhone = model.Phone,
                PasswordHash = model.Password,
                AccessRoleId = model.RoleId,
                UserInfo = new UserInfo()
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Company = model.Company,
                    Position = model.Position,
                },
            };

            StatusService.ChangeStatus(user, UserStatusType.System);
            return user;
        }
    }
}