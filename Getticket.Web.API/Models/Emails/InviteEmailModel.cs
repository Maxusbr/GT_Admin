namespace Getticket.Web.API.Models.Emails
{
    /// <summary>
    /// Модель для отправки письма приглашения
    /// </summary>
    public class InviteEmailModel : BaseEmailModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
