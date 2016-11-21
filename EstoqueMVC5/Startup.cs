using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstoqueMVC5.Startup))]
namespace EstoqueMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
