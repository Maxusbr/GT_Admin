using System;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.API.Models
{
    /// <summary>
    /// Модель сообщения пользователя
    /// </summary>
    public class UserMessageModel : BaseModel
    {
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// FK для <see cref="UserModel" />
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// Ссылка на пользователя <see cref="UserModel" />
        /// </summary>
        public virtual UserModel Sender { get; set; }

        /// <summary>
        /// FK для <see cref="UserModel" />
        /// </summary>
        public int? RecipientId { get; set; }

        /// <summary>
        /// Ссылка на пользователя <see cref="UserModel" />
        /// </summary>
        public virtual UserModel Recipient { get; set; }

        /// <summary>
        /// Статус сообщения
        /// </summary>
        public MessageStatus Status { get; set; }
    }
}
