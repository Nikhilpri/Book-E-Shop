using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimaryKeyIntTest.Startup))]
namespace PrimaryKeyIntTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
