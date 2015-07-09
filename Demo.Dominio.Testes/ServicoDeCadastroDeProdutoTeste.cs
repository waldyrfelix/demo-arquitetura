using Demo.Dominio.Exceptions;
using Demo.Dominio.Interfaces.Repositórios;
using Demo.Dominio.Servicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Demo.Dominio.Testes
{
    [TestClass]
    public class ServicoDeCadastroDeProdutoTeste
    {
        private ServicoDeCadastroDeProduto _servicoDeCadastroDeProduto;
        private Mock<IRepositorioDeProduto> _mockIRepositorioDeProduto;

        [TestInitialize]
        public void IniciarTestes()
        {
            _mockIRepositorioDeProduto = new Mock<IRepositorioDeProduto>();
            _servicoDeCadastroDeProduto = new ServicoDeCadastroDeProduto(_mockIRepositorioDeProduto.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ProdutoException))]
        public void Quando_cadastrar_um_produto_que_ja_existe_lança_exception()
        {
            // arrage
            var produto = new Produto() { Nome = "Camisa Polo" };
            _mockIRepositorioDeProduto
                .Setup(x => x.ProdutoJáExiste(produto.Nome))
                .Returns(true);

            // act
            _servicoDeCadastroDeProduto.CadastrarProduto(produto);
        }

        [TestMethod]
        public void Quando_cadastrar_um_produto_que_não_existe_insere_no_repositorio()
        {
            // arrage
            var produto = new Produto { Nome = "Camisa Polo" };
            _mockIRepositorioDeProduto
                .Setup(x => x.ProdutoJáExiste(produto.Nome))
                .Returns(false);

            // act
            _servicoDeCadastroDeProduto.CadastrarProduto(produto);

            // assert
            _mockIRepositorioDeProduto.Verify(x => x.Inserir(produto), Times.Once());
        }

    }
}
