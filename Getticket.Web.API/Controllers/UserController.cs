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
        public UserController()
        {
            this.UserServ = new UserService();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok<IList<User>>(UserServ.GetAll());
        }

        [HttpPost]
        [Route("{id}")]
        public IHttpActionResult GetOne(int id)
        {
            User user = UserServ.GetById(id);
            if (user == null)
            {
                return Json<string>("User with id = " + id + " not found");
            }
            return Ok<User>(user);
        }

        /// <summary>
        /// Регестрирует пользователя в системе
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
        /// Обновляет информацию пользователя
        /// имя = model.Name 
        /// фамилия = model.LastName 
        /// компания = model.Company  
        /// должность = model.Position 
        /// электронная почта = model.Email 
        /// телефон = model.Phone 
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
        /// Изменяет пароль пользователю.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("changepass/{id}")]
        public IHttpActionResult ChangePassword(int id,[FromBody] ChangePasswordModel model)
        {
            string nameUserIn = this.User.Identity.Name;
            return Ok(UserServ.ChangePassword(id, nameUserIn, model).Response());
        }

        [HttpPost]
        [Route("lock/{id}")]
        public IHttpActionResult Lock(int id)
        {
            return Ok(UserServ.Lock(id).Response());
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult MarkDeleted(int id)
        {
            return Ok(UserServ.MarkDeleted(id).Response());
        }
    }
}
