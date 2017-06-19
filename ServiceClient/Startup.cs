using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceClient.Startup))]
namespace ServiceClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
