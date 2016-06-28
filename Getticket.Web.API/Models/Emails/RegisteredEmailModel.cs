namespace Getticket.Web.API.Models.Emails
{
    /// <summary>
    /// Модель для отправки письма при регистрации
    /// пользователя другим пользователем системы
    /// </summary>
    public class RegisteredEmailModel : BaseEmailModel
    {
        /// <summary>
        /// Email пользователя для входа в систему
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя для входа в систему
        /// </summary>
        public string Password { get; set; }
    }
}