using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCbasics.Startup))]
namespace MVCbasics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
