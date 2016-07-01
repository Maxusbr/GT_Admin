namespace Getticket.Web.API.Models.Emails
{
    /// <summary>
    /// Модель для восстановления пароля
    /// </summary>
    public class RestorePasswordEmailModel: BaseEmailModel
    {

        /// <summary>
        /// Пароль пользователя для входа в систему
        /// </summary>
        public string Password { get; set; }
    }
}