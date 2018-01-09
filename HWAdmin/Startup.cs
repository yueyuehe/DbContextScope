using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWAdmin.Startup))]
namespace HWAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
