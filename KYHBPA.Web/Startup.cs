using Microsoft.Owin;
using Owin;
//brittany's comment
[assembly: OwinStartupAttribute(typeof(KYHBPA.Web.Startup))]
namespace KYHBPA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
