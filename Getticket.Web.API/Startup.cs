using Getticket.Web.API.App_Start;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using System.Web.Http;

[assembly: OwinStartup(typeof(Getticket.Web.API.Startup))]
namespace Getticket.Web.API
{
    /// <summary>
    /// Точка входа приложения
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Настройки приложения
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            // Настройка инжектора
            SimpleInjectorConfig.Register(app, config);
            // Настраиваем маппинг Web.Api путей для контроллера и фильтры
            WebApiConfig.Register(config);
            // Настраиваем авторизацию и выдачу токенов
            OAuthConfig.Register(app, config);
        }
    }
}