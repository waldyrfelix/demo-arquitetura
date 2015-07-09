using System.Web.Mvc;
using CommonServiceLocator.SimpleInjectorAdapter;
using Demo.Aplicacao;
using Demo.Dominio.Interfaces.Aplicação;
using Demo.Dominio.Interfaces.Domínio;
using Demo.Dominio.Interfaces.Infraestrutura;
using Demo.Dominio.Interfaces.Repositórios;
using Demo.Dominio.Servicos;
using Demo.Infra.Repositorio;
using Demo.Infra.Repositorio.Configuracao;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Demo.Infra.IoC
{
    public static class IoC
    {
        public static void Start()
        {
            var container = new Container();
            container.Register<IServicoDeAplicacaoDeProduto,ServicoDeAplicacaoDeProduto>();
            container.Register<IServicoDeAplicacaoDeCliente,ServicoDeAplicacaoDeCliente>();
            container.Register<IServicoDeAplicacaoDaTransportadora,ServicoDeAplicacaoDaTransportadora>();
            container.Register<IServicoDeCadastroDeProduto, ServicoDeCadastroDeProduto>();
            container.Register<IRepositorioDeCliente,RepositorioDeCliente>();
            container.Register<IRepositorioDeContasAReceber,RepositorioDeContasAReceber>();
            container.Register<IRepositorioDeProduto,RepositorioDeProduto>();
            container.Register<IRepositorioDeRepresentante,RepositorioDeRepresentante>();
            container.Register<IRepositorioDeTransportadora,RepositorioDeTransportadora>();
            container.Register<IRepositorioDeVenda,RepositorioDeVenda>();
            container.Register<IGerenciadorDeRepositorio,GerenciadorDeRepositorioHttp>();
            container.Register<IUnidadeDeTrabalho,UnidadeDeTrabalhoEF>();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}