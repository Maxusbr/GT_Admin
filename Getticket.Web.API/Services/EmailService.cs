using Getticket.Web.API.Models.Emails;
using Getticket.Web.API.Properties;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Служба отправки сообщений электронной почты
    /// Существует баг(?): https://habrahabr.ru/post/237899/
    /// </summary>
    public static class EmailService
    {
        /// <summary>
        /// Отправка email
        /// </summary>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл</param>
        public static bool SendMail(string mailto, string caption, string message, string attachFile = null)
        {
            return SendMail(new List<string>() { mailto }, caption, message, attachFile);
        }

        /// <summary>
        /// Отправка email
        /// </summary>
        /// <param name="mailto">Адреса получателей</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл</param>
        public static bool SendMail(List<string> mailto, string caption, string message, string attachFile = null)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(Settings.Default.MailFrom);
            foreach (string s in mailto)
            {
                 mail.To.Add(new MailAddress(s));
            }
            mail.Subject = caption;
            mail.IsBodyHtml = true;
            mail.Body = message;
            if (!string.IsNullOrEmpty(attachFile))
            {
                mail.Attachments.Add(new Attachment(attachFile));
            }
            bool rez = Send(mail);
            mail.Dispose();
            return rez;
        }

        /// <summary>
        /// Отправляет письмо используя Базовую модель письма <paramref name="model" />
        /// и опработаный шаблон письма <paramref name="HtmlString" />
        /// </summary>
        /// <param name="model"></param>
        /// <param name="HtmlString"></param>
        /// <returns></returns>
        public static bool SendMail(BaseEmailModel model, string HtmlString)
        {
            return SendMail(model.MailTo, model.Caption, HtmlString, null);
        }

        /// <summary>
        /// Инициализирует SmtpClient и отправляет почту
        /// </summary>
        /// <param name="mail"></param>
        private static bool Send(MailMessage mail)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = Settings.Default.MailHost;
                client.Port = Settings.Default.MailPort;
                client.EnableSsl = Settings.Default.MailEnableSsl;
                client.Credentials = new NetworkCredential(Settings.Default.MailFrom.Split('@')[0], Settings.Default.MailPassword);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                client.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}