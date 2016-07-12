using Getticket.Web.API.Models.Emails;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;

namespace Getticket.Web.API.Providers
{
    /// <summary>
    /// Предоставляет настроеный экземпляр
    /// RazorEngineService
    /// </summary>
    public static class RazorTemplateProvider
    {
        /// <see cref="RazorTemplateProvider"/>
        public static IRazorEngineService Get()
        {
            var config = new TemplateServiceConfiguration();
            string temlatesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");
            config.TemplateManager = new ResolvePathTemplateManager(new List<string>() { temlatesPath });
            var service = RazorEngineService.Create(config);
            PrepareTemplates(service);
            return service;
        }

        /// <summary>
        /// Компиляция и кеширование шаблонов для последующего использования
        /// </summary>
        /// <param name="service"></param>
        private static void PrepareTemplates(IRazorEngineService service)
        {
            service.Compile("Emails/Invite", typeof(InviteEmailModel));
            service.Compile("Emails/Registered", typeof(RegisteredEmailModel));
            service.Compile("Emails/ChangePassword", typeof(ChangePasswordEmailModel));
            service.Compile("Emails/RestorePassword", typeof(RestorePasswordEmailModel));
        }
    }
}
