using Getticket.Web.API.Attributes;
using System.Web.Http;

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
        public static void Register(HttpConfiguration config)
        {
            // Маршруты веб-API основанные на атрибутах
            config.MapHttpAttributeRoutes();

            // Проверяем состояние модели на каждом контроллере
            config.Filters.Add(new ValidateModelStateAttribute());
        }
    }
}
