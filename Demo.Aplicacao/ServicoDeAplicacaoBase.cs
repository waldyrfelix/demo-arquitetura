using Demo.Dominio.Interfaces.Infra;
using Microsoft.Practices.ServiceLocation;

namespace Demo.Aplicacao
{
    public class ServicoDeAplicacaoBase
    {
        private IUnidadeDeTrabalho unidadeDeTrabalho;

        public virtual void IniciarTransação()
        {
            unidadeDeTrabalho = ServiceLocator.Current.GetInstance<IUnidadeDeTrabalho>();
            unidadeDeTrabalho.Iniciar();
        }

        public virtual void PersistirTransação()
        {
            unidadeDeTrabalho.Persistir();
        }
    }
}