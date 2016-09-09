using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Getticket.Web.DAL.Enums;
using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Сообщение пользователя <see cref="Entities.User" />
    /// </summary>
    public class UserMessage : BaseEntity
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
        /// FK для <see cref="Entities.User" />
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// Ссылка на пользователя <see cref="Entities.User" />
        /// </summary>
        [ForeignKey("SenderId")]
        [JsonIgnore]
        public virtual User Sender { get; set; }

        /// <summary>
        /// FK для <see cref="Entities.User" />
        /// </summary>
        public int? RecipientId { get; set; }

        /// <summary>
        /// Ссылка на пользователя <see cref="Entities.User" />
        /// </summary>
        [ForeignKey("RecipientId")]
        [JsonIgnore]
        public virtual User Recipient { get; set; }

        /// <summary>
        /// Статус сообщения
        /// </summary>
        public MessageStatus Status { get; set; }
    }
}
