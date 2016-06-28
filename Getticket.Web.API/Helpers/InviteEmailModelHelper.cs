using Getticket.Web.API.Models.Emails;
using Getticket.Web.DAL.Entities;

namespace Getticket.Web.API.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class InviteEmailModelHelper
    {
        /// <summary>
        /// Формирует InviteEmailModel из <paramref name="invite"/>
        /// </summary>
        /// <param name="invite"></param>
        public static InviteEmailModel GetInviteEmailModel(InviteCode invite)
        {
            InviteEmailModel toReturn = new InviteEmailModel();
            toReturn.MailTo.Add(invite.User.UserName);
            toReturn.Caption = "Invite";
            toReturn.Link = invite.Code;
            return toReturn;
        }
    }
}