using System.Web.Http;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Repository;

namespace Getticket.Web.API.Controllers
{
    [RoutePrefix("debug")]
    public class DebugController : ApiController
    {
      private UserRepository userRep = new UserRepository();

        public DebugController()
        {

        }

        [HttpPost]
        [Route("test1")]
        public IHttpActionResult Test1()
        {
            return Ok();
        }
    }
}
