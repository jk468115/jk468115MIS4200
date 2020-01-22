using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jk468115MIS4200.Startup))]
namespace jk468115MIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
