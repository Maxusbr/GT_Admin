using Microsoft.AspNet.Identity;

namespace Getticket.Web.DAL.Entities
{
    class User : BaseEntity, IUser<int>
    {
        /// <summary>
        /// Уникальное поле для IUser интерфейса
        /// фактически логин для пользователя
        /// хранится как Email в бд
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// Информация о пользователе
        /// Имя, Фамилия, Телефон, Компания и т.д.
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }


        /// <summary>
        /// Роль доступа пользователя к API
        /// </summary>
        public virtual AccessRole AccessRole { get; set; }
    }
}
