using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.IRepositories;
using Getticket.Web.DAL.Repository;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Getticket.Web.API.App_Start
{
    /// <summary>
    /// Конфигурация SimpleInjector
    /// </summary>
    public static class SimpleInjectorConfig
    {
        /// <summary>
        /// Регистрация настроек
        /// </summary>
        /// <param name="config"></param>
        public static void Register(IAppBuilder app, HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Регистрация бинов?
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IInviteCodeRepository, InviteCodeRepository>(Lifestyle.Scoped);

            container.Register<CredentailsService>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(config);

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            // TODO постораться избавиться от записи в GlobalConfiguration
            GlobalConfiguration.Configuration.DependencyResolver = config.DependencyResolver;

            // Чтобы можнобыло инжектить в OWIN
            app.Use(async (context, next) => {
                using (container.BeginExecutionContextScope())
                {
                    await next.Invoke();
                }
            });

            // PROD connent it on prodaction
            container.Verify();
        }
    }
}