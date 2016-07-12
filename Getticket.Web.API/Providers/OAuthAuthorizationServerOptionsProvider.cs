using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;

namespace Getticket.Web.API.Providers
{
    /// <summary>
    /// Настройки сервера авторицации и выдачи токенов
    /// </summary>
    public class OAuthAuthorizationServerOptionsProvider : OAuthAuthorizationServerOptions
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public OAuthAuthorizationServerOptionsProvider(IOAuthAuthorizationServerProvider OAuthAuthorizationServerProvider) : base()
        {
            // PROD На продакшн = false
            this.AllowInsecureHttp = true;

            // Путь по которому получаем токен
            this.TokenEndpointPath = new PathString("/logon");

            // Время жизни токена
            this.AccessTokenExpireTimeSpan = TimeSpan.FromDays(1);

            // Кто выдает токены
            this.Provider = OAuthAuthorizationServerProvider;
        }
    }
}