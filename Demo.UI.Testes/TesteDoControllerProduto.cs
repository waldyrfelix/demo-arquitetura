using System.Web.Mvc;
using Demo.Aplicacao;
using Demo.Dominio;
using Demo.UI.Controllers;
using DemoMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Demo.UI.Testes
{
    [TestClass]
    public class TesteDoControllerProduto
    {
        private Mock<IServicoDeAplicacaoDeProduto> mockIServicoDeAplicacaoDeProduto;
        private ProdutoController controller;

        [TestInitialize]
        public void IniciarTestes()
        {
            mockIServicoDeAplicacaoDeProduto = new Mock<IServicoDeAplicacaoDeProduto>();
            controller = new ProdutoController(mockIServicoDeAplicacaoDeProduto.Object);
        }

        [TestMethod]
        public void Quando_adicionar_produto_devolver_erro()
        {
            // arrange
            var viewModel = new ProdutoViewModel();
            controller.ModelState.AddModelError("", "Erro qualquer.");

            // act
            var jsonResult = controller.Adicionar(viewModel) as JsonResult;

            // assert
            Assert.AreEqual("{ erro = Erro no form }",
                jsonResult.Data.ToString());
        }

        [TestMethod]
        public void Quando_adicionar_produto_valido_CadastrarProduto_no_servico_de_aplicacao()
        {
            // arrange
            var viewModel = new ProdutoViewModel();

            // act
            controller.Adicionar(viewModel);

            // assert
            mockIServicoDeAplicacaoDeProduto.Verify(x => x.CadastrarProduto(It.IsAny<Produto>()),
                Times.Once());
        }
    }
}
