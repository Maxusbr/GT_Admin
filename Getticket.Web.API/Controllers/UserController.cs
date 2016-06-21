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
        private CredentailsService Credentails;

        public UserController()
        {
            this.UserRegServ = new UserRegistrationService();
            this.Credentails = new CredentailsService();
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

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register([FromBody] RegisterUserModel model)
        {
            User user = UserRegServ.CreateActiveUser(model);
            if (user == null)
            {
                return Json<string>("user allready exists");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update([FromBody] UpdateUserModel model)
        {
            User user = UserRegServ.UpdateUser(model);
            if (user == null)
            {
                return Json<string>("User id not found");
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult MarkDeleted(int id)
        {
            if (!UserRegServ.MarkDelete(id))
            {
                return Json<string>("User with id = " + id + " not found");
            }

            return Json<string>("User with id = " + id + " deleted");
        }
    }
}
