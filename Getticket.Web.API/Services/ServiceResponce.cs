using System.Collections.Generic;

namespace Getticket.Web.API.Services
{
    /// <summary>
    /// Стандартные ответы сервисов
    /// </summary>
    public class ServiceResponce
    {
        private Dictionary<string, object> _response;
        private static string _prefix = "add_";
        private static string _status = "status";
        private static string _result = "result";

        /// <summary>
        /// Сервис успешно выполнил свою работу
        /// </summary>
        /// <returns></returns>
        public static ServiceResponce FromSuccess()
        {
            ServiceResponce ServiceResponce = new ServiceResponce();
            return ServiceResponce.Status("success");
        }

        /// <summary>
        /// Сервис завершил свою работу с ошибками
        /// </summary>
        /// <returns></returns>
        public static ServiceResponce FromFailed()
        {
            ServiceResponce ServiceResponce = new ServiceResponce();
            return ServiceResponce.Status("failed");
        }

        /// <summary>
        /// Добавляет дополнительный ответ к ответу сервиса;
        /// Если добавляется один из зарезервированых ключей,
        /// ему дописывается приставка add_
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ServiceResponce Add(string key, object value)
        {
            key = key.ToLower();
            if (key.Equals(_status) || key.Equals(_result))
            {
                key = _prefix + key;
            }
            this._response.Add(key, value);
            return this;
        }

        /// <summary>
        /// Добавляет ответ result к ответу сервиса;
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ServiceResponce Result(object value)
        {
            this._response.Add(_result, value);
            return this;
        }

        /// <summary>
        /// Возвращает Dictionary содержащий ответ сервера
        /// и статус завершения
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> Response()
        {
            return this._response;
        }

        private ServiceResponce Status(object value)
        {
            this._response.Add(_status, value);
            return this;
        }

        private ServiceResponce()
        {
            this._response = new Dictionary<string, object>();
        }
    }
}