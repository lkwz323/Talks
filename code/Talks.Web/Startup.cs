using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Talks.Web.Startup))]
namespace Talks.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
