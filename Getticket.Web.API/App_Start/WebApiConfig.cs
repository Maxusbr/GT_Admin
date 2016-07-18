﻿using Getticket.Web.API.Attributes;
using Ninject;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Getticket.Web.API
{
    /// <summary>
    /// Конфигурация Web Api и фильтров
    /// </summary>
    public static class WebApiConfig
    {

        /// <summary>
        /// Регистрация настроек
        /// </summary>
        /// <param name="config"></param>
        /// <param name="kernel"></param>
        public static void Register(HttpConfiguration config, IKernel kernel)
        {
            var cors = new EnableCorsAttribute("http://getticket.azurewebsites.net", "*", "*");
            config.EnableCors();

            // Маршруты веб-API основанные на атрибутах
            config.MapHttpAttributeRoutes();

            // Проверяем состояние модели на каждом контроллере
            config.Filters.Add(kernel.Get<ValidateModelStateAttribute>());
        }
    }
}
