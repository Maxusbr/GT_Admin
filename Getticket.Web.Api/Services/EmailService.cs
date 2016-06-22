using Getticket.Web.API.Properties;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Служба отправки сообщений электронной почтой
    /// Существует баг(?): https://habrahabr.ru/post/237899/
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Отправка email
        /// </summary>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл</param>
        public static void SendMailToOne(string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(Settings.Default.MailFrom);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = Settings.Default.MailHost;
                client.Port = Settings.Default.MailPort;
                client.EnableSsl = Settings.Default.MailEnableSsl;
                client.Credentials = new NetworkCredential(Settings.Default.MailFrom.Split('@')[0], Settings.Default.MailPassword);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("EmailService: " + e.Message);
            }
        }

        /// <summary>
        /// Отправка email
        /// </summary>
        /// <param name="mailto">Адреса получателей</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл</param>
        public static void SendMailToList(List<string> mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(Settings.Default.MailFrom);
                foreach (string s in mailto)
                {
                    mail.To.Add(new MailAddress(s));
                }
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = Settings.Default.MailHost;
                client.Port = Settings.Default.MailPort;
                client.EnableSsl = Settings.Default.MailEnableSsl;
                client.Credentials = new NetworkCredential(Settings.Default.MailFrom.Split('@')[0], Settings.Default.MailPassword);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("EmailService: " + e.Message);
            }
        }
    }
}