using Newtonsoft.Json;

namespace Getticket.Web.DAL.Entities
{
    /// <summary>
    /// Информация о пользователе
    /// </summary>
    public class UserInfo : BaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UserInfo(){}

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Должность в компании
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        [JsonIgnore]
        public User User { get; set; }
    }
}
