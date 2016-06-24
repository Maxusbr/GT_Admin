using Getticket.Web.API.Authentification;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

namespace Getticket.Web.API.App_Start
{
    /// <summary>
    /// Настройки сервера авторицации и выдачи токенов
    /// </summary>
    public static class OAuthConfig
    {

        /// <summary>
        /// Регистрация настроек
        /// </summary>
        /// <param name="app"></param>
        /// <param name="config"></param>
        public static void Register(IAppBuilder app, HttpConfiguration config)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                // PROD На продакшн = false
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
            // Разрешаем запросы с других источников
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            // Объединяем OWIN и ASP.NET Web API
            app.UseWebApi(config);
        }
    }
}