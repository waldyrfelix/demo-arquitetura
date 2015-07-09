using Demo.Dominio.Interfaces.Repositórios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Demo.Aplicacao.Testes
{
    [TestClass]
    public class TesteDeServicoDeAplicacaoDaTransportadora
    {
        private Mock<IRepositorioDeTransportadora> mockDoRepositorioDeTransportadoras;
        private ServicoDeAplicacaoDaTransportadora servico;

        [TestInitialize]
        public void IniciarTeste()
        {
            mockDoRepositorioDeTransportadoras = new Mock<IRepositorioDeTransportadora>();
            servico = new ServicoDeAplicacaoDaTransportadora(mockDoRepositorioDeTransportadoras.Object);
        }

        [TestMethod]
        public void Quando_chamar_RecuperarTodasAsTransportadoras_repassar_chamada_para_o_repositorio_de_transportadora()
        {
            // arrange
            mockDoRepositorioDeTransportadoras.Setup(x => x.RecuperarTodos());

            //act
            servico.RecuperarTodasAsTransportadoras();

            //assert
            mockDoRepositorioDeTransportadoras.VerifyAll();
        }
    }
}