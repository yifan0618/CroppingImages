using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CroppingImages.Startup))]
namespace CroppingImages
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
