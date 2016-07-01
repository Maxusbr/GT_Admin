using Getticket.Web.API.Models.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public class RestorePasswordEmailModelHelper
    {
        /// <summary>
        /// Получает ChangePasswordEmailModel
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
        public static RestorePasswordEmailModel GetRestorePasswordEmailModel(string Email, string NewPassword)
        {
            RestorePasswordEmailModel toReturn = new RestorePasswordEmailModel();
            toReturn.Caption = "Restore password";
            toReturn.MailTo.Add(Email);
            toReturn.Password = NewPassword;
            return toReturn;
        }
    }
}