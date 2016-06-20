using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using System;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        private UserRegistrationService UserRegServ = new UserRegistrationService();

        public UserController()
        {
        
        }

        //TODO сделать авторизацию
        [HttpPost]
        [Route("")]
        public IHttpActionResult GetAll([FromBody] QueryModel<string> model)
        {
          /*  if (model == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Credentails.CheckAuthorization(model.Credentails, AccessRole.Registered); */
            return Ok(UserRegServ.GetAll()); 
        }

        [HttpPost]
        [Route("{id}")]
        public IHttpActionResult GetOne(int id, [FromBody] QueryModel<string> model)
        {
            User user = UserRegServ.GetById(id);
            if (user == null)
            {
                return Json<string>("User with id = " + id + " not found");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register([FromBody] QueryModel<RegisterUserModel> model)
        {
            User user = UserRegServ.CreateActiveUser(model.Payload);
            if (user == null)
            {
                return Json<string>("user allready exists");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update([FromBody] QueryModel<User> model)
        {
            User user = UserRegServ.UpdateUser(model.Payload);
            if (user == null)
            {
                return Json<string>("User id not found");
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult MarkDeleted(int id, [FromBody] QueryModel<string> model)
        {
            if (!UserRegServ.MarkDelete(1))
            {
                return Json<string>("User with id = " + id + " not found");
            }

            return Json<string>("User with id = " + id + " deleted");
        }
    }
}
