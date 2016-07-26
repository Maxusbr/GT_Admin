using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Enums;
using System;
using System.Web.Http;

namespace Getticket.Web.API.Controllers {
    /// <summary>
    /// Контроллер предоставляющий информацию о доступных системных ролях
    /// и кому они принадлежат.
    /// Доступ имеют только пользователи с ролью <see cref="AccessRoleType.AccessRoleManager"/>
    /// </summary>
    [Authorize(Roles = "AccessRoleManager, Admin")]
    [RoutePrefix("sysroles")]
    public class SystemRolesController : ApiController {

        private AccessRolesService RoleServ;

        /// <summary>
        /// Конструктор
        /// </summary>
        public SystemRolesController(AccessRolesService RoleServ) {
            this.RoleServ = RoleServ;
        }

        /// <summary>
        /// Выдает список всех системных ролей
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll() {
            return Ok(RoleServ.GetAllRoles());
        }

        /// <summary>
        /// Выдает системную роль с <paramref name="Id"/>
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("{Id}")]
        [HttpPost]
        public IHttpActionResult GetOneRole(int Id) {
            return Ok(RoleServ.GetRole(Id));
        }

        /// <summary>
        /// Отображает всех пользователей, которые имеют роль с идентификатором <paramref name="Id"/>
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("{Id}/users")]
        [HttpPost]
        public IHttpActionResult GetUsersByRole(int Id) {
            return Ok(RoleServ.GetUsersByRole(Id));
        }

        /// <summary>
        /// Выдает карту со списком всех допустимых системных ролей для доступа к методам контроллера
        /// </summary>
        /// <returns></returns>
        [Route("types")]
        [HttpPost]
        public IHttpActionResult GetAllManagedRoleTypes() {
            return Ok(RoleServ.GetAvailableRoleTypes());
        }

        /// <summary>
        /// Создает новую роль или обновляет 
        /// существующую если <see cref="AccessRoleModel.Id"/><c> != 0</c>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("save")]
        [HttpPost]
        public IHttpActionResult SaveAccessRole([FromBody] AccessRoleModel model) {
            return Ok(RoleServ.SaveRole(model).Response());
        }
    }
}
