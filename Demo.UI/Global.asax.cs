using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Demo.Dominio.Interfaces.Infra;
using Demo.Infra.IoC;
using DemoMVC.Infra;
using Microsoft.Practices.ServiceLocation;

namespace DemoMVC
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Rota_Produto",
                "{controller}/{action}/{nome}",
                new {controller = "Produto", action = "Listar", nome = UrlParameter.Optional});
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new DemoDependencyResolver());

            ConfiguraçãoAutoMapper.Inicializar();
        }

        protected void Application_EndRequest()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorioHttp>();
            gerenciador.Finalizar();
        }
    }
}