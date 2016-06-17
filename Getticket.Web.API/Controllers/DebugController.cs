using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    [RoutePrefix("debug")]
    public class DebugController : ApiController
    {
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
