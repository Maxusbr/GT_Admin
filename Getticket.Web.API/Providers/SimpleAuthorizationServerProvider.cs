using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Getticket.Web.DAL.IRepositories;

namespace Getticket.Web.API.Providers
{
    // gets idea from StackOveflow
    // http://stackoverflow.com/questions/33398961/db-first-authentication-confusion-with-asp-net-web-api-2-ef6
    /// <summary>
    /// Проверяет аутонтификацию и авторизацию пользователя.
    /// </summary>
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private CredentailsService Credentails;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public SimpleAuthorizationServerProvider(CredentailsService Credentails, IUserRepository userRepository)
        {
            this.Credentails = Credentails;
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        /// <summary>
        /// Предоставляет авторизацию на доступ к ресурсам
        /// используя identity.AddClaim
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            IFormCollection data = await context.Request.ReadFormAsync();
            string UserName = context.UserName;
            string UserPassword = context.Password;
            string UserPhone = data.Get("phone");

            User user = Credentails.Authenticate(UserName, UserPhone, UserPassword);
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.UserName));

                List<string> rolesNames = new List<string>();
                foreach (AccessRoleType role in Enum.GetValues(typeof(AccessRoleType)))
                {
                    if (user.AccessRoles.Role.HasFlag(role) && (role != AccessRoleType.None))
                    {
                        rolesNames.Add(role.ToString());
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
                    }
                }
                var principal = new GenericPrincipal(identity, rolesNames.ToArray());
                Thread.CurrentPrincipal = principal;
                context.Validated(identity);
                _userRepository.UpdateLastEnter(user.Id, DateTime.Now);
                return;
            }
            context.SetError("invalid_grant", "User name or password were not recognized");
            return;
        }

        public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            if (context.IsTokenEndpoint && context.Request.Method == "OPTIONS")
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "authorization" });
                context.RequestCompleted();
                return Task.FromResult(0);
            }

            return base.MatchEndpoint(context);
        }
    }
}