using System;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    /// <summary>
    /// Контроллер для работы с приглашениями пользователей
    /// </summary>
    [RoutePrefix("invites")]
    [Authorize(Roles = "Admin")]
    public class InviteController : ApiController
    {
        /// <summary>
        /// Возвращает всех пользователей которые:
        /// 1.получили приглашение и еще не ответили на него,
        /// 2.ответили на приглашение, но еще не получили "Акцепта(ТЗ стр.8)"
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult GetAllInvitedUsers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Отправляет приглашение пользователю
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("send")]
        public IHttpActionResult SendInvite()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Проверяет есть ли активный инвайт по коду
        /// и возвращает Id роли и Email приглашенного
        /// пользователя для использования при обновлении
        /// информации приглашенного пользователя
        /// </summary>
        /// <param name="code">Код приглашения</param>
        /// <returns></returns>
        [HttpPost]
        [Route("accept/{code}")]
        public IHttpActionResult AcceptInvite(string code)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Обновляет данные приглашения пользователя
        /// и переводит статус приглашения в статус ожидающий
        /// "Акцепта(ТЗ стр.8)"
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update/{code}")]
        public IHttpActionResult UpdateAcceptedInvite(string code)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Переводит пользователя из 
        /// приглашенного в зарегестрированного
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("confirm/{Id}")]
        public IHttpActionResult ConfirmAcceptedInvite(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаляет существующее приглашение и самого 
        /// пользователя из системы 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("delete/{Id}")]
        public IHttpActionResult DeleteInvite(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
