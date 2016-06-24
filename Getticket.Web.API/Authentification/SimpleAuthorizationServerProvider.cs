using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Getticket.Web.API.Authentification
{
    // gets idea from StackOveflow
    // http://stackoverflow.com/questions/33398961/db-first-authentication-confusion-with-asp-net-web-api-2-ef6
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            CredentailsService Credentails = (CredentailsService) 
                GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(CredentailsService));

            User user = await Credentails.Authenticate(context.UserName, context.Password);
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.UserName));

                List<string> rolesNames = new List<string>();
                foreach (AccessRoleType role in Enum.GetValues(typeof(AccessRoleType)))
                {
                    if (user.AccessRole.Role.HasFlag(role) && (role != AccessRoleType.None))
                    {
                        rolesNames.Add(role.ToString());
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
                    }
                }
                var principal = new GenericPrincipal(identity, rolesNames.ToArray());
                Thread.CurrentPrincipal = principal;
                context.Validated(identity);
                return;
            }
            context.SetError("invalid_grant", "User name or password were not recognized");
            return;
        }
    }
}