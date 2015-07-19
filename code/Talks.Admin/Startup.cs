using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Talks.Admin.Startup))]
namespace Talks.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
