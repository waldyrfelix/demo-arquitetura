using Demo.Infra.IoC;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo.UI.Mvc.Startup))]
namespace Demo.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IoC.Start();
        }
    }
}
