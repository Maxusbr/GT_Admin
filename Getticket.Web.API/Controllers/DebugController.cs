using System.Web.Http;
using Getticket.Web.DAL.Entities;
using Getticket.Web.API.Services;
using System.Collections.Generic;
using Getticket.Web.DAL.IRepositories;
using RazorEngine.Templating;
using Getticket.Web.API.Models.Emails;
using Getticket.Web.API.Models;
using Getticket.Web.DAL.Enums;

namespace Getticket.Web.API.Controllers
{
    /// <summary>
    /// Контроллер исключительно для отладки приложения
    /// </summary>
    [RoutePrefix("debug")]
    [Authorize(Roles = "Admin")]
    public class DebugController : ApiController
    {
        private IUserRepository UserRep;
        private UserService UserRegServ;
        private IRazorEngineService TemplateServ;
        private AccessRolesService AccessRolesServ;

        public DebugController(IUserRepository UserRep, UserService UserRegServ, IRazorEngineService TemplateServ, AccessRolesService AccessRolesServ)
        {
            this.UserRep = UserRep;
            this.UserRegServ = UserRegServ;
            this.TemplateServ = TemplateServ;
            this.AccessRolesServ = AccessRolesServ;
        }

        [HttpPost]
        [Route("seed")]
        [AllowAnonymous]
        public IHttpActionResult UsersSeed()
        {
            AccessRolesServ.SaveRole(new AccessRoleModel() {
                Id = 0,
                Name = "Admin",
                Desciption = "Test admin role, can do averething",
                Roles = (AccessRoleType.Admin | AccessRoleType.AccessRoleManager).ToString()
            });

            AccessRolesServ.SaveRole(new AccessRoleModel() {
                Id = 0,
                Name = "new role",
                Desciption = "Test role",
                Roles = AccessRoleType.Admin.ToString()
            });

            UserRegServ.CreateSystemUser(new RegisterUserModel() {
                Name = "admin",
                Email = "admin@admin.su",
                Phone = "89159998877",
                LastName = "admin",
                Company = "none",
                Position = "none",
                GeneratePassword = false,
                NotSendWelcome = true,
                Password = "admin",
                RoleId = 1
            });

            UserRegServ.CreateSystemUser(new RegisterUserModel() {
                Name = "teest",
                Email = "teest@admin.su",
                Phone = "89151234455",
                LastName = "admin",
                Company = "none",
                Position = "none",
                GeneratePassword = false,
                NotSendWelcome = true,
                Password = "teest",
                RoleId = 2
            });

            UserRegServ.CreateSystemUser(new RegisterUserModel() {
                Name = "deleted",
                Email = "deleted@admin.su",
                Phone = "89155558822",
                LastName = "admin",
                Company = "none",
                Position = "none",
                GeneratePassword = false,
                NotSendWelcome = true,
                Password = "deleted",
                RoleId = 2
            });

            UserRegServ.MarkDeleted(UserRep.FindOneByEmail("deleted@admin.su").Id);

            return Ok();
        }

        [HttpPost]
        [Route("mail")]
        public IHttpActionResult SendMailTo()
        {
            string From = this.User.Identity.Name != null ? this.User.Identity.Name : "Uknown";
            List<string> To = new List<string>() { "maria.s@sunrise-r.ru"};
            EmailService.SendMail(To, "Тест отправки письма", "Hello from " + From);
            return Ok("sended");
        }

        [HttpPost]
        [Route("test")]
        [AllowAnonymous]
        public IHttpActionResult Test()
        {
            string temp = GlobalConfiguration.Configuration.DependencyResolver.ToString();
            UserInfo ui = new UserInfo() { Company = "Home" };
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public IHttpActionResult Test4()
        {
            string result1 = TemplateServ.Run("Emails/Invite", typeof(InviteEmailModel), new InviteEmailModel() { Link = "dsfdsgsdg" });
            string result2 = TemplateServ.Run("Emails/Invite", typeof(InviteEmailModel), new InviteEmailModel() { Link = "qwertyu" });
            return Ok(result1 + " " + result2);
        }

    }
}
