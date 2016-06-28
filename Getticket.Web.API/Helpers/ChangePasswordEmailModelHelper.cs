using Getticket.Web.API.Models.Emails;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class ChangePasswordEmailModelHelper
    {
        /// <summary>
        /// Получает ChangePasswordEmailModel
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="NewPassword"></param>
        /// <param name="SelfChangePassword"></param>
        /// <returns></returns>
        public static ChangePasswordEmailModel GetChangePasswordEmailModel(string Email, string NewPassword, bool SelfChangePassword)
        {
            ChangePasswordEmailModel toReturn = new ChangePasswordEmailModel();
            toReturn.Caption = "Change password";
            toReturn.MailTo.Add(Email);
            toReturn.Password = NewPassword;
            toReturn.SelfChanged = SelfChangePassword;
            return toReturn;
        }
    }
}