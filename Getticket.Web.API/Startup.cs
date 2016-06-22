using Getticket.Web.API.Attributes;
using Getticket.Web.API.Authentification;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Getticket.Web.API.Startup))]
namespace Getticket.Web.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureFilters(config);
            ConfigureOAuth(app);
            // Настраиваем маппинг Web.Api для owin
            WebApiConfig.Register(config);
            // Разрешаем запросы с других источников
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                // На продакшн = false
                AllowInsecureHttp = true,
                // Путь по которому получаем токен
                TokenEndpointPath = new PathString("/logon"),
                // Время жизни токена
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                // Кто выдает токены
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        public void ConfigureFilters(HttpConfiguration config)
        {
            // Проверяем состояние модели на каждом контроллере
            config.Filters.Add(new ValidateModelStateAttribute());
        }
    }
}