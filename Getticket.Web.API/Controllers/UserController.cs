using Getticket.Web.API.Attributes;
using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    [RoutePrefix("users")]
    [Authorize(Roles = "Admin")]
    public class UserController : ApiController
    {
        private UserService UserServ;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserController(UserService UserServ)
        {
            this.UserServ = UserServ;
        }

        /// <summary>
        /// Воозвращает всех(неудаленных пользователей)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(UserServ.GetAll());
        }

        /// <summary>
        /// Возвращаем пользователя по его <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}")]
        public IHttpActionResult GetOne(int id)
        {
           return Ok(UserServ.GetById(id));
        }

        /// <summary>
        /// Регестрирует пользователя в системе, информация берется из <paramref name="model"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register([FromBody] RegisterUserModel model)
        {
            return Ok(UserServ.CreateSystemUser(model).Response());
        }


        /// <summary>
        /// Обновляет информацию пользователя с <paramref name="id"/>, 
        /// информация для обновления берется из <paramref name="model"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update/{id}")]
        [CheckModelForNull]
        public IHttpActionResult Update(int id,[FromBody] UpdateUserModel model)
        {
            return Ok(UserServ.UpdateUser(id, model).Response());
        }

        /// <summary>
        /// Изменяет пароль пользователю и 
        /// (опционально) отправляет ему письмо с новым паролем
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("changepass/{id}")]
        public IHttpActionResult ChangePassword(int id,[FromBody] ChangePasswordModel model)
        {
            string currentUser = this.User.Identity.Name;
            return Ok(UserServ.ChangePassword(id, currentUser, model).Response());
        }

        /// <summary>
        /// Устанавливает статус пользователя с <paramref name="id" /> как "заблокированный"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("lock/{id}")]
        public IHttpActionResult Lock(int id)
        {
            return Ok(UserServ.Lock(id).Response());
        }

        /// <summary>
        /// Разблокирует пользователя с <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("unlock/{id}")]
        public IHttpActionResult UnLock(int id)
        {
            return Ok(UserServ.Unlock(id).Response());
        }

        /// <summary>
        /// Помечает пользователя с <paramref name="id"/> как удаленного;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult MarkDeleted(int id)
        {
            return Ok(UserServ.MarkDeleted(id).Response());
        }

        /// <summary>
        /// Снимает метку "Удаленный" с пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("undelete/{id}")]
        public IHttpActionResult MarkNotDeleted(int id)
        {
            return Ok(UserServ.MarkNotDeleted(id).Response());
        }
    }
}
