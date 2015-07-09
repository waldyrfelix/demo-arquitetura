using Demo.Dominio.Interfaces.Repositórios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Demo.Aplicacao.Testes
{
    [TestClass]
    public class TesteDeServicoDeAplicacaoDeCliente
    {
        private Mock<IRepositorioDeCliente> mockDoRepositorioDeCliente;
        private ServicoDeAplicacaoDeCliente servico;

        [TestInitialize]
        public void IniciarTestes()
        {
            mockDoRepositorioDeCliente = new Mock<IRepositorioDeCliente>();
            servico = new ServicoDeAplicacaoDeCliente(mockDoRepositorioDeCliente.Object);
        }

        [TestMethod]
        public void Quando_chamar_RecuperarClientePorId_repassar_para_repositorio_de_cliente()
        {
            // act
            servico.RecuperarClientePorId(123);

            // assert
            mockDoRepositorioDeCliente.Verify(x => x.Recuperar(123), Times.Once());
        }
    }
}