using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VendBot.Startup))]
namespace VendBot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
