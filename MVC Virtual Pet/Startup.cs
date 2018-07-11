using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Virtual_Pet.Startup))]
namespace MVC_Virtual_Pet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
