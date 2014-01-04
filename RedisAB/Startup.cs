using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedisAB.Startup))]
namespace RedisAB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
