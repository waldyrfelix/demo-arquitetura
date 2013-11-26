using Microsoft.Practices.ServiceLocation;
using Ninject;
using NinjectAdapter;

namespace Demo.Infra.IoC
{
    public class IoC
    {
        public IoC()
        {
            Kernel = new StandardKernel(
                new ModuloNinjectDeInfraestrutura(),
                new ModuloNinjectDeRepositorios(),
                new ModuloNinjectDeAplicacao(),
                new ModuloNinjectDeServicosDeDominio());

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        public IKernel Kernel { get; private set; }
    }
}