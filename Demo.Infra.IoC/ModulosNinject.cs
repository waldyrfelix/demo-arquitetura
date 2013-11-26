using Demo.Aplicacao;
using Demo.Dominio.Interfaces.Infra;
using Demo.Dominio.Interfaces.Repositorio;
using Demo.Dominio.Servicos;
using Demo.Infra.Repositorio;
using Demo.Infra.Repositorio.Configuracao;
using Demo.Interfaces.Interfaces.Servico;
using Ninject.Modules;

namespace Demo.Infra.IoC
{
    public class ModuloNinjectDeAplicacao : NinjectModule
    {
        public override void Load()
        {
            Bind<IServicoDeAplicacaoDeProduto>().To<ServicoDeAplicacaoDeProduto>();
            Bind<IServicoDeAplicacaoDeCliente>().To<ServicoDeAplicacaoDeCliente>();
            Bind<IServicoDeAplicacaoDaTransportadora>().To<ServicoDeAplicacaoDaTransportadora>();
        }
    }

    public class ModuloNinjectDeServicosDeDominio : NinjectModule
    {
        public override void Load()
        {
            Bind<IServicoDeCadastroDeProduto>().To<ServicoDeCadastroDeProduto>();
        }
    }

    public class ModuloNinjectDeRepositorios : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositorioDeCliente>().To<RepositorioDeCliente>();
            Bind<IRepositorioDeContasAReceber>().To<RepositorioDeContasAReceber>();
            Bind<IRepositorioDeProduto>().To<RepositorioDeProduto>();
            Bind<IRepositorioDeRepresentante>().To<RepositorioDeRepresentante>();
            Bind<IRepositorioDeTransportadora>().To<RepositorioDeTransportadora>();
            Bind<IRepositorioDeVenda>().To<RepositorioDeVenda>();
        }
    }

    public class ModuloNinjectDeInfraestrutura : NinjectModule
    {
        public override void Load()
        {
            Bind<IGerenciadorDeRepositorioHttp>().To<GerenciadorDeRepositorio>();
            Bind<IUnidadeDeTrabalho>().To<UnidadeDeTrabalhoEF>();
        }
    }
}