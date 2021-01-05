using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectUni.Startup))]
namespace ProjectUni
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
