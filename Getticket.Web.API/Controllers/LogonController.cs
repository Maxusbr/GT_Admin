using Getticket.Web.API.Attributes;
using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    [RoutePrefix("logon")]
    public class LogonController : ApiController
    {
        private CredentailsService Credentails;

        public LogonController(CredentailsService Credentails)
        {
            this.Credentails = Credentails;
        }

        [HttpPost]
        [Route("credentails")]
        public IHttpActionResult Logon([FromBody] LogonModel model)
        {
            AuthModel credentails = Credentails.Authenticate(model);
            if (credentails == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok<AuthModel>(credentails);
            }
        }
    }
}
