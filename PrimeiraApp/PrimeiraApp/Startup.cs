using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimeiraApp.Startup))]
namespace PrimeiraApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
