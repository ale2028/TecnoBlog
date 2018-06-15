using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TecnoBlog.Frontend.Startup))]
namespace TecnoBlog.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
