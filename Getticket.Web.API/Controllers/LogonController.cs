using System;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    [RoutePrefix("logon")]
    public class LogonController : ApiController
    {
        public LogonController()
        {

        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Logon()
        {
            throw new NotImplementedException();
        }
    }
}
