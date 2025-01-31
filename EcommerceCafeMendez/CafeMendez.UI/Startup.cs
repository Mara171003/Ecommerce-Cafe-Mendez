using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CafeMendez.UI.Startup))]
namespace CafeMendez.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
