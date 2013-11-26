using System.Web.Mvc;
using Demo.Infra.Repositorio;

namespace Demo.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repositorio = new RepositorioDeCliente();
            

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}