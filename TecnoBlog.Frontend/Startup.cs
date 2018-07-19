using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TecnoBlog.Startup))]
namespace TecnoBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
