using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GT_Admin.Startup))]
namespace GT_Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
