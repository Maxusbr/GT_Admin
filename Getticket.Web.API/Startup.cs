using Getticket.Web.API.App_Start;
using Getticket.Web.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
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
            IKernel kernel = NinjectInjectorConfig.Register(config);
            // Настраиваем маппинг Web.Api путей для контроллера и фильтры
            WebApiConfig.Register(config, kernel);


            // Token and authorization roles provider
            app.UseOAuthAuthorizationServer(kernel.Get<OAuthAuthorizationServerOptionsProvider>());
            // Authentication provider
            app.UseOAuthBearerAuthentication(kernel.Get<OAuthBearerAuthenticationOptions>());
            // Разрешаем запросы с других источников
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            // adds ninject to owin
            app.UseNinjectMiddleware(() => kernel);
            // adds ninject to web api
            app.UseNinjectWebApi(config);
        }
    }
}