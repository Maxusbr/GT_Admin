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
            // Маршруты веб-API основанные на атрибутах
            config.MapHttpAttributeRoutes();
            var enableCorsAttribute = new EnableCorsAttribute("http://localhost:36049",
                                                  "Origin, Content-Type, Accept",
                                                  "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(enableCorsAttribute);
            // Проверяем состояние модели на каждом контроллере
            config.Filters.Add(kernel.Get<ValidateModelStateAttribute>());
        }
    }
}
