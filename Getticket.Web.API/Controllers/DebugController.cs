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
            User user = new User();

            user.UserName = "wer@yaetd.ru";
            user.UserInfo = new UserInfo();

            if (userRep.Add(user) != null)
            {
                return Ok();
            }
            return Json<string>("Error!!!!");
        }

        [HttpPost]
        [Route("test2")]
        public IHttpActionResult Test2()
        {
            User user = userRep.Find(1);
            if (user != null)
            {
                user.UserName = "werwwtt@yaetd.ru";
                user.UserInfo.Name = "Иван";
                user.UserInfo.LastName = "Петров";
                user = userRep.Update(user);
                return Ok();
            }

            return Json<string>("Error!!!!");
        }

        [HttpPost]
        [Route("test3")]
        public IHttpActionResult Test3()
        {
            if (userRep.Delete(1))
            {
                return Json<string>("Record delete");
            }

            return Json<string>("Error!!!!");
        }
    }
}
