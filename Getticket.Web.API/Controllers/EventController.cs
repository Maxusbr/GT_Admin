using System;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    [RoutePrefix("events")]
    [Authorize(Roles = "Admin")]
    public class EventController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        [Route("{Id}")]
        [HttpPost]
        public IHttpActionResult GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create()
        {
            throw new NotImplementedException();
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update()
        {
            throw new NotImplementedException();
        }
    }
}
