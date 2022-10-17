using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteKinhDoanhCayCanh.Startup))]
namespace WebsiteKinhDoanhCayCanh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
