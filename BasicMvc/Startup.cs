using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasicMvc.Startup))]
namespace BasicMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
