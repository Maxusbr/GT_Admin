namespace Getticket.Web.API.Models.Emails
{
    /// <summary>
    /// Модель для отправки письма о смене пароля
    /// </summary>
    public class ChangePasswordEmailModel : BaseEmailModel
    {
        /// <summary>
        /// Указывает сменил ли пользователь себе пароль сам или это сделал кто-то другой
        /// </summary>
        public bool SelfChanged { get; set; }

        /// <summary>
        /// Новый пароль
        /// </summary>
        public string Password { get; set; }
    }
}