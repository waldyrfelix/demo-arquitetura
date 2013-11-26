using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Demo.Aplicacao;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Infra;
using DemoMVC.Models;

namespace Demo.UI.Controllers
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
                }
                catch (DemoException exception)
                {
                    return Json(new { erro = exception.Message });
                }

                return Json(new { ok = "Produto cadastrado com sucesso." });
            }

            return Json(new { erro = "Erro no form" });
        }

        public ActionResult Deletar(string nome)
        {
            _servicoDeAplicacaoDeProduto.RemoverPorNome(nome);
            return PartialView("_ListaDeProdutos", obterListaDoViewModelDeProduto());
        }

       
    }
}