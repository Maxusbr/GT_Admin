using System.Web.Http;

namespace Getticket.Web.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            // Маршруты веб-API основанные на атрибутах
            config.MapHttpAttributeRoutes();
        }
    }
}
