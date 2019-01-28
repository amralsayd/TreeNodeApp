using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TreeNodeApp.Startup))]
namespace TreeNodeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
