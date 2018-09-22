using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ALX.Startup))]
namespace ALX
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
