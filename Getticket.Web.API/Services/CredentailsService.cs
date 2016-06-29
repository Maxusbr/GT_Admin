using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using Getticket.Web.DAL.IRepositories;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Сервис аутентификации пользователей
    /// </summary>
    public class CredentailsService
    {
        private IUserRepository UserRep;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="UserRep"></param>
        public CredentailsService(IUserRepository UserRep)
        {
            this.UserRep = UserRep;
        }


        /// <summary>
        /// Проверяет аутентификацию пользователя по
        /// <paramref name="UserName" />, <paramref name="Phone" />, <paramref name="Password" />,
        /// в случае успеха возвращает сущность пользователя
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Phone"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public User Authenticate(string UserName, string Phone, string Password)
        {
            string PasswordHash = PasswordService.GeneratePasswordHash(Password);
            User user = UserRep.FindOneByEmailAndPassword(UserName, PasswordHash);
            if (user != null)
            {
                if (user.UserStatus.Status == UserStatusType.Locked)
                {
                    user = null;
                }
            }

            return user;
        }
    }
}