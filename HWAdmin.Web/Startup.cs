using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWAdmin.Web.Startup))]
namespace HWAdmin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
