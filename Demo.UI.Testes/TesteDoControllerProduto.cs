using System.Web.Mvc;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Aplicação;
using Demo.UI.Mvc.Controllers;
using Demo.UI.Mvc.ViewModels;
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
            var viewResult = controller.Adicionar(viewModel) as ViewResult;

            // assert
            Assert.IsNotNull(viewResult.Model);
            Assert.IsInstanceOfType(viewResult.Model, typeof(ProdutoViewModel));
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
