using System.Web.Mvc;
using Demo.Dominio.Interfaces.Aplicação;

namespace Demo.UI.Mvc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServicoDeAplicacaoDeCliente _servicoDeAplicacaoDeCliente;

        public ClienteController(IServicoDeAplicacaoDeCliente servicoDeAplicacaoDeCliente)
        {
            _servicoDeAplicacaoDeCliente = servicoDeAplicacaoDeCliente;
        }

        public ActionResult RecuperarClientePorId(int idDoCliente)
        {
            var cliente = _servicoDeAplicacaoDeCliente.RecuperarClientePorId(idDoCliente);
            if (cliente == null)
            {
                return new EmptyResult();
            }
            return Json(cliente.Nome);
        }
    }
}