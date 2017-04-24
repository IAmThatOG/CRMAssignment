using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMAssignment.Startup))]
namespace CRMAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
