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

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update([FromBody] UpdateUserModel model)
        {
            return Ok(UserServ.UpdateUser(model).Response());
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult MarkDeleted(int id)
        {
            return Ok(UserServ.MarkDeleted(id).Response());
        }
    }
}
