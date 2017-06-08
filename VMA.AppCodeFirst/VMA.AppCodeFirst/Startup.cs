using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VMA.AppCodeFirst.Startup))]
namespace VMA.AppCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
