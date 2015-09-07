using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaxReturn.Startup))]
namespace TaxReturn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
