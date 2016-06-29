using Getticket.Web.API.Services;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    /// <summary>
    /// Контроллер предоставляющий информацию о доступных системных ролях
    /// и кому они принадлежат
    /// </summary>
    [Authorize(Roles = "Admin")]
    [RoutePrefix("sysroles")]
    public class SystemRolesController : ApiController
    {
        private AccessRolesService RoleServ;
        /// <summary>
        /// Конструктор
        /// </summary>
        public SystemRolesController(AccessRolesService RoleServ)
        {
            this.RoleServ = RoleServ;
        }

        /// <summary>
        /// Выдает список всех системных ролей
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public IHttpActionResult GetAll()
        {
            return Ok(RoleServ.GetAllRoles());
        }

        /// <summary>
        /// Отображает всех пользователей, которые имеют роль с идентификатором <paramref name="Id"/>
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("{Id}")]
        [HttpPost]
        public IHttpActionResult GetUsersByRole(int Id)
        {
            return Ok(RoleServ.GetUsersByRole(Id));
        }
    }
}
