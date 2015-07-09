using System;
using System.Collections.Generic;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Domínio;
using Demo.Dominio.Interfaces.Infraestrutura;
using Demo.Dominio.Interfaces.Repositórios;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Sequences;

namespace Demo.Aplicacao.Testes
{
    public class ServiceLocatorProviderFake : IServiceLocator
    {
        private IUnidadeDeTrabalho _unidadeDeTrabalho;

        public ServiceLocatorProviderFake(IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public TService GetInstance<TService>(string key)
        {
            throw new NotImplementedException();
        }

        public TService GetInstance<TService>()
        {
            if (typeof(TService) == typeof(IUnidadeDeTrabalho))
            {
                return (TService)_unidadeDeTrabalho;
            }

            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType, string key)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class TesteDeServicoDeAplicacaoDeProduto
    {
        private Mock<IServicoDeCadastroDeProduto> mockDoServicoDeProduto;
        private Mock<IRepositorioDeProduto> mockDoRepositorioDeProduto;
        private ServicoDeAplicacaoDeProduto servico;
        private Mock<IUnidadeDeTrabalho> mockDaUnidadeDeTrabalho;

        [TestInitialize]
        public void IniciarTestes()
        {
            mockDoServicoDeProduto = new Mock<IServicoDeCadastroDeProduto>();
            mockDoRepositorioDeProduto = new Mock<IRepositorioDeProduto>();

            servico = new ServicoDeAplicacaoDeProduto(mockDoServicoDeProduto.Object, mockDoRepositorioDeProduto.Object);


            mockDaUnidadeDeTrabalho = new Mock<IUnidadeDeTrabalho>();

            ServiceLocator.SetLocatorProvider(() => new ServiceLocatorProviderFake(mockDaUnidadeDeTrabalho.Object));
        }


        [TestMethod]
        public void Quando_CadastrarProduto_chamar_cadastrar_do_dominio_dentro_de_uma_transacao()
        {
            // arrange
            var produto = new Produto();
            using (Sequence.Create())
            {
                mockDaUnidadeDeTrabalho.Setup(_ => _.Iniciar()).InSequence();
                mockDoServicoDeProduto.Setup(_ => _.CadastrarProduto(produto)).InSequence();
                mockDaUnidadeDeTrabalho.Setup(_ => _.Persistir()).InSequence();

                // act
                servico.CadastrarProduto(produto);
            }
        }


        [TestMethod]
        public void Quando_RemoverPorNome_chamar_remover_do_repositorio_dentro_de_uma_transacao()
        {
            // arrange
            using (Sequence.Create())
            {
                mockDaUnidadeDeTrabalho.Setup(_ => _.Iniciar()).InSequence();
                mockDoRepositorioDeProduto.Setup(_ => _.RemoverPorNome("produto de teste")).InSequence();
                mockDaUnidadeDeTrabalho.Setup(_ => _.Persistir()).InSequence();

                // act
                servico.RemoverPorNome("produto de teste");
            }
        }

        [TestMethod]
        public void Quando_RecuperarTodosOsProdutos_recuperar_todos_do_repositorio()
        {
            // arrange
            var lista = new List<Produto>();
            mockDoRepositorioDeProduto.Setup(_ => _.RecuperarTodos()).Returns(lista);

            // act
            var retorno = servico.RecuperarTodosOsProdutos();

            // assert
            mockDoRepositorioDeProduto.VerifyAll();
            Assert.AreSame(lista, retorno);
        }


        [TestMethod]
        public void Quando_RecuperarPorNome_recuperar_por_nome_no_repositorio()
        {
            // arrange
            var produto = new Produto();
            mockDoRepositorioDeProduto.Setup(_ => _.ObterProdutoPorNome("nome a ser pesquisado")).Returns(produto);

            // act
            var retorno = servico.RecuperarPorNome("nome a ser pesquisado");

            // assert
            mockDoRepositorioDeProduto.VerifyAll();
            Assert.AreSame(produto, retorno);
        }
    }
}
