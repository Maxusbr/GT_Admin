using System.Collections.Generic;

namespace Getticket.Web.API.Models.Emails
{
    /// <summary>
    /// Базовая модель для отправки почты
    /// </summary>
    public class BaseEmailModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseEmailModel()
        {
            // Почти всегда мы будем отправлять письма только 1 адресату
            this.MailTo = new List<string>(1);
        }

        /// <summary>
        /// Список адресов для отправки почты
        /// </summary>
        public List<string> MailTo { get; set; }

        /// <summary>
        /// Тема письма
        /// </summary>
        public string Caption { get; set; }

    }
}