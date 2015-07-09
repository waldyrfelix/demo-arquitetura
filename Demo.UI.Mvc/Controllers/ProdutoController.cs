using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Demo.Dominio;
using Demo.Dominio.Exceptions;
using Demo.Dominio.Interfaces.Aplicação;
using Demo.UI.Mvc.ViewModels;

namespace Demo.UI.Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IServicoDeAplicacaoDeProduto _servicoDeAplicacaoDeProduto;

        public ProdutoController(IServicoDeAplicacaoDeProduto servicoDeAplicacaoDeProduto)
        {
            _servicoDeAplicacaoDeProduto = servicoDeAplicacaoDeProduto;
        }

        [HttpPost]
        public ActionResult Recuperar(string nome)
        {
            var produto = _servicoDeAplicacaoDeProduto.RecuperarPorNome(nome);
            if (produto == null)
            {
                return new EmptyResult();
            }
            return Json(produto.Preço);
        }

        public ActionResult Listar()
        {
            ViewBag.Produtos = obterListaDoViewModelDeProduto();

            return View();
        }

        private List<ProdutoViewModel> obterListaDoViewModelDeProduto()
        {
            return _servicoDeAplicacaoDeProduto.RecuperarTodosOsProdutos()
                .Select(produto =>
                        new ProdutoViewModel
                            {
                                Nome = produto.Nome,
                                Preco = produto.Preço
                            }).ToList();
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            var produto = new ProdutoViewModel();
            return View(produto);
        }

        [HttpPost]
        public ActionResult Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto
                                  {
                                      Nome = produtoViewModel.Nome,
                                      Preço = produtoViewModel.Preco
                                  };

                try
                {
                    _servicoDeAplicacaoDeProduto.CadastrarProduto(produto);
                    return RedirectToAction("Listar");
                }
                catch (ProdutoException exception)
                {
                    ModelState.AddModelError("Validação",exception.Message);
                    return View(produtoViewModel);
                }
            }

            return View(produtoViewModel);
        }

        public ActionResult Deletar(string nome)
        {
            _servicoDeAplicacaoDeProduto.RemoverPorNome(nome);
            return PartialView("_ListaDeProdutos", obterListaDoViewModelDeProduto());
        }

       
    }
}