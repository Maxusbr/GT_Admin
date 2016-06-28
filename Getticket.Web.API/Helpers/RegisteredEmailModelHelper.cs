using Getticket.Web.API.Models;
using Getticket.Web.API.Models.Emails;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class RegisteredEmailModelHelper
    {

        /// <summary>
        /// Получает RegisteredEmailModel
        /// </summary>
        /// <param name="model"></param>
        /// <param name="UnHashedPassword"></param>
        /// <returns></returns>
        public static RegisteredEmailModel GetRegisteredEmailModel(RegisterUserModel model, string UnHashedPassword)
        {
            RegisteredEmailModel toReturn = new RegisteredEmailModel();
            toReturn.Caption = "Registration";
            toReturn.MailTo.Add(model.Email);

            toReturn.Email = model.Email;
            toReturn.Password = UnHashedPassword;

            return toReturn;
        }
    }
}