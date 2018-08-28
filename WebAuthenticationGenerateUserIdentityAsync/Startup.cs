using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAuthenticationGenerateUserIdentityAsync.Startup))]
namespace WebAuthenticationGenerateUserIdentityAsync
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
