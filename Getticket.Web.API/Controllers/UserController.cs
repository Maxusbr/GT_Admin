using System;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        public UserController()
        {

        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{id}")]
        public IHttpActionResult GetOne()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult MarkDeleted()
        {
            throw new NotImplementedException();
        }
    }
}
