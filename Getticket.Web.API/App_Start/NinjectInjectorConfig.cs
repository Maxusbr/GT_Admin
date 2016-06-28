﻿using Getticket.Web.API.Providers;
using Getticket.Web.DAL.IRepositories;
using Getticket.Web.DAL.Repository;
using Ninject;
using Owin;
using RazorEngine.Templating;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Microsoft.Owin.Security.OAuth;
using System.Reflection;

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
        /// <param name="app"></param>
        /// <param name="config"></param>
        public static IKernel Register(HttpConfiguration config)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            InjectConfig(kernel);
            return kernel;
        }

        private static void InjectConfig(IKernel kernel)
        {
            // Bindings for startup
            kernel.Bind<IOAuthAuthorizationServerProvider>().To<SimpleAuthorizationServerProvider>();

            // Create the bindings for project
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IInviteCodeRepository>().To<InviteCodeRepository>();

            kernel.Bind<IRazorEngineService>().ToConstant<IRazorEngineService>(RazorTemplateProvider.Get()).InSingletonScope();
        }
    }
}