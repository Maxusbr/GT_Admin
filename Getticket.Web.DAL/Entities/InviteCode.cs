using System;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Таблица для хранения приглашений
    /// </summary>
    public class InviteCode : BaseEntity
    {
        /// <summary>
        /// Код приглашения
        /// </summary>
        [Required] public string Code { get; set; }

        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Время до которого приглашение будет хранится
        /// </summary>
        [Required] public DateTime ActiveTo { get; set; }
    }
}
