using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    [RoutePrefix("users")]
    [Authorize(Roles = "Admin")]
    public class UserController : ApiController
    {
        private UserRegistrationService UserRegServ;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserController()
        {
            this.UserRegServ = new UserRegistrationService();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok<IList<User>>(UserRegServ.GetAll()); 
        }

        [HttpPost]
        [Route("{id}")]
        public IHttpActionResult GetOne(int id)
        {
            User user = UserRegServ.GetById(id);
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
            return Ok(UserRegServ.CreateSystemUser(model).Result());
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update([FromBody] UpdateUserModel model)
        {
            return Ok(UserRegServ.UpdateUser(model).Result());
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult MarkDeleted(int id)
        {
            return Ok(UserRegServ.MarkDeleted(id).Result());
        }
    }
}
