using Getticket.Web.API.Attributes;
using System.Web.Http;

namespace Getticket.Web.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Проверяем состояние модели на каждом контроллере
            GlobalConfiguration.Configuration.Filters.Add(new ValidateModelStateAttribute());

            // Настраиваем маппинг Web.Api
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
