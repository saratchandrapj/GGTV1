using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GGKV2.Startup))]
namespace GGKV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
