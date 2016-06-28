using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using System;
using System.Collections.Generic;
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
        private UserInviteService InviteServ;

        /// <summary>
        /// Конструктор
        /// </summary>
        public InviteController(UserInviteService InviteServ)
        {
            this.InviteServ = InviteServ;
        }

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
            return Ok(InviteServ.GetAllInvited());
        }

        /// <summary>
        /// Отправляет приглашение пользователю
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("send")]
        public IHttpActionResult SendInvite([FromBody] SendInviteModel model)
        {
            return Ok(InviteServ.SendInvite(model).Response());
        }

        /// <summary>
        /// Проверяет есть ли активный инвайт по коду
        /// и возвращает Email приглашенного
        /// пользователя для использования при обновлении
        /// информации
        /// 
        /// Метод должен быть незащищен!!!
        /// </summary>
        /// <param name="code">Код приглашения</param>
        /// <returns></returns>
        [HttpPost]
        [Route("accept/{code}")]
        public IHttpActionResult AcceptInvite(string code)
        {
            return Ok(InviteServ.CheckInviteExist(code).Response());
        }

        /// <summary>
        /// Обновляет данные приглашения пользователя
        /// и переводит статус приглашения в статус ожидающий
        /// "Акцепта(ТЗ стр.8)"
        /// 
        /// Метод должен быть незащищен!!!
        /// </summary>
        /// <param name="code">Код приглашения</param>
        /// <param name="model">Модель с данными для обновления</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update/{code}")]
        public IHttpActionResult UpdateAcceptedInvite(string code, [FromBody] UpdateInviteModel model)
        {
            return Ok(InviteServ.UpdateInvite(code, model).Response());
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
