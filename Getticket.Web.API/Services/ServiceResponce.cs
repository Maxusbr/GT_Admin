using System.Collections.Generic;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Стандартные ответы сервисов
    /// </summary>
    public class ServiceResponce
    {
        private Dictionary<string, object> Response;

        private ServiceResponce()
        {
            this.Response = new Dictionary<string, object>();
        }

        /// <summary>
        /// Сервис успешно выполнил свою работу
        /// </summary>
        /// <returns></returns>
        public static ServiceResponce FromSuccess()
        {
            ServiceResponce ServiceResponce = new ServiceResponce();
            return ServiceResponce.Add("status", "success");
        }

        /// <summary>
        /// Сервис завершил свою работу с ошибками
        /// </summary>
        /// <returns></returns>
        public static ServiceResponce FromFailed()
        {
            ServiceResponce ServiceResponce = new ServiceResponce();
            return ServiceResponce.Add("status", "failed");
        }

        /// <summary>
        /// Добавляет ответ к ответу сервиса
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ServiceResponce Add(string key, object value)
        {
            this.Response.Add(key, value);
            return this;
        }

        /// <summary>
        /// Возвращает Dictionary содержащий ответ сервера
        /// и статус завершения
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> Result()
        {
            return this.Response;
        }
    }
}