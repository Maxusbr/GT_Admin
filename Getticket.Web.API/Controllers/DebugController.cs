using System.Web.Http;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Repository;
using Getticket.Web.API.Services;
using System.Collections.Generic;

namespace Getticket.Web.API.Controllers
{
    /// <summary>
    /// Контроллер исключительно для отладки приложения
    /// </summary>
    [RoutePrefix("debug")]
    [Authorize(Roles = "Admin")]
    public class DebugController : ApiController
    {
        private UserRepository UserRep;
        private UserRegistrationService UserRegServ;

        public DebugController()
        {
            this.UserRep = new UserRepository();
            this.UserRegServ = new UserRegistrationService();
        }

        [HttpPost]
        [Route("users/seed")]
        [AllowAnonymous]
        public IHttpActionResult UsersSeed()
        {
            
            return Ok();
        }

        [HttpPost]
        [Route("mail")]
        public IHttpActionResult SendMailTo()
        {
            string From = this.User.Identity.Name != null ? this.User.Identity.Name : "Uknown";
            string To = "maria.s@sunrise-r.ru";
            EmailService.SendMailToOne(To, "Тест отправки письма", "Hello from " + From);
            return Ok("sended");
        }

        [HttpPost]
        [Route("test")]
        public IHttpActionResult Test()
        {
            UserInfo ui = new UserInfo() { Phone = "+79159998877" };
            AccessRole ar = new AccessRole() { Name = "ar1" };
            User user = new User { UserName = "Вася", AccessRole = ar, UserInfo = ui };
            UserRep.Save(user);

            user.UserInfo.Name = "Василий";
            UserRep.Save(user);

            AccessRole ar2 = new AccessRole() { Name = "ar2" };
            user.AccessRole = ar2;
            UserRep.Save(user);

            UserRep.Delete(user);
            return Ok();
        }

        [HttpPost]
        [Route("test1")]
        public IHttpActionResult Test1()
        {
            User user = new User() {
                UserName = "test@test.ru",
                UserInfo = new UserInfo(),
                UserStatus = new UserStatus(),
                AccessRole = new AccessRole()
            };

            if (UserRep.Save(user) != null)
            {
                return Ok();
            }
            return Json<string>("Error!!!!");
        }

        [HttpPost]
        [Route("test2")]
        public IHttpActionResult Test2()
        {
            User user = UserRep.FindOneById(1);
            if (user != null)
            {
                user.UserName = "werwwtt@yaetd.ru";
                user.UserInfo.Name = "Иван";
                user.UserInfo.LastName = "Петров";
                user = UserRep.Save(user);
                return Ok();
            }

            return Json<string>("Error!!!!");
        }

        [HttpPost]
        [Route("test3")]
        public IHttpActionResult Test3()
        {
            if (UserRep.Delete(1))
            {
                return Json<string>("Record delete");
            }

            return Json<string>("Error!!!!");
        }

        [HttpPost]
        [Route("test4")]
        public IHttpActionResult Test4()
        {
            List<string> emails = new List<string>();
            emails.Add("mari_yar@inbox.ru");
            emails.Add("petr-marial@yandex.ru");
            emails.Add("maria.s@sunrise-r.ru");
            string body = "Здравствуйте! <br/><br/> Перейдите по ссылке  <a href='http://{1}/User/Activate/{0}'>http://{1}/User/Activate/{0}</a>, чтобы подтвертить свой почтовый ящик.<br/>-----<br/>С уважением, команда <a href='http://{1}'>{1}</a>";
            EmailService.SendMailToList(emails, "Это письмо для всех", body);
            return Json<string>("send email");
        }
    }
}
