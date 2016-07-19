using Getticket.Web.API.Providers;
using Getticket.Web.DAL.IRepositories;
using Ninject;
using RazorEngine.Templating;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Reflection;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Repositories;
using Ninject.Web.Common;

namespace Getticket.Web.API.App_Start
{
    /// <summary>
    /// Конфигурация NinjectInjectorConfig
    /// </summary>
    public static class NinjectInjectorConfig
    {
        /// <summary>
        /// Регистрация настроек
        /// </summary>
        /// <param name="config"></param>
        public static IKernel Register(HttpConfiguration config)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            InjectConfig(kernel);
            return kernel;
        }

        /// <summary>
        /// Настройка классов для инжекта
        /// </summary>
        /// <param name="kernel"></param>
        private static void InjectConfig(IKernel kernel)
        {
            // Bindings for startup
            kernel.Bind<IOAuthAuthorizationServerProvider>().To<SimpleAuthorizationServerProvider>();

            // Create the bindings for project
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IInviteCodeRepository>().To<InviteCodeRepository>();
            kernel.Bind<IAuthRepository>().To<AuthRepository>();
            kernel.Bind<IAccessRoleRepository>().To<AccessRoleRepository>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();

            kernel.Bind<IPersonService>().To<PersonService>().InRequestScope();

            kernel.Bind<IRazorEngineService>().ToConstant<IRazorEngineService>(RazorTemplateProvider.Get()).InSingletonScope();
        }
    }
}